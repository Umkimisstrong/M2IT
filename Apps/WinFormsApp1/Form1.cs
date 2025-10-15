using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initEvent();
        }

        private void initEvent()
        {
            this.Load += Form1_Load;
            this.btnClick.Click += BtnClick_Click;
        }

        private void BtnClick_Click(object? sender, EventArgs e)
        {
            //printTxt();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object? sender, EventArgs e)
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

            
            this.txtPrint.Text = sb.ToString();

        }


    }
}
