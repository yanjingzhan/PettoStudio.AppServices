using DataBaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class HelperControl
    {
        public void AddIPCounts(string VPNAccount, string VPNPassword, string source, string IP)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [dbo].[IPCounts] WHERE [VPNAccount] = '{0}' AND [VPNPassword] = '{1}' AND [Source] = '{2}' AND [IP] = '{3}'",
                    VPNAccount, VPNPassword, source, IP);

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t == null || t.ToString() == "0")
                {
                    sqlCmd = string.Format("INSERT INTO [dbo].[IPCounts] ([VPNAccount],[VPNPassword],[Source],[IP],[Count],[AdddateTime],[UpdateTime]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                                   VPNAccount, VPNPassword, source, IP, "1", DateTime.Now.ToString(), DateTime.Now.ToString());
                }
                else
                {
                    sqlCmd = string.Format("UPDATE [dbo].[IPCounts] SET [Count] = [Count] + 1  WHERE [VPNAccount] = '{0}' AND [VPNPassword] = '{1}' AND [Source] = '{2}' AND [IP] = '{3}'",
                        VPNAccount, VPNPassword, source, IP);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch
            {
                throw;
            }
        }
    }
}
