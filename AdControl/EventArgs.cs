using PAdControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl
{
    public class AdEventArgs : EventArgs
    {
        public List<AdInfo> AdInfoList;
        public string ErrorMessage;
    }

    public class RecommendAppEventArgs : EventArgs
    {
        public List<RecommendAppModel> RecommendAppList;
        public string ErrorMessage;
    }
}
