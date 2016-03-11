using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl.Models
{
    public class RecommendAppModel
    {
        public string AppName { get; set; }
        public string AppInfo { get; set; }
        public string AppUri { get; set; }
        public string AppImageUri { get; set; }
        public int PRI { get; set; }
    }
}
