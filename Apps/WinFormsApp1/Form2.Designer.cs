namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlBaseBody = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            grdContents = new DataGridView();
            KOR = new DataGridViewTextBoxColumn();
            ENG = new DataGridViewTextBoxColumn();
            KOR_SHORT = new DataGridViewTextBoxColumn();
            ENG_SHORT = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panel2 = new Panel();
            btnRefresh = new Button();
            txtSearchEngShort = new TextBox();
            txtSearchKorShort = new TextBox();
            txtSearchEng = new TextBox();
            txtSearchKor = new TextBox();
            btnSearch = new Button();
            txtEngShort = new TextBox();
            txtKorShort = new TextBox();
            txtEng = new TextBox();
            pnlTitleBar = new Panel();
            label1 = new Label();
            btnHide = new Button();
            btnClose = new Button();
            btnAdd = new Button();
            txtKor = new TextBox();
            pnlBaseBody.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdContents).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseBody
            // 
            pnlBaseBody.BackColor = Color.RosyBrown;
            pnlBaseBody.Controls.Add(panel3);
            pnlBaseBody.Controls.Add(panel1);
            pnlBaseBody.Dock = DockStyle.Fill;
            pnlBaseBody.Location = new Point(0, 0);
            pnlBaseBody.Margin = new Padding(2);
            pnlBaseBody.Name = "pnlBaseBody";
            pnlBaseBody.Padding = new Padding(3);
            pnlBaseBody.Size = new Size(621, 431);
            pnlBaseBody.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HighlightText;
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 101);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(615, 327);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HighlightText;
            panel4.Controls.Add(grdContents);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(615, 327);
            panel4.TabIndex = 2;
            // 
            // grdContents
            // 
            grdContents.AllowUserToAddRows = false;
            grdContents.BackgroundColor = Color.Tan;
            grdContents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdContents.Columns.AddRange(new DataGridViewColumn[] { KOR, ENG, KOR_SHORT, ENG_SHORT });
            grdContents.Dock = DockStyle.Fill;
            grdContents.Location = new Point(0, 0);
            grdContents.Margin = new Padding(2);
            grdContents.Name = "grdContents";
            grdContents.RowHeadersVisible = false;
            grdContents.RowHeadersWidth = 51;
            grdContents.Size = new Size(615, 327);
            grdContents.TabIndex = 0;
            // 
            // KOR
            // 
            KOR.DataPropertyName = "KOR";
            KOR.HeaderText = "한글";
            KOR.MinimumWidth = 6;
            KOR.Name = "KOR";
            KOR.Width = 150;
            // 
            // ENG
            // 
            ENG.DataPropertyName = "ENG";
            ENG.HeaderText = "영문";
            ENG.MinimumWidth = 6;
            ENG.Name = "ENG";
            ENG.Width = 150;
            // 
            // KOR_SHORT
            // 
            KOR_SHORT.DataPropertyName = "KOR_SHORT";
            KOR_SHORT.HeaderText = "한글약어";
            KOR_SHORT.MinimumWidth = 6;
            KOR_SHORT.Name = "KOR_SHORT";
            KOR_SHORT.Width = 150;
            // 
            // ENG_SHORT
            // 
            ENG_SHORT.DataPropertyName = "ENG_SHORT";
            ENG_SHORT.HeaderText = "영문약어";
            ENG_SHORT.MinimumWidth = 6;
            ENG_SHORT.Name = "ENG_SHORT";
            ENG_SHORT.Resizable = DataGridViewTriState.True;
            ENG_SHORT.Width = 150;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HighlightText;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 98);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HighlightText;
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(txtSearchEngShort);
            panel2.Controls.Add(txtSearchKorShort);
            panel2.Controls.Add(txtSearchEng);
            panel2.Controls.Add(txtSearchKor);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtEngShort);
            panel2.Controls.Add(txtKorShort);
            panel2.Controls.Add(txtEng);
            panel2.Controls.Add(pnlTitleBar);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtKor);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(615, 98);
            panel2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = SystemColors.ControlLightLight;
            btnRefresh.Location = new Point(238, 47);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(63, 27);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Clear";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // txtSearchEngShort
            // 
            txtSearchEngShort.BackColor = Color.PeachPuff;
            txtSearchEngShort.BorderStyle = BorderStyle.FixedSingle;
            txtSearchEngShort.Font = new Font("맑은 고딕", 13F);
            txtSearchEngShort.Location = new Point(420, 26);
            txtSearchEngShort.Margin = new Padding(2);
            txtSearchEngShort.Name = "txtSearchEngShort";
            txtSearchEngShort.Size = new Size(110, 31);
            txtSearchEngShort.TabIndex = 8;
            // 
            // txtSearchKorShort
            // 
            txtSearchKorShort.BackColor = Color.PeachPuff;
            txtSearchKorShort.BorderStyle = BorderStyle.FixedSingle;
            txtSearchKorShort.Font = new Font("맑은 고딕", 13F);
            txtSearchKorShort.Location = new Point(307, 26);
            txtSearchKorShort.Margin = new Padding(2);
            txtSearchKorShort.Name = "txtSearchKorShort";
            txtSearchKorShort.Size = new Size(110, 31);
            txtSearchKorShort.TabIndex = 7;
            // 
            // txtSearchEng
            // 
            txtSearchEng.BackColor = Color.PeachPuff;
            txtSearchEng.BorderStyle = BorderStyle.FixedSingle;
            txtSearchEng.Font = new Font("맑은 고딕", 13F);
            txtSearchEng.Location = new Point(120, 26);
            txtSearchEng.Margin = new Padding(2);
            txtSearchEng.Name = "txtSearchEng";
            txtSearchEng.Size = new Size(110, 31);
            txtSearchEng.TabIndex = 6;
            // 
            // txtSearchKor
            // 
            txtSearchKor.BackColor = Color.PeachPuff;
            txtSearchKor.BorderStyle = BorderStyle.FixedSingle;
            txtSearchKor.Font = new Font("맑은 고딕", 13F);
            txtSearchKor.Location = new Point(6, 26);
            txtSearchKor.Margin = new Padding(2);
            txtSearchKor.Name = "txtSearchKor";
            txtSearchKor.Size = new Size(110, 31);
            txtSearchKor.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkOrange;
            btnSearch.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnSearch.ForeColor = SystemColors.ControlLightLight;
            btnSearch.Location = new Point(534, 29);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(73, 27);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtEngShort
            // 
            txtEngShort.BackColor = Color.PeachPuff;
            txtEngShort.BorderStyle = BorderStyle.FixedSingle;
            txtEngShort.Font = new Font("맑은 고딕", 13F);
            txtEngShort.Location = new Point(420, 62);
            txtEngShort.Margin = new Padding(2);
            txtEngShort.Name = "txtEngShort";
            txtEngShort.Size = new Size(110, 31);
            txtEngShort.TabIndex = 3;
            // 
            // txtKorShort
            // 
            txtKorShort.BackColor = Color.PeachPuff;
            txtKorShort.BorderStyle = BorderStyle.FixedSingle;
            txtKorShort.Font = new Font("맑은 고딕", 13F);
            txtKorShort.Location = new Point(307, 62);
            txtKorShort.Margin = new Padding(2);
            txtKorShort.Name = "txtKorShort";
            txtKorShort.Size = new Size(110, 31);
            txtKorShort.TabIndex = 2;
            // 
            // txtEng
            // 
            txtEng.BackColor = Color.PeachPuff;
            txtEng.BorderStyle = BorderStyle.FixedSingle;
            txtEng.Font = new Font("맑은 고딕", 13F);
            txtEng.Location = new Point(120, 62);
            txtEng.Margin = new Padding(2);
            txtEng.Name = "txtEng";
            txtEng.Size = new Size(110, 31);
            txtEng.TabIndex = 1;
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.NavajoWhite;
            pnlTitleBar.Controls.Add(label1);
            pnlTitleBar.Controls.Add(btnHide);
            pnlTitleBar.Controls.Add(btnClose);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Margin = new Padding(2);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Size = new Size(615, 20);
            pnlTitleBar.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 2);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 6;
            label1.Text = "> 용어사전";
            // 
            // btnHide
            // 
            btnHide.BackColor = Color.Salmon;
            btnHide.Font = new Font("맑은 고딕", 7F, FontStyle.Bold);
            btnHide.ForeColor = SystemColors.ControlLightLight;
            btnHide.Location = new Point(572, -1);
            btnHide.Margin = new Padding(2);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(22, 21);
            btnHide.TabIndex = 99;
            btnHide.TabStop = false;
            btnHide.Text = "ㅡ";
            btnHide.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Salmon;
            btnClose.Font = new Font("맑은 고딕", 7F, FontStyle.Bold);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(593, -1);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(22, 21);
            btnClose.TabIndex = 98;
            btnClose.TabStop = false;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Sienna;
            btnAdd.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(534, 62);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(73, 27);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "추가";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtKor
            // 
            txtKor.BackColor = Color.PeachPuff;
            txtKor.BorderStyle = BorderStyle.FixedSingle;
            txtKor.Font = new Font("맑은 고딕", 13F);
            txtKor.Location = new Point(6, 62);
            txtKor.Margin = new Padding(2);
            txtKor.Name = "txtKor";
            txtKor.Size = new Size(110, 31);
            txtKor.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 431);
            Controls.Add(pnlBaseBody);
            Margin = new Padding(2);
            Name = "Form2";
            Text = "Form2";
            pnlBaseBody.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdContents).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBaseBody;
        private Panel panel3;
        private Panel panel4;
        private DataGridView grdContents;
        private Panel panel1;
        private Panel panel2;
        private Panel pnlTitleBar;
        private Button btnHide;
        private Button btnClose;
        private Button btnAdd;
        private TextBox txtKor;
        private DataGridViewTextBoxColumn KOR;
        private DataGridViewTextBoxColumn ENG;
        private DataGridViewTextBoxColumn KOR_SHORT;
        private DataGridViewTextBoxColumn ENG_SHORT;
        private TextBox txtEngShort;
        private TextBox txtKorShort;
        private TextBox txtEng;
        private TextBox txtSearchEngShort;
        private TextBox txtSearchKorShort;
        private TextBox txtSearchEng;
        private TextBox txtSearchKor;
        private Button btnSearch;
        private Button btnRefresh;
        private Label label1;
    }
}
