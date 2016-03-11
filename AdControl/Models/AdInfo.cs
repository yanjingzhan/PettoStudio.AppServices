using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl.Models
{
    public class AdInfo
    {
        public string AdTpye;
        public string AdName;
        public string AdId1;
        public string AdId2;
        public string AdId3;
        public int ClickCountToHide;
        public int PRI;
        public string Position;
        public string ImageUrl;
        public string ClickUrl;
        public int AdIndex;
        public int ShowFullAdTime;
        public int ShowFullAdCount;
        public int CarouselBannersInterval;
        public int RefreshBannersInterval;

        public bool IsDontRefresh;
    }
}
