using Controller;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AccountsGroupperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountControl ac = new AccountControl();

            //获取国家
            List<string> countryList = ac.GetCountryList();

            foreach (var country in countryList)
            {
                Console.WriteLine(country);

                var currentCountryMax = ConfigurationManager.AppSettings[country.ToLower()];

                if (string.IsNullOrEmpty(currentCountryMax))
                {
                    currentCountryMax = ConfigurationManager.AppSettings["defalut"];
                }

                int maxCount = int.Parse(currentCountryMax);
                Console.WriteLine(maxCount);

                //把高于MaxCount的账号Group清空
                ac.KillUpperThanMaxGroupNumber(country, maxCount);

                //获取未归组且绑定了的账号个数
                int bindingNoGroupAccountCount = ac.GetBindingAccountCountByCountry(country);
                Console.WriteLine(bindingNoGroupAccountCount);

                if (bindingNoGroupAccountCount > 0)
                {
                    int maxGroupNumber = ac.GetMaxGroupNumberByCountry(country);

                    Console.WriteLine("maxGroupNumber:{0}", maxGroupNumber);

                    if (maxGroupNumber == 0)
                    {
                        ac.GroupAccountByContry(country, "1", "100");
                    }
                    else
                    {
                        bool groupsAreFull = true;
                        for (int i = 1; i < maxGroupNumber + 1; i++)
                        {
                            int groupAccountCount = ac.GetGroupAccountCountByContry(country, i.ToString());
                            Console.WriteLine("组：{0}，当前个数：{1}", i, groupAccountCount);
                          
                            //if (groupAccountCount >= 0 && groupAccountCount < 100)
                            //{
                            //    groupsAreFull = false;

                            //    int needAccountCountryNumber = 100 - groupAccountCount;
                            //    ac.GroupAccountByContry(country, i.ToString(), needAccountCountryNumber.ToString());

                            //    bindingNoGroupAccountCount -= needAccountCountryNumber;

                            //    if (bindingNoGroupAccountCount <= 0)
                            //    {
                            //        break;
                            //    }
                            //}

                            if (i == maxGroupNumber)
                            {
                                if (groupAccountCount >= 0 && groupAccountCount < 100)
                                {
                                    groupsAreFull = false;

                                    int needAccountCountryNumber = 100 - groupAccountCount;
                                    ac.GroupAccountByContry(country, i.ToString(), needAccountCountryNumber.ToString());

                                    bindingNoGroupAccountCount -= needAccountCountryNumber;

                                    if (bindingNoGroupAccountCount <= 0)
                                    {
                                        break;
                                    }
                                }                                
                            }

                            if (groupAccountCount == -1)
                            {
                                groupsAreFull = false;
                            }
                        }

                        if (groupsAreFull && maxGroupNumber < maxCount)
                        {
                            ac.GroupAccountByContry(country, (maxGroupNumber + 1).ToString(), "100");
                        }
                    }
                }

                CountryGroupInfo countryGroupInfo = ac.GetCountryGroupInfoByContryName(country);

                if (countryGroupInfo != null)
                {
                    if (countryGroupInfo.AccountCount == -1)
                    {
                        int maxGroupNumber = ac.GetMaxGroupNumberByCountry(country);
                        if (maxGroupNumber > 0)
                        {
                            int accountCountInGroup = ac.GetBindingAccountCountInGroupByCountry(country);

                            ac.InsertInfoIntoCountryGroupTable(new CountryGroupInfo
                                {
                                    AccountCount = accountCountInGroup,
                                    Country = country,
                                    CurrentGroupNumber = "1",
                                    CurrentGroupSyncTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                    MaxGroupNumber = maxGroupNumber.ToString(),
                                    MaxGroupSyncTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                                });
                        }
                    }
                    else
                    {
                        int maxGroupNumber = ac.GetMaxGroupNumberByCountry(country);
                        if (maxGroupNumber > 0)
                        {
                            int accountCountInGroup = ac.GetBindingAccountCountInGroupByCountry(country);
                            ac.UpdateMaxGroupNumberAndAccountCountToCountryGroupTable(maxGroupNumber.ToString(), accountCountInGroup.ToString(), country);
                        }
                    }
                }
            }
        }
    }
}
