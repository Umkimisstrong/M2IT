using System.Data;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private DataTable contentDt;

        public Form1()
        {
            InitializeComponent();
            initEvent();
        }

        
        private void initEvent()
        {
            this.Load += Form1_Load;
            this.txtContent.KeyDown += TxtContent_KeyDown;
            this.btnAdd.Click += BtnAdd_Click;
            this.grdContents.CellClick += GrdContents_CellClick;
            this.btnForeCast.Click += BtnForeCast_Click;
        }

        private void BtnForeCast_Click(object? sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void initDesign()
        {
            grdContents.RowHeadersVisible = false;
        }

        private void GrdContents_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            if (grdContents.DataSource != null && grdContents.Rows[rowIdx] != null && grdContents.Rows[rowIdx].Cells["CONTENT"].Value != null)
            {
                bool checkedValue = false;
                bool.TryParse(grdContents.Rows[rowIdx].Cells["CHECK"].Value.ToString(), out checkedValue);
                contentDt.Rows[rowIdx]["CHECK"] = checkedValue;
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            AddContent();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            initVariables();
            initDesign();
        }
        private void initVariables()
        {
            contentDt = new DataTable();
            contentDt.Columns.Add(new DataColumn("CONTENT"));
            contentDt.Columns.Add(new DataColumn("WRITER"));
            contentDt.Columns.Add(new DataColumn("DATE"));
            contentDt.Columns.Add(new DataColumn("CHECK"));
        }

        private void TxtContent_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                AddContent();
            }
        }

        private void AddContent()
        {

            if (ValidateContent())
            {
                SetContentData();
                RefreshContent();
            }
            
        }

        private bool ValidateContent()
        {
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("내용을 작성해주세요.", "주의");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetContentData()
        {
            //grdContents.DataSource = null;

            DataRow row = contentDt.NewRow();
            row["CONTENT"] = txtContent.Text;
            row["WRITER"] = "김상기";
            row["DATE"] = DateTime.Now.ToString("HH:mm:ss");
            row["CHECK"] = false;
            contentDt.Rows.Add(row);
            
            grdContents.DataSource = contentDt;
        }

        private void RefreshContent()
        { 
            txtContent.Clear();
        }


    }
}
