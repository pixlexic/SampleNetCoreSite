

using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLE_NetCoreMVC.Helpers
{
    public class AppSettings
    {

        public string? Secret { get; set; }

        public string? AssetFolder { get; set; }

        public string? SMTPServer { get; set; }
        public string? SMTPUserName { get; set; }
        public string? SMTPPassword { get; set; }

    }
}