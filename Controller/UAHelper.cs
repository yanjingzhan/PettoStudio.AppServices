using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLib;

namespace Controller
{
    public class UAHelper
    {
        public string GetUARandom(string system)
        {
            try
            {
                string sqlCmd = string.Format("SELECT TOP 1 [UAString] FROM [dbo].[MobileUserAgent] WHERE [System] = '{0}' ORDER BY newid()", system);

                if (string.IsNullOrEmpty(system) || system.ToLower() != "ios" || system.ToLower() != "android" || system.ToLower() != "windows")
                {
                    sqlCmd = string.Format("SELECT TOP 1 [UAString] FROM [dbo].[MobileUserAgent] ORDER BY newid()");
                }

                object t = SqlHelper.Instance.ExecuteScalar(sqlCmd);

                return t.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
