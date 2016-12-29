using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Utility;

namespace Controller
{
    public class VerifyEmailControl
    {
        public string AddEmail(string account, string password)
        {
            try
            {
                string result = string.Empty;
                string[] ss = account.Split('@');

                CmdHelper.ExecWithArgs(@"C:\hMailServerScripts\AddAccounts\CreateAccount.vbs", string.Format("User {0} {1} {2}", ss[0], password, ss[1]));

                Thread.Sleep(500);

                string resultFile = Path.Combine(@"C:\hMailServerScripts\AddAccounts\ResultFiles", account + ".txt");
                if (File.Exists(resultFile))
                {
                    if (File.ReadAllText(resultFile).Contains("1"))
                    {
                        result = "200:ok";
                    }
                    else
                    {
                        result = "-100:error create";
                    }

                    try
                    {
                        File.Delete(resultFile);
                    }
                    catch { }
                }
                else
                {
                    result = "-101:no result file";
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string GetShortSecurityCode(string account, string passowrd)
        {
            try
            {
                string result = string.Empty;
                string[] ss = account.Split('@');
                string popAdd = "pop3." + ss[1];

                //本机
                popAdd = "127.0.0.1";

                MailHelper mail = new MailHelper(popAdd, account, passowrd);

                List<MailModel> mailList = mail.GetMailList();
                mailList.Reverse();

                foreach (var item in mailList)
                {
                    DateTime sendTime = item.SendTime.AddHours(8);
                    if (Math.Abs(DateTime.Now.Subtract(sendTime).TotalMinutes) < 120)
                    {
                        if (item.Body.Contains("如果你没有请求此代码") || item.Body.Contains("If you didn't request this code"))
                        {
                            string[] sShit = item.Body.Split('\n');

                            foreach (var s in sShit)
                            {
                                if (s.Contains("安全代码:") || s.Contains("Security code:"))
                                {
                                    string[] ssShit = s.Trim().Split(':');
                                    result = ssShit[1].Trim();
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetLongSecurityCode(string account, string passowrd)
        {
            try
            {
                string result = string.Empty;
                string[] ss = account.Split('@');
                string popAdd = "pop3." + ss[1];

                //本机
                popAdd = "127.0.0.1";

                MailHelper mail = new MailHelper(popAdd, account, passowrd);

                List<MailModel> mailList = mail.GetMailList();
                mailList.Reverse();

                foreach (var item in mailList)
                {
                    DateTime sendTime = item.SendTime.AddHours(8);
                    if (Math.Abs(DateTime.Now.Subtract(sendTime).TotalMinutes) < 120)
                    {
                        if (item.Body.Contains("如果你无法识别 Microsoft 帐户") || item.Body.Contains("If you don't recognize the Microsoft account"))
                        {
                            string[] sShit = item.Body.Split('\n');

                            foreach (var s in sShit)
                            {
                                if (s.Contains("安全代码:") || s.Contains("Security code:"))
                                {
                                    string[] ssShit = s.Trim().Split(':');
                                    result = ssShit[1].Trim();
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
