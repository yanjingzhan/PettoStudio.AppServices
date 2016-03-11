using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace XAPADStatisticsTest
{
    public class AssociationUriMapper : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            if (uri.ToString().Contains("Protocol"))
            {
                App.isStart = false;
                return new Uri("/MainPage.xaml", UriKind.Relative);
            }
            else
            {
                if (App.isStart)
                {
                    return new Uri("/BootPage.xaml", UriKind.Relative);
                }
                else
                {
                    return uri;
                }
            }
        }
    }
}
