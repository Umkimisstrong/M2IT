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
            btnAdd = new Button();
            txtContent = new TextBox();
            btnForeCast = new Button();
            pnlBaseBody.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdContents).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            panel3.Location = new Point(4, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(792, 377);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HighlightText;
            panel4.Controls.Add(grdContents);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(792, 377);
            panel4.TabIndex = 2;
            // 
            // grdContents
            // 
            grdContents.BackgroundColor = Color.Tan;
            grdContents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdContents.Columns.AddRange(new DataGridViewColumn[] { CONTENT, WRITER, DATE, CHECK });
            grdContents.Dock = DockStyle.Fill;
            grdContents.Location = new Point(0, 0);
            grdContents.Name = "grdContents";
            grdContents.RowHeadersVisible = false;
            grdContents.RowHeadersWidth = 51;
            grdContents.Size = new Size(792, 377);
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
            panel1.Size = new Size(792, 65);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HighlightText;
            panel2.Controls.Add(btnForeCast);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtContent);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(792, 65);
            panel2.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Sienna;
            btnAdd.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(586, 11);
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
            txtContent.Location = new Point(8, 11);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(572, 36);
            txtContent.TabIndex = 0;
            // 
            // btnForeCast
            // 
            btnForeCast.BackColor = SystemColors.HotTrack;
            btnForeCast.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnForeCast.ForeColor = SystemColors.ControlLightLight;
            btnForeCast.Location = new Point(686, 11);
            btnForeCast.Name = "btnForeCast";
            btnForeCast.Size = new Size(94, 36);
            btnForeCast.TabIndex = 2;
            btnForeCast.Text = "날씨";
            btnForeCast.UseVisualStyleBackColor = false;
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
    }
}
