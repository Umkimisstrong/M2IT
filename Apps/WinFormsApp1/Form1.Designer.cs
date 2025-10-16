namespace WinFormsApp1
{
    partial class Form1
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
            CONTENT = new DataGridViewTextBoxColumn();
            WRITER = new DataGridViewTextBoxColumn();
            DATE = new DataGridViewTextBoxColumn();
            CHECK = new DataGridViewCheckBoxColumn();
            panel1 = new Panel();
            panel2 = new Panel();
            btnForeCast = new Button();
            btnAdd = new Button();
            txtContent = new TextBox();
            panel5 = new Panel();
            btnClose = new Button();
            btnHide = new Button();
            pnlBaseBody.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdContents).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseBody
            // 
            pnlBaseBody.BackColor = Color.RosyBrown;
            pnlBaseBody.Controls.Add(panel3);
            pnlBaseBody.Controls.Add(panel1);
            pnlBaseBody.Dock = DockStyle.Fill;
            pnlBaseBody.Location = new Point(0, 0);
            pnlBaseBody.Name = "pnlBaseBody";
            pnlBaseBody.Padding = new Padding(4);
            pnlBaseBody.Size = new Size(800, 450);
            pnlBaseBody.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HighlightText;
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(4, 94);
            panel3.Name = "panel3";
            panel3.Size = new Size(792, 352);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HighlightText;
            panel4.Controls.Add(grdContents);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(792, 352);
            panel4.TabIndex = 2;
            // 
            // grdContents
            // 
            grdContents.AllowUserToAddRows = false;
            grdContents.BackgroundColor = Color.Tan;
            grdContents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdContents.Columns.AddRange(new DataGridViewColumn[] { CONTENT, WRITER, DATE, CHECK });
            grdContents.Dock = DockStyle.Fill;
            grdContents.Location = new Point(0, 0);
            grdContents.Name = "grdContents";
            grdContents.RowHeadersVisible = false;
            grdContents.RowHeadersWidth = 51;
            grdContents.Size = new Size(792, 352);
            grdContents.TabIndex = 0;
            // 
            // CONTENT
            // 
            CONTENT.DataPropertyName = "CONTENT";
            CONTENT.HeaderText = "내용";
            CONTENT.MinimumWidth = 6;
            CONTENT.Name = "CONTENT";
            CONTENT.Width = 420;
            // 
            // WRITER
            // 
            WRITER.DataPropertyName = "WRITER";
            WRITER.HeaderText = "작성자";
            WRITER.MinimumWidth = 6;
            WRITER.Name = "WRITER";
            WRITER.Width = 125;
            // 
            // DATE
            // 
            DATE.DataPropertyName = "DATE";
            DATE.HeaderText = "작성일";
            DATE.MinimumWidth = 6;
            DATE.Name = "DATE";
            DATE.Width = 125;
            // 
            // CHECK
            // 
            CHECK.DataPropertyName = "CHECK";
            CHECK.HeaderText = "체크";
            CHECK.MinimumWidth = 6;
            CHECK.Name = "CHECK";
            CHECK.Resizable = DataGridViewTriState.True;
            CHECK.SortMode = DataGridViewColumnSortMode.Automatic;
            CHECK.Width = 125;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HighlightText;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(792, 90);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HighlightText;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(btnForeCast);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtContent);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(792, 90);
            panel2.TabIndex = 2;
            // 
            // btnForeCast
            // 
            btnForeCast.BackColor = SystemColors.HotTrack;
            btnForeCast.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnForeCast.ForeColor = SystemColors.ControlLightLight;
            btnForeCast.Location = new Point(686, 39);
            btnForeCast.Name = "btnForeCast";
            btnForeCast.Size = new Size(94, 36);
            btnForeCast.TabIndex = 2;
            btnForeCast.Text = "날씨";
            btnForeCast.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Sienna;
            btnAdd.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(586, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "추가";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtContent
            // 
            txtContent.BackColor = Color.PeachPuff;
            txtContent.BorderStyle = BorderStyle.FixedSingle;
            txtContent.Font = new Font("맑은 고딕", 13F);
            txtContent.Location = new Point(8, 39);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(572, 36);
            txtContent.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.NavajoWhite;
            panel5.Controls.Add(btnHide);
            panel5.Controls.Add(btnClose);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(792, 26);
            panel5.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Salmon;
            btnClose.Font = new Font("맑은 고딕", 7F, FontStyle.Bold);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(763, -1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(28, 28);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnHide
            // 
            btnHide.BackColor = Color.Salmon;
            btnHide.Font = new Font("맑은 고딕", 7F, FontStyle.Bold);
            btnHide.ForeColor = SystemColors.ControlLightLight;
            btnHide.Location = new Point(738, -1);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(28, 28);
            btnHide.TabIndex = 4;
            btnHide.Text = "ㅡ";
            btnHide.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBaseBody);
            Name = "Form1";
            Text = "CheckList";
            pnlBaseBody.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdContents).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBaseBody;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Button btnAdd;
        private TextBox txtContent;
        private DataGridView grdContents;
        private DataGridViewTextBoxColumn CONTENT;
        private DataGridViewTextBoxColumn WRITER;
        private DataGridViewTextBoxColumn DATE;
        private DataGridViewCheckBoxColumn CHECK;
        private Button btnForeCast;
        private Panel panel5;
        private Button btnClose;
        private Button btnHide;
    }
}
