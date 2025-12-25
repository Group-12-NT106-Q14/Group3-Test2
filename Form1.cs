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
    }
}
