using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

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
    }

}
