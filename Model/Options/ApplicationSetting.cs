using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Options
{
    public class ApplicationSetting
    {
        public string DBConnectionString { get; set; }
        public string RestServiceBaseUrl { get; set; }
        public string RestServiceGetMethod { get; set; }
    }
}
