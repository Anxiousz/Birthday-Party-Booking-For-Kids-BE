using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects
{
    public partial class PHSContext : DbContext
    {
        public PHSContext()
        {
        }

        public PHSContext(DbContextOptions<PHSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<LogAction> LogActions { get; set; }
        public virtual DbSet<MenuOrder> MenuOrders { get; set; }
        public virtual DbSet<MenuPartyHost> MenuPartyHosts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PartyHost> PartyHosts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<TransactionBooking> TransactionBookings { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.RoomId, e.AccId });

                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BookingID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisteredUser_Booking");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Booking");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("Config");

                entity.Property(e => e.ConfigId).HasColumnName("ConfigID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Configs)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Admin_Config");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.Comment).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Feedback_RegisteredUser");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Feedback_Post");
            });

            modelBuilder.Entity<LogAction>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__LogActio__5E5499A8F0E3B206");

                entity.ToTable("LogAction");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuOrder>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__MenuOrde__C99ED25093EA194A");

                entity.ToTable("MenuOrder");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FoodOrderId).HasColumnName("FoodOrderID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MenuOrders)
                    .HasForeignKey(d => new { d.BookingId, d.RoomId, d.AccId })
                    .HasConstraintName("FK_MenuOrder_Booking");
            });

            modelBuilder.Entity<MenuPartyHost>(entity =>
            {
                entity.HasKey(e => e.FoodOrderId)
                    .HasName("PK__MenuPart__943FF77F7122C355");

                entity.ToTable("MenuPartyHost");

                entity.Property(e => e.FoodOrderId).HasColumnName("FoodOrderID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PartyHostId).HasColumnName("PartyHostID");

                entity.HasOne(d => d.PartyHost)
                    .WithMany(p => p.MenuPartyHosts)
                    .HasForeignKey(d => d.PartyHostId)
                    .HasConstraintName("FK_PartyHost_MenuPartyHost");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Admin_Package");
            });

            modelBuilder.Entity<PartyHost>(entity =>
            {
                entity.ToTable("PartyHost");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PartyHosts)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PartyHost_Package");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.PartyHosts)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Staff_PartyHost");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Context).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<RegisteredUser>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Register__349DA5A62FF4BF3B");

                entity.ToTable("RegisteredUser");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.PartyHostId).HasColumnName("PartyHostID");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TimeEnd).HasColumnType("datetime");

                entity.Property(e => e.TimeStart).HasColumnType("datetime");

                entity.HasOne(d => d.PartyHost)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.PartyHostId)
                    .HasConstraintName("FK_PartyHost_Room");
            });

            modelBuilder.Entity<TransactionBooking>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__55433A4BA4243A77");

                entity.ToTable("TransactionBooking");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.AccId).HasColumnName("AccID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TransactionBookings)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_TransactionBooking_Payment");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.TransactionBookings)
                    .HasForeignKey(d => new { d.BookingId, d.RoomId, d.AccId })
                    .HasConstraintName("FK_TransactionBooking_Booking");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.ReissuedByNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.ReissuedBy)
                    .HasConstraintName("FK_PartyHost_Voucher");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SuperiorId).HasColumnName("SuperiorID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Superior)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.SuperiorId)
                    .HasConstraintName("FK_Admin_Staff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
