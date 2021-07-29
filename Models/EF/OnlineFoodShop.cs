using System.Data.Entity;

namespace FoodShopOnline.Models.EF
{
    public partial class OnlineFoodShop : DbContext
    {
        public OnlineFoodShop()
            : base("name=OnlineFoodShop")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OderDetail> OderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admins>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .HasMany(e => e.Tags1)
                .WithMany(e => e.News)
                .Map(m => m.ToTable("NewsTag").MapLeftKey("NewsID").MapRightKey("TagsID"));

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipPhone)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Tags1)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductTag").MapLeftKey("ProductID").MapRightKey("TagsID"));

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();
        }
    }
}
