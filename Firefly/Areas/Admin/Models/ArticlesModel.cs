using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Firefly.Areas.Admin.Models
{
    public class ArticlesModel
    {

        public int id { get; set; }

        [Display(Name = "Danh mục")]
        public int newsCategoryID { get; set; }
        
        [Display(Name = "Danh mục")]
        public string newsCategory { get; set; }
        
        [Display(Name ="Tiêu đề")]
        public string headline { get; set; }

        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string text { get; set; }

        public DateTime? publishDate { get; set; }

        [Display(Name = "Tác giả")]
        public string byLine { get; set; }

        [Display(Name ="Nguồn")]
        public string source { get; set; }

        public string state { get; set; }

        public DateTime? createdDate { get; set; }

        public DateTime? lastModifiedDate { get; set; }

        public string htmlMetaDescription { get; set; }

        public string htmlMetaKeywords { get; set; }

        public string htmlMetaLangauge { get; set; }

        public string photoHtmlAlt { get; set; }

        [Display(Name ="Ảnh minh họa")]
        public string photoURL { get; set; }
    }
}