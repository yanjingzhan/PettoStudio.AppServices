using DataBaseLib;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class IOSIAPServicesControl
    {
        public void InsertIAPRecord(AppleIAPRecord appleIAPRecord)
        {
            try
            {
                string sqlCmd = string.Format("SELECT COUNT(*) FROM [AppleIAPUser] WHERE [Account] = '{0}' AND [Password] = '{1}' AND State = '{2}'", appleIAPRecord.Account, appleIAPRecord.Password, "normal");

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t == null || t.ToString() == "0")
                {
                    throw new Exception("身份验证失败！");
                }


                sqlCmd = string.Format("SELECT COUNT(*) FROM [AppleIAPRecord] WHERE [Guid] = '{0}'", appleIAPRecord.GUID);

                t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                if (t != null && t.ToString() != "0")
                {
                    throw new Exception("已存在该数据");
                }


                sqlCmd = string.Format("INSERT INTO [dbo].[AppleIAPRecord] ([Account],[Password],[GameName],[Score],[GUID],[State],[AddTime],[UpdateTime]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                                    appleIAPRecord.Account, appleIAPRecord.Password, appleIAPRecord.GameName, appleIAPRecord.Score, appleIAPRecord.GUID, "normal", DateTime.Now.ToString(), DateTime.Now.ToString());
                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch
            {
                throw;
            }
        }
    }
}
