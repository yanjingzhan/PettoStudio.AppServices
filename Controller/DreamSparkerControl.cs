using DataBaseLib;
using Models;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Controller
{
    public class DreamSparkerControl
    {
        public List<DreamSparkerModel> GetDreamSparkerListByCount(DreamSparkerModel model, int count)
        {
            try
            {
                string id = string.IsNullOrEmpty(model.ID) ? "[ID]" : "'" + model.ID + "'";
                string account = string.IsNullOrEmpty(model.Account) ? "[Account]" : "'" + model.Account + "'";
                string password = string.IsNullOrEmpty(model.Password) ? "[Password]" : "'" + model.Password + "'";
                string newPassword = string.IsNullOrEmpty(model.NewPassword) ? "[NewPassword]" : "'" + model.NewPassword + "'";
                string state = string.IsNullOrEmpty(model.State) ? "[State]" : "'" + model.State + "'";
                string devAccount = string.IsNullOrEmpty(model.DevAccount) ? "[DevAccount]" : "'" + model.DevAccount + "'";
                string devPassword = string.IsNullOrEmpty(model.DevPassword) ? "[DevPassword]" : "'" + model.DevPassword + "'";
                string sourceType = string.IsNullOrEmpty(model.SourceType) ? "[SourceType]" : "'" + model.SourceType + "'";
                string addTime = string.IsNullOrEmpty(model.AddTime) ? "[AddTime]" : "'" + model.AddTime + "'";
                string updateTime = string.IsNullOrEmpty(model.UpdateTime) ? "[UpdateTime]" : "'" + model.UpdateTime + "'";
                string token = string.IsNullOrEmpty(model.Token) ? "[Token]" : "'" + model.Token + "'";
                string domain = string.IsNullOrEmpty(model.Domain) ? "[Domain]" : "'" + model.Domain + "'";
                string pushCount = string.IsNullOrEmpty(model.PushCount) ? "[PushCount]" : "'" + model.PushCount + "'";

                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[Edumail] WHERE " +
                                              "[ID] = {1} AND [Account] = {2} AND [Password] = {3} AND [NewPassword] = {4} AND [State] = {5} AND" +
                                              "[DevAccount] = {6} AND [DevPassword] = {7} AND [SourceType] = {8} AND [AddTime] = {9} AND [UpdateTime] = {10} AND [Token] = {11} AND [Domain] = {12} AND [PushCount] = {13}",
                                              count == 0 ? "" : "TOP " + count.ToString(),
                                              id, account, password, newPassword, state,
                                              devAccount, devPassword, sourceType, addTime, updateTime, token, domain, pushCount);

                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }

                List<DreamSparkerModel> result = new List<DreamSparkerModel>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DreamSparkerModel r_t = new DreamSparkerModel
                    {
                        Account = table.Rows[i]["Account"].ToString(),
                        DevAccount = table.Rows[i]["DevAccount"].ToString(),
                        ID = table.Rows[i]["ID"].ToString(),
                        AddTime = table.Rows[i]["AddTime"].ToString(),
                        DevPassword = table.Rows[i]["DevPassword"].ToString(),
                        NewPassword = table.Rows[i]["NewPassword"].ToString(),
                        Password = table.Rows[i]["Password"].ToString(),
                        SourceType = table.Rows[i]["SourceType"].ToString(),
                        State = table.Rows[i]["State"].ToString(),
                        UpdateTime = table.Rows[i]["UpdateTime"].ToString(),
                        Domain = table.Rows[i]["Domain"].ToString(),
                        Token = table.Rows[i]["Token"].ToString(),
                        PushCount = table.Rows[i]["PushCount"].ToString()
                    };

                    result.Add(r_t);
                }

                //当获取1个，并且State是“已获取”的时候，试做为激活做准备。
                if (state == "'已获取'" && count == 1)
                {
                    string sqlCmd_t = string.Format("UPDATE [dbo].[Edumail] SET [State] = '激活中' WHERE [ID] = {0}", result[0].ID);
                    SqlHelper.Instance.ExecuteCommand(sqlCmd_t);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public void UpdateDreamSparker(DreamSparkerModel model,string ip)
        {
            try
            {
                string id = string.IsNullOrEmpty(model.ID) ? "[ID]" : "'" + model.ID + "'";
                string account = string.IsNullOrEmpty(model.Account) ? "[Account]" : "'" + model.Account + "'";
                string password = string.IsNullOrEmpty(model.Password) ? "[Password]" : "'" + model.Password + "'";
                string newPassword = string.IsNullOrEmpty(model.NewPassword) ? "[NewPassword]" : "'" + model.NewPassword + "'";
                string state = string.IsNullOrEmpty(model.State) ? "[State]" : "'" + model.State + "'";
                string devAccount = string.IsNullOrEmpty(model.DevAccount) ? "[DevAccount]" : "'" + model.DevAccount + "'";
                string devPassword = string.IsNullOrEmpty(model.DevPassword) ? "[DevPassword]" : "'" + model.DevPassword + "'";
                string sourceType = string.IsNullOrEmpty(model.SourceType) ? "[SourceType]" : "'" + model.SourceType + "'";
                string addTime = string.IsNullOrEmpty(model.AddTime) ? "[AddTime]" : "'" + model.AddTime + "'";
                string updateTime = string.IsNullOrEmpty(model.UpdateTime) ? "[UpdateTime]" : "'" + model.UpdateTime + "'";
                string token = string.IsNullOrEmpty(model.Token) ? "[Token]" : "'" + model.Token + "'";
                string domain = string.IsNullOrEmpty(model.Domain) ? "[Domain]" : "'" + model.Domain + "'";
                string pushCount = string.IsNullOrEmpty(model.PushCount) ? "[PushCount]" : "'" + model.PushCount + "'";



                string sqlCmd = string.Format("UPDATE [dbo].[Edumail] SET [Account] = {1},[Password] = {2},[NewPassword] = {3},[State] = {4}," +
                                              "[DevAccount] = {5},[DevPassword] = {6},[SourceType] = {7},[UpdateTime] = '{8}',[Token] = {9},[Domain]= {10},[PushCount] = {11} WHERE [ID] = {0}",
                                              id, account, password, newPassword, state,
                                              devAccount, devPassword, sourceType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                              token, domain, pushCount);

                if (state == "'已激活'")
                {
                    sqlCmd = string.Format("UPDATE [dbo].[Edumail] SET [Account] = {1},[Password] = {2},[NewPassword] = {3},[State] = {4}," +
                                              "[DevAccount] = {5},[DevPassword] = {6},[SourceType] = {7},[UpdateTime] = '{8}',[Token] = {9},[Domain]= {10},[PushCount] = {11},[ActiveIP] = '{12}' WHERE [ID] = {0}",
                                              id, account, password, newPassword, state,
                                              devAccount, devPassword, sourceType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                              token, domain, pushCount,ip);
                }

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDreamSparkerByDevAccount(DreamSparkerModel model)
        {
            try
            {
                string id = string.IsNullOrEmpty(model.ID) ? "[ID]" : "'" + model.ID + "'";
                string account = string.IsNullOrEmpty(model.Account) ? "[Account]" : "'" + model.Account + "'";
                string password = string.IsNullOrEmpty(model.Password) ? "[Password]" : "'" + model.Password + "'";
                string newPassword = string.IsNullOrEmpty(model.NewPassword) ? "[NewPassword]" : "'" + model.NewPassword + "'";
                string state = string.IsNullOrEmpty(model.State) ? "[State]" : "'" + model.State + "'";
                string devAccount = string.IsNullOrEmpty(model.DevAccount) ? "[DevAccount]" : "'" + model.DevAccount + "'";
                string devPassword = string.IsNullOrEmpty(model.DevPassword) ? "[DevPassword]" : "'" + model.DevPassword + "'";
                string sourceType = string.IsNullOrEmpty(model.SourceType) ? "[SourceType]" : "'" + model.SourceType + "'";
                string addTime = string.IsNullOrEmpty(model.AddTime) ? "[AddTime]" : "'" + model.AddTime + "'";
                string updateTime = string.IsNullOrEmpty(model.UpdateTime) ? "[UpdateTime]" : "'" + model.UpdateTime + "'";
                string token = string.IsNullOrEmpty(model.Token) ? "[Token]" : "'" + model.Token + "'";
                string domain = string.IsNullOrEmpty(model.Domain) ? "[Domain]" : "'" + model.Domain + "'";
                string pushCount = string.IsNullOrEmpty(model.PushCount) ? "[PushCount]" : "'" + model.PushCount + "'";


                string sqlCmd = string.Format("UPDATE [dbo].[Edumail] SET [Account] = {1},[Password] = {2},[NewPassword] = {3},[State] = {4}," +
                                              "[DevAccount] = {5},[DevPassword] = {6},[SourceType] = {7},[UpdateTime] = '{8}',[Token] = {9},[Domain]= {10},[PushCount]= {11} WHERE [DevAccount] = {0}",
                                              devAccount, account, password, newPassword, state,
                                              devAccount, devPassword, sourceType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                              token, domain, pushCount);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddDreamSparkerModel(DreamSparkerModel model)
        {
            try
            {
                string sqlCmd_Get = string.Format("SELECT COUNT(*) FROM [dbo].[Edumail] WHERE [Account] = '{0}'", model.Account);

                int count = int.Parse(SqlHelper.Instance.ExecuteScalar(sqlCmd_Get).ToString());

                if (count > 0)
                {
                    throw new Exception("该账号已经存在于库中!");
                }

                string sqlCmd = string.Format("INSERT INTO [dbo].[Edumail] ([Account],[Password],[NewPassword],[State],[DevAccount],[DevPassword],[SourceType],[AddTime],[UpdateTime],[Token],[Domain],[PushCount])" +
                                              " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                                              model.Account, model.Password, model.NewPassword, model.State, model.DevAccount, model.DevPassword,
                                              model.SourceType, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), model.Token, model.Domain, model.PushCount);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDreamSparkerModel(string id)
        {
            try
            {
                string sqlCmd = string.Format("DELETE FROM [dbo].[Edumail] WHERE [ID] = '{0}'", id);
                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch
            { }
        }

        public List<AccountInfo> GetAccountInfoByDevState(string isDevAccount, int count)
        {
            try
            {
                string sqlCmd = string.Format("SELECT {0} * FROM [dbo].[Accounts] WHERE [IsDevAccount] = '{1}' AND [State] ='binding' ORDER BY [BindingTime] desc",
                                              count == 0 ? "" : "TOP " + count.ToString(), isDevAccount);

                DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }

                List<AccountInfo> result = new List<AccountInfo>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    AccountInfo r_t = new AccountInfo
                    {
                        Account = table.Rows[i]["Account"].ToString(),
                        BindingTime = table.Rows[i]["BindingTime"].ToString(),
                        Country = table.Rows[i]["Country"].ToString(),
                        Group = table.Rows[i]["Group"].ToString(),
                        IsDevAccount = table.Rows[i]["IsDevAccount"].ToString(),
                        Password = table.Rows[i]["Password"].ToString(),
                        PhoneType = table.Rows[i]["PhoneType"].ToString(),
                        State = table.Rows[i]["State"].ToString(),
                        UserName = table.Rows[i]["UserName"].ToString(),
                        UpdateTime = table.Rows[i]["UpdateTime"].ToString(),
                        ID = table.Rows[i]["ID"].ToString(),
                    };

                    result.Add(r_t);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public void UpdateAccounDevState(string isDevAccount, string state, string id)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[Accounts] SET [IsDevAccount] = '{1}',[UpdateTime]= '{2}',[State] = '{3}' WHERE [ID] = '{0}'",
                                             id, isDevAccount, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), state);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
