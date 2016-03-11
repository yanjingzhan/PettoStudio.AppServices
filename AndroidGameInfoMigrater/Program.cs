using DataBaseLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidGameInfoMigrater
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlGetter = "SELECT * FROM [dbo].[AYYGames] WHERE ([Version] LIKE '%4.%' OR　[Version] LIKE '%5.%') AND LEN([Version])=5";

            DataTable table = SqlHelper.Instance.ExecuteDataTable(sqlGetter);

            if (table != null || table.Rows.Count != 0)
            {
                Console.WriteLine("行数：{0}",table.Rows.Count);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string gameName_t = table.Rows[i]["Name"].ToString();

                    Console.WriteLine("原名：{0}", gameName_t);

                    if(gameName_t.ToLower().EndsWith(" apk"))
                    {
                        int i_t = gameName_t.ToLower().LastIndexOf(" v");
                        if(i_t > 0)
                        {
                            gameName_t = gameName_t.Remove(i_t).Trim();
                        }
                        else
                        {
                            gameName_t = gameName_t.Replace(" APK", "").Trim();
                        }
                    }


                    Console.WriteLine("新名：{0}", gameName_t);

                    string sqlInserter = string.Format("INSERT INTO [dbo].[PushGameInfo] ([GameName],[Version],[State],[GameID],[PusherName],[SurfaceAccountID],[SurfaceAdID],[GoogleBanner],[GoogleChaping]"
                                        +",[PubcenterAppID],[PubcenterAdID],[AddTime],[UpdateTime],[DevAccount],[DevPassword],[GameDetails],[LogoPath],[BackImagePath],[SourceType],[FileName]"
                                        + ",[JPState],[FixedGameName],[AdName],[RealDevAccount],[RealDevPassword],[LastGameName],[PushIP],[GameClassify],[UnityVersion]) VALUES "
                                        + "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}',"
                                        + "'{24}','{25}','{26}','{27}','{28}')",
                                        gameName_t, "0", "安卓未就绪", "", "", "", "", "", "",
                                        "", "", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),"","",table.Rows[i]["GameProfileInfo"].ToString(),"","","android_unity",table.Rows[i]["FileName"].ToString(),
                                        "", gameName_t, "", "", "", "", "", table.Rows[i]["GameClassify"].ToString(), table.Rows[i]["Version"].ToString());

                    try
                    {
                        SqlHelper.Instance.ExecuteCommand(sqlInserter);
                        Console.WriteLine("{0},成功", gameName_t);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("{0},失败,{1}", gameName_t,ex.Message);
                    }
                }
            }

        }

    }
}
