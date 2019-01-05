namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TechFireFlyDbContext : DbContext
    {
        public TechFireFlyDbContext()
            : base("name=TechFireFlyDbContext")
        {
        }

        public virtual DbSet<NewsArticleCategory> NewsArticleCategories { get; set; }
        public virtual DbSet<NewsArticle> NewsArticles { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.headline)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.extract)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.encoding)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.byLine)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.clientQuote)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.htmlMetaDescription)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.htmlMetaKeywords)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.htmlMetaLangauge)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.tags)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.format)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.photoHtmlAlt)
                .IsUnicode(false);

            modelBuilder.Entity<NewsArticle>()
                .Property(e => e.photoURL)
                .IsUnicode(false);

            modelBuilder.Entity<NewsCategory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
