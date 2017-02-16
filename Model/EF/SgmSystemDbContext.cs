namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SgmSystemDbContext : DbContext
    {
        public SgmSystemDbContext()
            : base("name=SgmDb")
        {
        }

        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<tbl_Attandance> tbl_Attandance { get; set; }
        public virtual DbSet<tbl_Event> tbl_Event { get; set; }
        public virtual DbSet<tbl_Group> tbl_Group { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }
        public virtual DbSet<tbl_UserEvent> tbl_UserEvent { get; set; }
        public virtual DbSet<tbl_UserRole> tbl_UserRole { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }
        public virtual DbSet<tbl_YearCalendar> tbl_YearCalendar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<SgmSystemDbContext>(null);
            modelBuilder.Entity<tbl_Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Admin>()
                .Property(e => e.AdminPass)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Group>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.UserPass)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.UserComputer)
                .IsUnicode(false);
        }
    }
}
