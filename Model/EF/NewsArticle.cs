namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsArticle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewsArticle()
        {
            NewsArticleCategories = new HashSet<NewsArticleCategory>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string headline { get; set; }

        [Column(TypeName = "text")]
        public string extract { get; set; }

        [Required]
        [StringLength(45)]
        public string encoding { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string text { get; set; }

        public DateTime publishDate { get; set; }

        [StringLength(255)]
        public string byLine { get; set; }

        [StringLength(255)]
        public string source { get; set; }

        [Required]
        [StringLength(20)]
        public string state { get; set; }

        [Column(TypeName = "text")]
        public string clientQuote { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime lastModifiedDate { get; set; }

        [StringLength(255)]
        public string htmlMetaDescription { get; set; }

        [StringLength(255)]
        public string htmlMetaKeywords { get; set; }

        [StringLength(255)]
        public string htmlMetaLangauge { get; set; }

        [StringLength(255)]
        public string tags { get; set; }

        public int? priority { get; set; }

        [Required]
        [StringLength(10)]
        public string format { get; set; }

        [StringLength(255)]
        public string photoHtmlAlt { get; set; }

        public short? photoWidth { get; set; }

        public short? photoHeight { get; set; }

        [Column(TypeName = "text")]
        public string photoURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsArticleCategory> NewsArticleCategories { get; set; }
    }
}
