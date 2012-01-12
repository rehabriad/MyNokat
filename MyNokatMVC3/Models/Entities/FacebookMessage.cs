using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNokatMVC3.Models.Entities
{
    public class FacebookMessage
    {
        public string Message { get; set; }
        public string ArticleCaption { get; set; }
        public string ArticleLink { get; set; }
        public string PhotoLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActionLabel { get; set; }
        public string ActionLink { get; set; }        
    }
}


