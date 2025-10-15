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
            txtPrint = new TextBox();
            btnClick = new Button();
            SuspendLayout();
            // 
            // txtPrint
            // 
            txtPrint.Location = new Point(12, 42);
            txtPrint.Name = "txtPrint";
            txtPrint.Size = new Size(528, 27);
            txtPrint.TabIndex = 0;
            txtPrint.Text = "프린트되는곳";
            // 
            // btnClick
            // 
            btnClick.Location = new Point(546, 41);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(94, 29);
            btnClick.TabIndex = 1;
            btnClick.Text = "클릭해";
            btnClick.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClick);
            Controls.Add(txtPrint);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrint;
        private Button btnClick;
    }
}
