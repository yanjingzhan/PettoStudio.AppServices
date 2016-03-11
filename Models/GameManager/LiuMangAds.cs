using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.GameManager
{
    public class LiuMangAds
    {
        /*        
         * USE [PettoStudio.AppServices]
        GO

        SELECT [ID]
              ,[IadKey]
              ,[IadAppName]
              ,[JingZhongKey]
              ,[JingZhongAppName]
              ,[Status]
              ,[Time]
          FROM [dbo].[LiuMangAds]
        GO
        */

        public string ID;
        public string IadKey;
        public string IadAppName;
        public string JingZhongKey;
        public string JingZhongAppName;

        /// <summary>
        /// 空闲/已用/作废
        /// </summary>
        public string Status;
        public string Time;
    }
}
