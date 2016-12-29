using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AmazonFullInfoServices
{
    public partial class AccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, newStateAfterUse, state, account, country, gamename;
                action = Request["action"] == null ? "" : Request["action"].Trim();
                newStateAfterUse = Request["newstateafteruse"] == null ? "" : Request["newstateafteruse"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                country = Request["country"] == null ? "" : Request["country"].Trim();
                gamename = Request["gamename"] == null ? "" : Request["gamename"].Trim();

                switch (action.ToLower())
                {
                    case "getamazonfullinfo":
                        GetAmazonFullInfo(newStateAfterUse);
                        break;

                    case "getamazonfullinfostr":
                        GetAmazonFullInfoStr(newStateAfterUse);
                        break;

                    case "updateaccountstate":
                        UpdateAccountState(account, state);
                        break;

                    case "addshuacount":
                        AddShuaCount(country, gamename);
                        break;


                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        public void GetAmazonFullInfo(string newStateAfterUse)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AmazonFullInfoServicesControl().GetAmazonFullInfo(newStateAfterUse));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAmazonFullInfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAmazonFullInfo");
            }
        }

        public void GetAmazonFullInfoStr(string newStateAfterUse)
        {
            try
            {
                var data =
                    new AmazonFullInfoServicesControl().GetAmazonFullInfo(newStateAfterUse);

                string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32}",
                    data.IMEI, data.AndroidID, data.PhoneNum, data.SimSerialNum, data.IMSI, data.SimCountry, data.Operator, data.OperatorName, data.CountryISOCode, data.NetworkType, data.NetworkTypeName, data.PhoneType,
                    data.PhoneCardStatus, data.MacAddress, data.WIFIName, data.WIFIAddress, data.OSVersion, data.OSVersionValue, data.OSStructure, data.ScreenResolution, data.FirmwareVersion, data.Brand, data.Model, data.ProductName,
                    data.OEM, data.CPUModel, data.Hardware, data.AmazonAccount, data.AmazonPassword, data.VPNAccount, data.VPNPassword, data.IP,
                    //test
                    //"need speed car"
                    "racing"
                    );

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAmazonFullInfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAmazonFullInfo");
            }

        }

        public void UpdateAccountState(string account, string state)
        {
            try
            {
                new AmazonFullInfoServicesControl().UpdateAccountState(account, state);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountCountryAndGroup");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountState");
            }
        }

        public void AddShuaCount(string country, string gameName)
        {
            try
            {
                new AmazonFullInfoServicesControl().AddShuaCount(country, gameName);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddShuaCount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddShuaCount");
            }
        }

    }
}