namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsArticleCategory")]
    public partial class NewsArticleCategory
    {
        public int id { get; set; }

        public int newsCategoryID { get; set; }

        public int newsArticleID { get; set; }

        public virtual NewsArticle NewsArticle { get; set; }

        public virtual NewsCategory NewsCategory { get; set; }
    }
}
