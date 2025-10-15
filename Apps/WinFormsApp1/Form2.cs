using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private string forecastUrl = "https://apihub.kma.go.kr/api/typ01/url/fct_afs_dl.php?";
        public Form2()
        {
            InitializeComponent();
            initEvent();
        }

        private void initEvent()
        {
            this.Load += Form2_Load;
            this.btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            getForeCastInfo();
        }

        private void  Form2_Load(object? sender, EventArgs e)
        {


        }



        private void getForeCastInfo()
        {
            int iTm_fc = 1;
            string tm_fc = "00";
            string tm_fc2 = "06";
            if (int.TryParse(DateTime.Now.ToString("HH"), out iTm_fc))
            {
                if (iTm_fc >= 0 && iTm_fc < 6)
                {
                    tm_fc = "00";
                    tm_fc2 = "06";
                }
                else if (iTm_fc >= 6 && iTm_fc < 12)
                {
                    tm_fc = "06";
                    tm_fc2 = "12";
                }
                else if (iTm_fc >= 12 && iTm_fc < 18)
                {
                    tm_fc = "12";
                    tm_fc2 = "18";
                }
                else if (iTm_fc >= 18 && iTm_fc <= 23)
                {
                    tm_fc = "18";
                    tm_fc2 = "23";
                }
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string forecastParams = "reg=11B10101&" + "tmfc1=" + DateTime.Now.ToString("yyyyMMdd") + tm_fc + "&" + "tmfc2=" + DateTime.Now.ToString("yyyyMMdd") + tm_fc2 + "&disp=0&help=1&authKey=_n1x6n-5Sji9cep_uVo4Uw";
            forecastUrl = forecastUrl + forecastParams;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(forecastUrl).Result;
                var byteData = response.Content.ReadAsByteArrayAsync().Result;
                string rawText = Encoding.GetEncoding("euc-kr").GetString(byteData);

                // 결과만 추출: 주석 줄(#으로 시작하는 줄) 제거
                string[] lines = rawText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                StringBuilder resultText = new StringBuilder();

                foreach (var line in lines)
                {
                    if (!line.StartsWith("#") && !string.IsNullOrWhiteSpace(line))
                    {
                        resultText.AppendLine(line);
                    }
                }

                // 결과를 richTextBox에 출력
                rtxForeCast.Text = resultText.ToString();

            }
        }
    }
}
