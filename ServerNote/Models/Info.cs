using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ServerNote.Models
{
    public class Info
    {
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}