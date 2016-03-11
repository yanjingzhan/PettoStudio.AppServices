using DataBaseLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevAccountsManager
{
    public partial class Form1 : Form
    {
        private string[] _accountInfoArray;
        public Form1()
        {
            InitializeComponent();

            this.comboBox_StoreType.SelectedIndex = 0;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            string sqlCmd = string.Empty;

            foreach (var accountInfo in _accountInfoArray)
            {
                if (accountInfo.Contains(":"))
                {
                    string a_t = accountInfo.Trim();

                    switch (this.comboBox_StoreType.Text)
                    {
                        case "360":
                            sqlCmd = string.Format("INSERT INTO [dbo].[SanLiuLingDevAccounts] ([SanLiuLingStoreDevAccount],[SanLiuLingStoreDevPassword]) VALUES ('{0}','{1}')",
                                                   a_t.Split(':')[0], a_t.Split(':')[1]);
                            break;

                        case "百度":
                            sqlCmd = string.Format("INSERT INTO [dbo].[BaiDuDevAccounts] ([BaiduStoreDevAccount],[BaiduStoreDevPassword]) VALUES ('{0}','{1}')",
                                                   a_t.Split(':')[0], a_t.Split(':')[1]);
                            break;

                        case "小米":
                            sqlCmd = string.Format("INSERT INTO [dbo].[XiaoMiDevAccounts] ([XiaomiStoreDevAccount],[XiaomiStoreDevPassword]) VALUES ('{0}','{1}')",
                                                   a_t.Split(':')[0], a_t.Split(':')[1]);
                            break;

                        default:
                            break;
                    }

                    SqlHelper.Instance.ExecuteCommand(sqlCmd);

                }
            }
            MessageBox.Show("Done");
        }

        private void button_AddTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _accountInfoArray = null;
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    _accountInfoArray = sr.ReadToEnd().Split('\n');
                }
            }
        }
    }
}
