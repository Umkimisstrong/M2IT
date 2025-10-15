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
            panel1 = new Panel();
            btnSearch = new Button();
            rtxForeCast = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rtxForeCast);
            panel1.Location = new Point(12, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 335);
            panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(39, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(487, 47);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "날씨 조회";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // rtxForeCast
            // 
            rtxForeCast.Location = new Point(3, 3);
            rtxForeCast.Name = "rtxForeCast";
            rtxForeCast.Size = new Size(543, 313);
            rtxForeCast.TabIndex = 0;
            rtxForeCast.Text = "";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 438);
            Controls.Add(btnSearch);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSearch;
        private RichTextBox rtxForeCast;
    }
}
