using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using XSA.Models;

namespace XSA.Models
{
    public class NewsArticle
    {
        public string Title {get; set;}
        public string Picture {get; set;}
        public string Body {get; set;}
        public string Author {get; set;}
        public string Date {get; set;}
    }
    
}