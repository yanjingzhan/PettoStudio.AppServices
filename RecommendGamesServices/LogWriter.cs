using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Utility;


namespace RecommendGamesServices
{
    public class LogWriter
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="LogMessage">日志内容</param>
        public static void WriteLog(string LogMessage, System.Web.UI.Page page)
        {
            string IP = page.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string stringFrom = string.Empty;
            string stringQuery = string.Empty;
            System.Collections.Specialized.NameValueCollection NameValues = page.Request.Form;
            if (NameValues.Count > 0)
            {
                string[] AllKeys = NameValues.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringFrom.Length == 0)
                    {
                        stringFrom += tepKey + "=" + NameValues[tepKey];
                    }
                    else
                    {
                        stringFrom += "&" + tepKey + "=" + NameValues[tepKey];
                    }
                }
            }

            System.Collections.Specialized.NameValueCollection NameVlaues1 = page.Request.QueryString;

            if (NameVlaues1.Count > 0)
            {
                string[] AllKeys = NameVlaues1.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringQuery.Length == 0)
                    {
                        stringQuery += tepKey + "=" + NameVlaues1[tepKey];
                    }
                    else
                    {
                        stringQuery += "&" + tepKey + "=" + NameVlaues1[tepKey];
                    }
                }
            }
            Log.Write(IP, stringFrom, stringQuery, LogMessage, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"));
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="LogMessage">日志内容</param>
        public static void WriteLog(string LogMessage, System.Web.UI.Page page, string fileNamePre)
        {
            string IP = page.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string stringFrom = string.Empty;
            string stringQuery = string.Empty;
            System.Collections.Specialized.NameValueCollection NameValues = page.Request.Form;
            if (NameValues.Count > 0)
            {
                string[] AllKeys = NameValues.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringFrom.Length == 0)
                    {
                        stringFrom += tepKey + "=" + NameValues[tepKey];
                    }
                    else
                    {
                        stringFrom += "&" + tepKey + "=" + NameValues[tepKey];
                    }
                }
            }

            System.Collections.Specialized.NameValueCollection NameVlaues1 = page.Request.QueryString;

            if (NameVlaues1.Count > 0)
            {
                string[] AllKeys = NameVlaues1.AllKeys;
                foreach (string tepKey in AllKeys)
                {
                    if (stringQuery.Length == 0)
                    {
                        stringQuery += tepKey + "=" + NameVlaues1[tepKey];
                    }
                    else
                    {
                        stringQuery += "&" + tepKey + "=" + NameVlaues1[tepKey];
                    }
                }
            }
            Log.Write(IP, stringFrom, stringQuery, LogMessage, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"), fileNamePre);
        }
    }
}