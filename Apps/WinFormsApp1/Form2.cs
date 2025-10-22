using System.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// contentDt : 전역 DataTable 변수
        /// </summary>
        private DataTable contentDt;
        private string appRootPath;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Form2 : Dictionary Form 
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            initEvent();
        }

        /// <summary>
        /// Form2_Load : 폼 로드 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object? sender, EventArgs e)
        {
            initVariables();
            initDesign();
            SetXmlDataForContent();
        }



        /// <summary>
        /// Form2_FormClosing : 폼을 닫을 때 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object? sender, FormClosingEventArgs e)
        {
            MakeXmlDocumentForContent();
        }

        /// <summary>
        /// initEvent : Event 를 초기화
        /// </summary>
        private void initEvent()
        {
            this.Load += Form2_Load;
            this.txtKor.KeyDown += TxtKor_KeyDown;
            this.txtEng.KeyDown += TxtEng_KeyDown;
            this.txtKorShort.KeyDown += TxtKorShort_KeyDown;
            this.txtEngShort.KeyDown += TxtEngShort_KeyDown;

            this.txtSearchKor.KeyDown += TxtSearchKor_KeyDown;
            this.txtSearchEng.KeyDown += TxtSearchEng_KeyDown;
            this.txtSearchKorShort.KeyDown += TxtSearchKorShort_KeyDown;
            this.txtSearchEngShort.KeyDown += TxtSearchEngShort_KeyDown;

            this.btnAdd.Click += BtnAdd_Click;
            this.grdContents.MouseDown += GrdContents_MouseDown;
            this.btnClose.Click += BtnClose_Click;
            this.btnHide.Click += BtnHide_Click;
            this.FormClosing += Form2_FormClosing;
            this.pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            this.btnSearch.Click += BtnSearch_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        /// <summary>
        /// BtnRefresh_Click : Clear 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            RefreshContentAll();
        }

        /// <summary>
        /// BtnSearch_Click : 검색 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            if ((   !string.IsNullOrEmpty(txtSearchKor.Text)
                || !string.IsNullOrEmpty(txtSearchEng.Text)
                || !string.IsNullOrEmpty(txtSearchKorShort.Text)
                || !string.IsNullOrEmpty(txtSearchEngShort.Text)
                )
                &&
                grdContents.Rows.Count>0
                )
            {
                SearchWords();
            }
        }

        /// <summary>
        /// SearchWords : 단어조회
        /// </summary>
        private void SearchWords()
        {
            grdContents.ClearSelection();
            string searchKorWords = txtSearchKor.Text.Trim();
            string searchEngWords = txtSearchEng.Text.Trim();
            string searchKorShortWords = txtSearchKorShort.Text.Trim();
            string searchEngShortWords = txtSearchEngShort.Text.Trim();

            int searchWordsCount = 0;
            if (searchKorWords.Length > 0)
                searchWordsCount++;
            if (searchEngWords.Length > 0)
                searchWordsCount++;
            if (searchKorShortWords.Length > 0)
                searchWordsCount++;
            if (searchEngShortWords.Length > 0)
                searchWordsCount++;

            for (int i = 0; i < grdContents.Rows.Count; i++)
            {
                int matchedWordsCount = 0;
                for (int j = 0; j < grdContents.Rows[i].Cells.Count; j++)
                {
                    if (j == 0 && searchKorWords.Length > 0)
                    {
                        if (grdContents.Rows[i].Cells[j].Value != null)
                        {
                            if (grdContents.Rows[i].Cells[j].Value.ToString().Contains(searchKorWords))
                            {
                                matchedWordsCount++;
                            }

                        }
                    }

                    if (j == 1 && searchEngWords.Length > 0)
                    {
                        if (grdContents.Rows[i].Cells[j].Value != null)
                        {
                            if (grdContents.Rows[i].Cells[j].Value.ToString().Contains(searchEngWords))
                            {
                                matchedWordsCount++;
                            }

                        }
                    }

                    if (j == 2 && searchKorShortWords.Length > 0)
                    {
                        if (grdContents.Rows[i].Cells[j].Value != null)
                        {
                            if (grdContents.Rows[i].Cells[j].Value.ToString().Contains(searchKorShortWords))
                            {
                                matchedWordsCount++;
                            }

                        }
                    }

                    if (j == 3 && searchEngShortWords.Length > 0)
                    {
                        if (grdContents.Rows[i].Cells[j].Value != null)
                        {
                            if (grdContents.Rows[i].Cells[j].Value.ToString().Contains(searchEngShortWords))
                            {
                                matchedWordsCount++;
                            }

                        }
                    }
                }

                if (searchWordsCount > 0 && searchWordsCount == matchedWordsCount)
                {
                    grdContents.Rows[i].Selected = true;
                    break;
                }

            }
        
        }

        /// <summary>
        /// PnlTitleBar_MouseDown : 타이틀 바 마우스다운
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
            contentDt.Columns.Add(new DataColumn("KOR"));
            contentDt.Columns.Add(new DataColumn("ENG"));
            contentDt.Columns.Add(new DataColumn("KOR_SHORT"));
            contentDt.Columns.Add(new DataColumn("ENG_SHORT"));

            appRootPath = "C:\\Users\\KIMSANGKI\\Desktop\\KSK\\998. SOURCE\\M2IT";
            //appRootPath = Application.StartupPath;
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
                    grdContents.CurrentCell = grdContents.Rows[hitTestInfo.RowIndex].Cells["KOR"];

                    contextMenuStrip.Items.Add(grdContents.Rows[hitTestInfo.RowIndex].Cells["KOR"].Value.ToString() + " 삭제", null, (s, ev) => DeleteRow(hitTestInfo.RowIndex));
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
        /// TxtKor_KeyDown : 텍스트 박스 키다운 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtKor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddContent();
            }
        }

        /// <summary>
        /// TxtEngShort_KeyDown : 영문약어 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEngShort_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddContent();
            }
        }

        /// <summary>
        /// TxtKorShort_KeyDown : 한글약어 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtKorShort_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddContent();
            }
        }

        /// <summary>
        /// TxtEng_KeyDown : 영문 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEng_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddContent();
            }
        }

        /// <summary>
        /// TxtSearchEngShort_KeyDown : 영문약어 검색 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearchEngShort_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((!string.IsNullOrEmpty(txtSearchKor.Text)
                || !string.IsNullOrEmpty(txtSearchEng.Text)
                || !string.IsNullOrEmpty(txtSearchKorShort.Text)
                || !string.IsNullOrEmpty(txtSearchEngShort.Text)
                )
                &&
                grdContents.Rows.Count > 0
                )
                {
                    SearchWords();
                }
            }
        }

        /// <summary>
        /// TxtSearchKorShort_KeyDown : 한글약어 검색 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearchKorShort_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((!string.IsNullOrEmpty(txtSearchKor.Text)
                || !string.IsNullOrEmpty(txtSearchEng.Text)
                || !string.IsNullOrEmpty(txtSearchKorShort.Text)
                || !string.IsNullOrEmpty(txtSearchEngShort.Text)
                )
                &&
                grdContents.Rows.Count > 0
                )
                {
                    SearchWords();
                }
            }
        }

        /// <summary>
        /// TxtSearchEng_KeyDown : 영문검색 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearchEng_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((!string.IsNullOrEmpty(txtSearchKor.Text)
                || !string.IsNullOrEmpty(txtSearchEng.Text)
                || !string.IsNullOrEmpty(txtSearchKorShort.Text)
                || !string.IsNullOrEmpty(txtSearchEngShort.Text)
                )
                &&
                grdContents.Rows.Count > 0
                )
                {
                    SearchWords();
                }
            }
        }

        /// <summary>
        /// TxtSearchKor_KeyDown : 한글 검색 키다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearchKor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((!string.IsNullOrEmpty(txtSearchKor.Text)
                || !string.IsNullOrEmpty(txtSearchEng.Text)
                || !string.IsNullOrEmpty(txtSearchKorShort.Text)
                || !string.IsNullOrEmpty(txtSearchEngShort.Text)
                )
                &&
                grdContents.Rows.Count > 0
                )
                {
                    SearchWords();
                }
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
            if (string.IsNullOrWhiteSpace(txtKor.Text))
            {
                MessageBox.Show("한글명을 작성해주세요.", "주의");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEng.Text))
            {
                MessageBox.Show("영문명을 작성해주세요.", "주의");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKorShort.Text))
            {
                MessageBox.Show("한글약어명을 작성해주세요.", "주의");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEngShort.Text))
            {
                MessageBox.Show("영문약어명을 작성해주세요.", "주의");
                return false;
            }

            return true;

        }

        /// <summary>
        /// SetContentData : 데이터를 세팅, 그리드에 입력
        /// </summary>
        private void SetContentData()
        {
            //grdContents.DataSource = null;

            DataRow row = contentDt.NewRow();
            row["KOR"] = txtKor.Text;
            row["ENG"] = txtEng.Text;
            row["KOR_SHORT"] = txtKorShort.Text;
            row["ENG_SHORT"] = txtEngShort.Text;
            contentDt.Rows.Add(row);

            DataView dv = contentDt.AsDataView();
            dv.Sort = "KOR ASC";
            contentDt = dv.ToTable();
            grdContents.DataSource = contentDt;

        }

        /// <summary>
        /// RefreshContent : 텍스트박스 초기화
        /// </summary>
        private void RefreshContent()
        {
            txtKor.Clear();
            txtEng.Clear();
            txtKorShort.Clear();
            txtEngShort.Clear();
        }

        /// <summary>
        /// RefreshContent : 전체 텍스트박스 초기화
        /// </summary>
        private void RefreshContentAll()
        {
            txtKor.Clear();
            txtEng.Clear();
            txtKorShort.Clear();
            txtEngShort.Clear();

            txtSearchKor.Clear();
            txtSearchEng.Clear();
            txtSearchKorShort.Clear();
            txtSearchEngShort.Clear();

            grdContents.ClearSelection();
        }

        /// <summary>
        /// MakeXmlDocumentForContent : xml 정보를 만든다.
        /// </summary>
        private void MakeXmlDocumentForContent()
        {
            string fileNm = "wordsDictionary" + ".xml";
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
                sb.Append("<kor>");
                sb.Append(grdContents.Rows[i].Cells["KOR"].Value.ToString());
                sb.Append("</kor>");
                sb.Append("<eng>");
                sb.Append(grdContents.Rows[i].Cells["ENG"].Value.ToString());
                sb.Append("</eng>");
                sb.Append("<kor_short>");
                sb.Append(grdContents.Rows[i].Cells["KOR_SHORT"].Value.ToString());
                sb.Append("</kor_short>");
                sb.Append("<eng_short>");
                sb.Append(grdContents.Rows[i].Cells["ENG_SHORT"].Value.ToString());
                sb.Append("</eng_short>");
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
            string fileNm = "wordsDictionary" + ".xml";
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
                                string _kor = item["kor"]?.InnerText ?? "없음";
                                string _eng = item["eng"]?.InnerText ?? "NONE";
                                string _kor_short = item["kor_short"]?.InnerText ?? "없음";
                                string _eng_short = item["eng_short"]?.InnerText ?? "NONE";

                                DataRow row = contentDt.NewRow();
                                row["KOR"] = _kor;
                                row["ENG"] = _eng;
                                row["KOR_SHORT"] = _kor_short;
                                row["ENG_sHORT"] = _eng_short;
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
