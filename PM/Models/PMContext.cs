using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PM.Models
{
    public partial class PMContext : DbContext
    {
        public PMContext()
        {
        }

        public PMContext(DbContextOptions<PMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackList> BlackList { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<ChatDetail> ChatDetail { get; set; }
        public virtual DbSet<ChatRoom> ChatRoom { get; set; }
        public virtual DbSet<ChatUser> ChatUser { get; set; }
        public virtual DbSet<Citys> Citys { get; set; }
        public virtual DbSet<CmsBanner> CmsBanner { get; set; }
        public virtual DbSet<CmsNews> CmsNews { get; set; }
        public virtual DbSet<CmsNewsCategory> CmsNewsCategory { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<FriendsList> FriendsList { get; set; }
        public virtual DbSet<Fund> Fund { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<GalleryProductPicture> GalleryProductPicture { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<NewsTags> NewsTags { get; set; }
        public virtual DbSet<NotifyHistory> NotifyHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostReport> PostReport { get; set; }
        public virtual DbSet<PostShare> PostShare { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductImport> ProductImport { get; set; }
        public virtual DbSet<ProductPicture> ProductPicture { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductUnit> ProductUnit { get; set; }
        public virtual DbSet<RequestMoney> RequestMoney { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Slug> Slug { get; set; }
        public virtual DbSet<StaticPage> StaticPage { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourMember> TourMember { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<UserDevices> UserDevices { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WebLinks> WebLinks { get; set; }
        public virtual DbSet<WebpagesMembership> WebpagesMembership { get; set; }
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMembership { get; set; }
        public virtual DbSet<WebpagesRoles> WebpagesRoles { get; set; }
        public virtual DbSet<WebpagesUsers> WebpagesUsers { get; set; }
        public virtual DbSet<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TL\\SQLEXPRESS;Database=PM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlackList>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BlockUserId });

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ChatDetail>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Message).HasColumnType("ntext");

                entity.Property(e => e.RoomId)
                    .HasMaxLength(125)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.RoomId)
                    .HasMaxLength(125)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastDate).HasColumnType("datetime");

                entity.Property(e => e.LastMessage).HasColumnType("ntext");

                entity.Property(e => e.RoomName).HasMaxLength(1000);
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId)
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Citys>(entity =>
            {
                entity.Property(e => e.CityName).HasMaxLength(100);
            });

            modelBuilder.Entity<CmsBanner>(entity =>
            {
                entity.ToTable("CMS_Banner");

                entity.Property(e => e.BannerName).HasMaxLength(128);

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.LargeImage)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LinkRedirect)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TargetLink)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailImage)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CmsNews>(entity =>
            {
                entity.ToTable("CMS_News");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BodyContent).HasColumnType("ntext");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirateDate).HasColumnType("datetime");

                entity.Property(e => e.ImageThumb)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription).HasMaxLength(1000);

                entity.Property(e => e.MetaKeyword).HasColumnType("ntext");

                entity.Property(e => e.MetaTitle).HasMaxLength(256);

                entity.Property(e => e.PromoExpireDate).HasColumnType("datetime");

                entity.Property(e => e.PromoStartDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SeoName).HasMaxLength(256);

                entity.Property(e => e.ShareCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShortDescription).HasMaxLength(1024);

                entity.Property(e => e.Tag).HasMaxLength(256);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.UrlRewrite)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CmsNewsCategory>(entity =>
            {
                entity.ToTable("CMS_NewsCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(200);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.IconImg)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UrlRewrite)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(4000);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Contents).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowUserId });

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FriendsList>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendUserId });

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Fund>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FundSafe)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LuckyBonus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LuckyFund).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LuckyMinInCome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SharingBonus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SharingFund).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SharingMinInCome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TravellingBonus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TravellingFund).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TravellingMinInCome).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.GalleryName).HasMaxLength(255);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GalleryProductPicture>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.ToTable("Gallery_Product_Picture");

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.Bimage)
                    .HasColumnName("BImage")
                    .HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Mimage)
                    .HasColumnName("MImage")
                    .HasMaxLength(256);

                entity.Property(e => e.PictureName).HasMaxLength(256);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Simage)
                    .HasColumnName("SImage")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(255);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Message1)
                    .HasColumnName("Message")
                    .HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(128);
            });

            modelBuilder.Entity<NewsTags>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.NewsTitle).HasMaxLength(256);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagName).HasMaxLength(200);
            });

            modelBuilder.Entity<NotifyHistory>(entity =>
            {
                entity.Property(e => e.Action)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasMaxLength(4000);

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.BillingAddress).HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CurrentIncome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerIp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(256);

                entity.Property(e => e.OrderDiscount)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShippingAddress).HasMaxLength(256);

                entity.Property(e => e.ShippingEmail).HasMaxLength(100);

                entity.Property(e => e.ShippingName).HasMaxLength(100);

                entity.Property(e => e.ShippingPhone).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Comment).HasDefaultValueSql("((0))");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActived).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Like).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShareCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title).HasColumnType("ntext");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.WebLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YoutubeLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostReport>(entity =>
            {
                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Bimage)
                    .HasColumnName("BImage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MetaDescription).HasMaxLength(255);

                entity.Property(e => e.MetaKeyword).HasMaxLength(255);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.Mimage)
                    .HasColumnName("MImage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Simage)
                    .HasColumnName("SImage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductImport>(entity =>
            {
                entity.HasKey(e => e.ImportId);

                entity.Property(e => e.ImportId).HasColumnName("ImportID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImportDate).HasColumnType("datetime");

                entity.Property(e => e.ImportFrom).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.ToTable("Product_Picture");

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.Bimage)
                    .HasColumnName("BImage")
                    .HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Mimage)
                    .HasColumnName("MImage")
                    .HasMaxLength(256);

                entity.Property(e => e.PictureName).HasMaxLength(256);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Simage)
                    .HasColumnName("SImage")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Bimage)
                    .HasColumnName("BImage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BonusPercent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DetailContent).HasColumnType("ntext");

                entity.Property(e => e.MetaDescription).HasMaxLength(255);

                entity.Property(e => e.MetaKeyword).HasMaxLength(255);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.Mimage)
                    .HasColumnName("MImage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.Promotion).HasMaxLength(255);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SeoName).HasMaxLength(255);

                entity.Property(e => e.ShareCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShortDescription).HasColumnType("ntext");

                entity.Property(e => e.Simage)
                    .HasColumnName("SIMage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TokenPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ViewDoping).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UnitName).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestMoney>(entity =>
            {
                entity.Property(e => e.AccountName).HasMaxLength(128);

                entity.Property(e => e.AccountNumber).HasMaxLength(128);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BankLocation).HasMaxLength(128);

                entity.Property(e => e.BankName).HasMaxLength(128);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.Property(e => e.SettingName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<Slug>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.HashSlug)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

                entity.Property(e => e.RedirectUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SlugName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(128);
            });

            modelBuilder.Entity<StaticPage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content1).HasColumnType("ntext");

                entity.Property(e => e.Content2).HasColumnType("ntext");

                entity.Property(e => e.Content3).HasColumnType("ntext");

                entity.Property(e => e.Content4).HasColumnType("ntext");

                entity.Property(e => e.Content5).HasColumnType("ntext");

                entity.Property(e => e.Copyright).HasMaxLength(256);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.Hotline).HasMaxLength(256);

                entity.Property(e => e.Logo).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyWord).HasMaxLength(256);

                entity.Property(e => e.MetaTitle).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TagName).HasMaxLength(200);
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TourName).HasMaxLength(128);
            });

            modelBuilder.Entity<TourMember>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Income).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LastBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LastIncome).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Note).HasColumnType("ntext");

                entity.Property(e => e.TransactionSafe)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentBalanceToUserId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CurrentBalanceUserId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToUserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionName).HasMaxLength(255);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Browser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.PostTitle).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserIdpost).HasColumnName("UserIDPost");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserNamePost).HasMaxLength(255);
            });

            modelBuilder.Entity<UserDevices>(entity =>
            {
                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("ntext");

                entity.Property(e => e.Token).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.AccountBalance)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountPoint)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.AvatarImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AvatarImageName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountName).HasMaxLength(120);

                entity.Property(e => e.BankAccountNumber).HasMaxLength(120);

                entity.Property(e => e.BankLocation).HasMaxLength(120);

                entity.Property(e => e.BankName).HasMaxLength(120);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImageName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Followers).HasDefaultValueSql("((0))");

                entity.Property(e => e.Following).HasDefaultValueSql("((0))");

                entity.Property(e => e.FrontSide)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InCome)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActived).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHot).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLock).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOnline).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsShowCountry).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsShowDate).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsUpdateAvatar).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVerify).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVip).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordFailureDate).HasColumnType("datetime");

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoginFailNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.MessageDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewComment).HasDefaultValueSql("((1))");

                entity.Property(e => e.NewFollow).HasDefaultValueSql("((0))");

                entity.Property(e => e.NewMessage).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrgAvatarImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordVerificationToken).HasMaxLength(256);

                entity.Property(e => e.PasswordVerificationTokenExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.Posts).HasDefaultValueSql("((0))");

                entity.Property(e => e.RearSide)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserSafe)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserType).HasDefaultValueSql("((0))");

                entity.Property(e => e.VerifyDate).HasColumnType("datetime");

                entity.Property(e => e.Views).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<WebLinks>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.Property(e => e.LinkId).HasColumnName("LinkID");

                entity.Property(e => e.LinkName).HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(500);
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("webpages_Membership");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ConfirmationToken).HasMaxLength(128);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPasswordFailureDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationToken).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationTokenExpirationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId });

                entity.ToTable("webpages_OAuthMembership");

                entity.Property(e => e.Provider).HasMaxLength(30);

                entity.Property(e => e.ProviderUserId).HasMaxLength(100);
            });

            modelBuilder.Entity<WebpagesRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("webpages_Roles");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__webpages__8A2B61607E8CC4B1")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<WebpagesUsers>(entity =>
            {
                entity.ToTable("webpages_Users");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DisplayName).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FullName).HasMaxLength(128);

                entity.Property(e => e.IsLock).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phone).HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebpagesUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("webpages_UsersInRoles");
            });
        }
    }
}
