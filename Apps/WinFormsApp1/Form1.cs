using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// contentDt : 전역 DataTable 변수
        /// </summary>
        private DataTable contentDt;

        /// <summary>
        /// appRootPath : 어플리케이션의 root 경로
        /// </summary>
        private string appRootPath;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Form1 : CheckList Form 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            initEvent();
        }

        /// <summary>
        /// Form1_Load : 폼 로드 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object? sender, EventArgs e)
        {
            initVariables();
            initDesign();
            SetXmlDataForContent();
        }



        /// <summary>
        /// Form1_FormClosing : 폼을 닫을 때 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            MakeXmlDocumentForContent();
        }

        /// <summary>
        /// initEvent : Event 를 초기화
        /// </summary>
        private void initEvent()
        {
            this.Load += Form1_Load;
            this.txtContent.KeyDown += TxtContent_KeyDown;
            this.btnAdd.Click += BtnAdd_Click;
            this.grdContents.CellClick += GrdContents_CellClick;
            this.grdContents.MouseDown += GrdContents_MouseDown;
            this.btnForeCast.Click += BtnForeCast_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnHide.Click += BtnHide_Click;
            this.FormClosing += Form1_FormClosing;
            this.pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;

        }

        /// <summary>
        /// PnlTitleBar_MouseDown : 타이틀바의 마우스 다운 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlTitleBar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }



        /// <summary>
        /// initVariables : 변수 초기화
        /// </summary>
        private void initVariables()
        {
            contentDt = new DataTable();
            contentDt.Columns.Add(new DataColumn("CONTENT"));
            contentDt.Columns.Add(new DataColumn("WRITER"));
            contentDt.Columns.Add(new DataColumn("DATE"));
            contentDt.Columns.Add(new DataColumn("CHECK"));

            appRootPath = "C:\\Users\\KIMSANGKI\\Desktop\\KSK\\998. SOURCE\\M2IT";
            // "C:\\Users\\KIMSANGKI\\Desktop\\KSK\\998. SOURCE\\M2IT\\Apps\\WinFormsApp1\\bin\\Debug\\net8.0-windows\\"
            // "C:\\Users\\KIMSANGKI\\Desktop\\KSK\\998. SOURCE\\M2IT\\Apps\\WinFormsApp1\\bin\\Release\\net8.0-windows\\"
        }
        /// <summary>
        /// initDesign : Design 을 초기화
        /// </summary>
        private void initDesign()
        {
            grdContents.RowHeadersVisible = false;
            grdContents.ScrollBars = ScrollBars.Vertical;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.FormBorderStyle = FormBorderStyle.None;

        }

        /// <summary>
        /// BtnHide_Click : 최소화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHide_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// BtnClose_Click : 폼 닫기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// BtnForeCast_Click : 날씨 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnForeCast_Click(object? sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }


        /// <summary>
        /// GrdContents_CellClick : 그리드 셀 클릭 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// GrdContents_MouseDown : 마우스 우클릭 시 메뉴생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdContents_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = grdContents.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    grdContents.ContextMenuStrip = contextMenuStrip;
                    grdContents.ClearSelection();
                    grdContents.Rows[hitTestInfo.RowIndex].Selected = true;
                    grdContents.CurrentCell = grdContents.Rows[hitTestInfo.RowIndex].Cells["CONTENT"];

                    contextMenuStrip.Items.Add(grdContents.Rows[hitTestInfo.RowIndex].Cells["CONTENT"].Value.ToString() + " 삭제", null, (s, ev) => DeleteRow(hitTestInfo.RowIndex));
                    contextMenuStrip.Show(grdContents, new Point(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// BtnAdd_Click : 추가 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            AddContent();
        }

        /// <summary>
        /// TxtContent_KeyDown : 텍스트 박스 키다운 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtContent_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                AddContent();
            }
        }

        /// <summary>
        /// AddContent : 내용 추가
        /// </summary>
        private void AddContent()
        {

            if (ValidateContent())
            {
                SetContentData();
                RefreshContent();
            }
            
        }

        /// <summary>
        /// DeleteRow : 행 삭제
        /// </summary>
        /// <param name="idx"></param>
        private void DeleteRow(int idx)
        {
            contentDt.Rows.RemoveAt(idx);
            grdContents.DataSource = contentDt;
        }

        /// <summary>
        /// ValidateContent : 내용 검증
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// SetContentData : 데이터를 세팅, 그리드에 입력
        /// </summary>
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

        /// <summary>
        /// RefreshContent : 텍스트박스 초기화
        /// </summary>
        private void RefreshContent()
        { 
            txtContent.Clear();
        }

        /// <summary>
        /// MakeXmlDocumentForContent : xml 정보를 만든다.
        /// </summary>
        private void MakeXmlDocumentForContent()
        {
            string fileNm = DateTime.Now.ToString("yyyyMMdd") + ".xml";
            string folderPath = appRootPath + "\\xmlContents";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            XmlDocument xml = new XmlDocument();

            StringBuilder sb = new StringBuilder();

            sb.Append("<root>");
            for (int i = 0; i < grdContents.Rows.Count; i++)
            {
                sb.Append("<item>");
                sb.Append("<idx>");
                sb.Append(i.ToString());
                sb.Append("</idx>");
                sb.Append("<content>");
                sb.Append(grdContents.Rows[i].Cells["CONTENT"].Value.ToString());
                sb.Append("</content>");
                sb.Append("<writer>");
                sb.Append(grdContents.Rows[i].Cells["WRITER"].Value.ToString());
                sb.Append("</writer>");
                sb.Append("<date>");
                sb.Append(grdContents.Rows[i].Cells["DATE"].Value.ToString());
                sb.Append("</date>");
                sb.Append("<check>");
                sb.Append((grdContents.Rows[i].Cells["CHECK"].Value.ToString()??"").Equals("True") ? "True" : "False");
                sb.Append("</check>");
                sb.Append("</item>");
            }
            sb.Append("</root>");

            xml.LoadXml(sb.ToString());
            xml.Save(folderPath + "\\" + fileNm);
        }
         
        /// <summary>
        /// SetXmlDataForContent : xml 정보를 생성한다.
        /// </summary>
        private void SetXmlDataForContent()
        {
            string fileNm = DateTime.Now.ToString("yyyyMMdd") + ".xml";
            string folderPath = appRootPath + "\\xmlContents";
            string allFilePath = Path.Combine(folderPath, fileNm);

            if (File.Exists(allFilePath))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(allFilePath);

                if (xml.DocumentElement != null)
                {
                    XmlElement root = xml.DocumentElement;
                    if (xml.SelectNodes("/root/item") != null)
                    {
                        XmlNodeList items = xml?.SelectNodes("/root/item")!;
                        int i = 0;
                        if (items != null)
                        {
                            foreach (XmlNode item in items)
                            {

                                int _idx = int.Parse(item["idx"]?.InnerText ?? i.ToString());
                                string _content = item["content"]?.InnerText ?? "없음";
                                string _writer = item["writer"]?.InnerText ?? "김상기";
                                string _date = item["date"]?.InnerText ?? DateTime.Now.ToString("yyyyMMdd");
                                bool _check = false;
                                bool.TryParse(item["check"]?.InnerText ?? "False", out _check);


                                DataRow row = contentDt.NewRow();
                                row["CONTENT"] = _content;
                                row["WRITER"] = _writer;
                                row["DATE"] = _date;
                                row["CHECK"] = _check;
                                contentDt.Rows.Add(row);

                                i++;
                            }
                            grdContents.DataSource = contentDt;
                            grdContents.ClearSelection();
                        }
                        
                    }
                }
            }

        }
    }
}
