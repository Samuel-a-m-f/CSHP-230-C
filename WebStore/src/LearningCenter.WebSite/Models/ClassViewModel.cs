using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenter.WebSite.Models
{
    public class ClassViewModel
    {
        public CategoryModel Category { get; set; }
        public ProductModel[] Products { get; set; }
    }
}