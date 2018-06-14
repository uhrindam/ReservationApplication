namespace BOL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class ReservationDBInitializer : CreateDatabaseIfNotExists<ReservationAPPModel>
    {
        protected override void Seed(ReservationAPPModel context)
        {
            context.Database.Create();
            context.USERS.Add(new USERS()
            {
                EmailAddress = "admin@admin.admin",
                FullName = "Admin Admin",
                IsAdmin = true,
                NickName = "admin",
                Passwd = "d033e22ae348aeb5660fc2140aec35850c4da997", // "admin"
                RegistrationDate = new DateTime(2018, 06, 02, 00, 00, 00)
            }
            );
            context.SaveChanges();
        }
    }

    public partial class ReservationAPPModel : DbContext
    {
        public ReservationAPPModel()
            : base("name=ReservationAPPModel")
        {
            Database.SetInitializer(new ReservationDBInitializer());

        }

        public virtual DbSet<APPOINTMENTS> APPOINTMENTS { get; set; }
        public virtual DbSet<CATEGORIES> CATEGORIES { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APPOINTMENTS>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<APPOINTMENTS>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIES>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIES>()
                .HasMany(e => e.APPOINTMENTS)
                .WithRequired(e => e.CATEGORIES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.Passwd)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.APPOINTMENTS)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);
        }
    }
}
