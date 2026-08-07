namespace SvnTracker
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRetrieveTime = new System.Windows.Forms.Label();
            this.grdSvn = new System.Windows.Forms.DataGridView();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.svnTimer = new System.Windows.Forms.Timer(this.components);
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifyNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSvn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(12, 12);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 0;
            this.btnRetrieve.Text = "조회";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(146, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(345, 21);
            this.txtPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "경로";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "마지막조회";
            // 
            // lblRetrieveTime
            // 
            this.lblRetrieveTime.AutoSize = true;
            this.lblRetrieveTime.Location = new System.Drawing.Point(649, 21);
            this.lblRetrieveTime.Name = "lblRetrieveTime";
            this.lblRetrieveTime.Size = new System.Drawing.Size(53, 12);
            this.lblRetrieveTime.TabIndex = 5;
            this.lblRetrieveTime.Text = "조회시간";
            // 
            // grdSvn
            // 
            this.grdSvn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSvn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.path,
            this.fileName,
            this.status,
            this.modifyNm,
            this.modifyTime});
            this.grdSvn.Location = new System.Drawing.Point(12, 53);
            this.grdSvn.Name = "grdSvn";
            this.grdSvn.RowTemplate.Height = 23;
            this.grdSvn.Size = new System.Drawing.Size(1032, 448);
            this.grdSvn.TabIndex = 6;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(889, 511);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(72, 16);
            this.chkAuto.TabIndex = 7;
            this.chkAuto.Text = "자동조회";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(808, 509);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(49, 21);
            this.txtMin.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(863, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "분";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(967, 507);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 10;
            this.btnAuto.Text = "적용";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // path
            // 
            this.path.DataPropertyName = "path";
            this.path.HeaderText = "경로";
            this.path.Name = "path";
            this.path.Width = 440;
            // 
            // fileName
            // 
            this.fileName.DataPropertyName = "fileName";
            this.fileName.HeaderText = "파일명";
            this.fileName.Name = "fileName";
            this.fileName.Width = 150;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "상태";
            this.status.Name = "status";
            // 
            // modifyNm
            // 
            this.modifyNm.DataPropertyName = "modifyNm";
            this.modifyNm.HeaderText = "수정자";
            this.modifyNm.Name = "modifyNm";
            // 
            // modifyTime
            // 
            this.modifyTime.DataPropertyName = "modifyTime";
            this.modifyTime.HeaderText = "변경시간";
            this.modifyTime.Name = "modifyTime";
            this.modifyTime.Width = 130;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 542);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.grdSvn);
            this.Controls.Add(this.lblRetrieveTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRetrieve);
            this.Name = "Form1";
            this.Text = "SvnTracker";
            ((System.ComponentModel.ISupportInitialize)(this.grdSvn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRetrieveTime;
        private System.Windows.Forms.DataGridView grdSvn;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Timer svnTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifyNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifyTime;
    }
}

