using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Group3_Test2
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string CookieToken = "itgcdMQgkBrwE23iTQaHSqsHtp3oy7mZJtkaJhP_MB9yPkbWA1HrEPVYSyki9vmPjjlCz4n4TlitXwVpPMw-Sze8jP77B7Iqueof9kyzWA41";
        private const string FormToken = "FlJYEcyZa8OLStfreEueXwMT31d_2A2DLbxAvLM7jUx2LLUUmTawidlEpWv9g_bYc-EQumtJ1IXbLCBwaCn4tROsHpybrUSGNcAlUOJCvic1";
        public Form1()
        {
            InitializeComponent();
            if (!client.DefaultRequestHeaders.Contains("User-Agent"))
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", $"__RequestVerificationToken={CookieToken};");
            }
        }
        public class DataStructure
        {
            public string TradingDate { get; set; }
            public string StockCode { get; set; }
            public string FinanceURL { get; set; }
            public string StockName { get; set; }
            public int BasicPrice { get; set; }
            public int OpenPrice { get; set; }
            public int ClosePrice { get; set; }
            public int HighestPrice { get; set; }
            public int LowestPrice { get; set; }
            public int AvrPrice { get; set; }
            public int Change { get; set; }
            public double PerChange { get; set; }
            public long TotalVol { get; set; }
        }

        private async Task Test()
        {
            string url = "https://finance.vietstock.vn/data/KQGDThongKeGiaPaging";
            if (!int.TryParse(tb_Size.Text, out int pageSize) || pageSize <= 0) pageSize = 100;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            // form-url-encoded 
            var form = new Dictionary<string, string>
            {
                ["page"] = "1",
                ["pageSize"] = pageSize.ToString(),
                ["catID"] = "1",
                ["date"] = date,
                ["__RequestVerificationToken"] = FormToken
            };
            using var content = new FormUrlEncodedContent(form);
            HttpResponseMessage response = await client.PostAsync(url, content);
            string body = await response.Content.ReadAsStringAsync();
            // Nếu server trả HTML
            if (body.TrimStart().StartsWith("<"))
            {
                MessageBox.Show("API không trả JSON mà trả HTML (do token/cookie hết hạn hoặc request không hợp lệ).");
                return;
            }
            response.EnsureSuccessStatusCode();
            //Response là mảng, data nằm ở phần tử thứ 3 (index = 2)
            JArray root = JArray.Parse(body);
            var data = root.Count > 2 ? root[2].ToObject<List<DataStructure>>() : new List<DataStructure>();
            // Hiển thị
            richTextBox1.Clear();
            listView1.Items.Clear();
            foreach (var item in data)
            {
                listView1.Items.Add(new ListViewItem(item.FinanceURL ?? ""));
                richTextBox1.AppendText($"Trading Date: {item.TradingDate}\n");
                richTextBox1.AppendText($"Stock Name: {item.StockName}\n");
                richTextBox1.AppendText($"Basic Price: {item.BasicPrice}\n");
                richTextBox1.AppendText($"Lowest Price: {item.LowestPrice}\n");
                richTextBox1.AppendText($"Highest Price: {item.HighestPrice}\n");
                richTextBox1.AppendText($"AvrPrice: {item.AvrPrice}\n");
                richTextBox1.AppendText($"Change: {item.Change}\n");
                richTextBox1.AppendText($"Per Change: {item.PerChange}\n");
                richTextBox1.AppendText($"ToTal Vol: {item.TotalVol}\n\n");
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await Test();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string toEmail = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                MessageBox.Show("Nhập email người nhận trước.");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Chưa có dữ liệu. Bấm 'Tìm kiếm' trước.");
                return;
            }
            // 1) Lưu thành .txt =
            string bin = AppDomain.CurrentDomain.BaseDirectory; //mặc định
            string filePath = Path.Combine(bin, $"BaoCaoKLGD.txt");
            File.WriteAllText(filePath, richTextBox1.Text, Encoding.UTF8);
            // 2) Gửi Gmail
            try
            {
                using var mail = new MailMessage();
                mail.From = new MailAddress("group12.nt106.q14@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = $"Báo cáo khối lượng giao dịch";
                mail.Body = "Đính kèm là file báo cáo khối lượng giao dịch (.txt).";
                mail.Attachments.Add(new Attachment(filePath));
                using var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(
                    "group12.nt106.q14@gmail.com",
                    "tmjx bacw rvsg dybr"
                );
                smtp.Send(mail);
                MessageBox.Show("Gửi email thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi email thất bại: " + ex.Message);
            }
        }
    }
}
