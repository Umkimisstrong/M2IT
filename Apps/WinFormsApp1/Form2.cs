using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            initEvent();
        }

        private void initEvent()
        {
            this.Load += Form2_Load;
        }

      

        private void Form2_Load(object? sender, EventArgs e)
        {
            
        }

        private void printTxt()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("123");
            sb.Append("+");
            sb.Append("3");
            sb.Append("=");
            sb.ToString();
            // 123+3=
            string SA = "123" + "+" + "3" + "=";
            SA.ToString();
            // 123+3=

            List<string> list = new List<string>();
            list.Add("!");
            DataTable dt = new DataTable();

            


        }


    }
}
