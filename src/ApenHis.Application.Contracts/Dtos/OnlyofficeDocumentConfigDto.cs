using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApenHis.Dtos
{
    public class config
    {
        public Document document { get; set; }
        public string documentType { get; set; }
        public EditorConfig editorConfig { get; set; }
    }

    public class Document
    {
        public string fileType { get; set; }
        public string key { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public Info info { get; set; }
        public Permissions permissions { get; set; }
    }

    public class EditorConfig
    {
        public string callbackUrl { get; set; }
        public string lang { get; set; }
        public User user { get; set; }
        public Customization customization { get; set; }
        public Plugins plugins { get; set; }
    }

    public class User
    {
        public string group { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Logo
    {
        public string image { get; set; }
        public string imageDark { get; set; }
        public string url { get; set; }
    }

    public class Customization
    {
        public bool forcesave { get; set; }
        public Logo logo { get; set; }
        public Customer customer { get; set; }
        public bool plugins { get; set; } = true;
    }

    public class Plugins
    {
        public IList<string> autostart { get; set; }
        public IList<string> pluginsData { get; set; }
    }

    public class CommentGroups
    {
        public IList<string> edit { get; set; }
        public IList<string> remove { get; set; }
        public string view { get; set; }
    }

    public class Permissions
    {
        public bool chat { get; set; }
        public bool comment { get; set; }
        public CommentGroups commentGroups { get; set; }
        public bool copy { get; set; }
        public bool deleteCommentAuthorOnly { get; set; }
        public bool download { get; set; }
        public bool edit { get; set; }
        public bool editCommentAuthorOnly { get; set; }
        public bool fillForms { get; set; }
        public bool modifyContentControl { get; set; }
        public bool modifyFilter { get; set; }
        public bool print { get; set; }
        public bool protect { get; set; }
        public bool review { get; set; }
        public IList<string> reviewGroups { get; set; }
        public IList<string> userInfoGroups { get; set; }
    }

    public class SharingSetting
    {
        public string permissions { get; set; }
        public string user { get; set; }
        public bool? isLink { get; set; }
    }

    public class Info
    {
        public bool favorite { get; set; }
        public string folder { get; set; }
        public string owner { get; set; }
        public IList<SharingSetting> sharingSettings { get; set; }
        public string uploaded { get; set; }
    }

    public class Customer
    {
        public string address { get; set; }
        public string info { get; set; }
        public string logo { get; set; }
        public string logoDark { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string www { get; set; }
    }
}
