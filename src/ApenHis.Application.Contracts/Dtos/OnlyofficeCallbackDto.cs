using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApenHis.Dtos
{
    public class OnlyofficeCallback
    {
        public int error { get; set; }
    }
    public class OnlyofficeCallbackInput
    {
        public List<OnlyOfficeAction> actions { get; set; }
        public OnlyOfficeHistory history { get; set; }
        public string changesurl { get; set; }
        public string filetype { get; set; }
        public int? forcesavetype { get; set; }
        [Required]
        public string key { get; set; }

        public int status { get; set; }

        public string url { get; set; }

        public string userdata { get; set; }

        public List<string> users { get; set; }
    }

    public class OnlyOfficeAction
    {
        public int type { get; set; }

        public string userid { get; set; }
    }

    public class OnlyOfficeChange
    {
        public string created { get; set; }

        public OnlyOfficeUser user { get; set; }
    }
    public class OnlyOfficeUser
    {
        public string id { get; set; }

        public string name { get; set; }
    }
    public class OnlyOfficeHistory
    {
        public string serverVersion { get; set; }

        public List<OnlyOfficeChange> changes { get; set; }
    }
}
