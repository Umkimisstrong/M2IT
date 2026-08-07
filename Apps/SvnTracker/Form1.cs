using SharpSvn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SvnTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.btnRetrieve.Click += Button1_Click;
            this.btnAuto.Click += BtnAuto_Click;
            this.chkAuto.CheckedChanged += ChkAuto_CheckedChanged;
            this.svnTimer.Tick += SvnTimer_Tick;
        }

        private void SvnTimer_Tick(object sender, EventArgs e)
        {
            var list = RetrieveStatus();


            if (list.Count > 0)
            {
                ShowNotification(list);
            }
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMin.Text) && !this.txtMin.Text.Equals("0"))
            {
                this.svnTimer.Interval = 1000 * int.Parse(this.txtMin.Text);
            }
        }

        private void ChkAuto_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTimer(this.chkAuto.Checked);
        }

        private void ToggleTimer(bool isChecked)
        {
            if (!string.IsNullOrEmpty(this.txtMin.Text) && !this.txtMin.Text.Equals("0") && isChecked)
            {
                this.svnTimer.Interval = 1000 * int.Parse(this.txtMin.Text);
                this.svnTimer.Enabled = isChecked;
                this.svnTimer.Start();
                this.Hide();
            }
            else
            {
                this.svnTimer.Enabled = isChecked;
                this.svnTimer.Stop();

                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RetrieveStatus();
        }

        private void ShowNotification(List<SvnChangedItem> list)
        {
            this.Show();

            MessageBox.Show(
                $"변경사항이 있습니다.\n\n" +
                $"파일 수 : {list.Count}",
                "SVN Tracker",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //private bool HasUpdate(string workingCopyPath)
        //{
        //    using (SvnClient client = new SvnClient())
        //    {
        //        Collection<SvnStatusEventArgs> statuses;

        //        SvnStatusArgs args = new SvnStatusArgs()
        //        {
        //            RetrieveRemoteStatus = true
        //        };

        //        if (!client.GetStatus(workingCopyPath, args, out statuses))
        //            return false;

        //        foreach (var status in statuses)
        //        {
        //            if (status.RemoteNodeStatus != SvnStatus.None)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }


        //}

        private List<SvnChangedItem> RetrieveStatus()
        {
            string path = this.txtPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                path = @"C:\HAMIS_Projects\client\HAMIS.Projects\HM";
                this.txtPath.Text = path;
            }

            this.lblRetrieveTime.Text =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            List<SvnChangedItem> result = GetChangedItems(path);


            this.grdSvn.DataSource = result;


            return result;
        }

        /*
         hamis01	고관영
         hamis02	마봉기
         hamis03	이성태
         hamis04	김평화
         hamis05	이진화
         hamis06	김상기
         hamis07	정주영
         hamis08	김동준
         hamis09	정승우
         hamis10	홍수연
         hamis11	외래팀01
         */
        
        private List<SvnChangedItem> GetChangedItems(string path)
        {
            Dictionary<string, string> userMap = new Dictionary<string, string>();
            userMap.Add("hamis01", "고관영");
            userMap.Add("hamis02", "마봉기");
            userMap.Add("hamis03", "이성태");
            userMap.Add("hamis04", "김평화");
            userMap.Add("hamis05", "이진화");
            userMap.Add("hamis06", "김상기");
            userMap.Add("hamis07", "정주영");
            userMap.Add("hamis08", "김동준");
            userMap.Add("hamis09", "정승우");
            userMap.Add("hamis10", "홍수연");
            userMap.Add("hamis11", "외래팀01");
            List<SvnChangedItem> list = new List<SvnChangedItem>();

            using (SvnClient client = new SvnClient())
            {
                Collection<SvnStatusEventArgs> statuses;


                SvnStatusArgs args = new SvnStatusArgs()
                {
                    RetrieveRemoteStatus = true
                };


                client.GetStatus(path, args, out statuses);


                foreach (var status in statuses)
                {
                    if (status.RemoteNodeStatus != SvnStatus.None)
                    {
                        DateTime localTime = status.RemoteUpdateCommitTime.ToLocalTime();
                        string userNm = userMap.ContainsKey(status.RemoteUpdateCommitAuthor) ? userMap[status.RemoteUpdateCommitAuthor].ToString() : status.RemoteUpdateCommitAuthor;
                        list.Add(new SvnChangedItem()
                        {
                            path = Path.GetDirectoryName(status.Path),
                            fileName = Path.GetFileName(status.Path),
                            status = status.RemoteNodeStatus.ToString(),
                            modifyNm = userNm,
                            modifyTime = localTime
                        });
                    }
                }
            }

            return list;
        }
    }
}
