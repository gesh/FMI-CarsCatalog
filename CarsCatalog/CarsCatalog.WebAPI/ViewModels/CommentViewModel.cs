using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCatalog.WebAPI.ViewModels
{
    public class CommentViewModel
    {
        public int CarID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public double  Rating { get; set; }
    }
}