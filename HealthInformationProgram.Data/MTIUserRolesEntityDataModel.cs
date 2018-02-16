namespace HealthInformationProgram.Models
{
    using System;
    using System.Data.Entity;
    using HealthInformationProgram.Data;
    using HealthInformationProgram.SessionObject;

    public partial class MTIUserRolesEntityDataModel : DbContext
    {
        public static MTIUserRolesEntityDataModel Create(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException(nameof(countryCode));

            return new MTIUserRolesEntityDataModel(ConnectionStringHelper.GetConnectionStringName(countryCode));
        }

        public static MTIUserRolesEntityDataModel CreateForLoggedInUser()
        {
            var countryCode = SessionData.Current.LoggedInUser?.Country.Code;

            if (string.IsNullOrEmpty(countryCode))
                throw new InvalidOperationException("Current user does not have a country associated with the current session. Reestablish the session and try again.");

            return new MTIUserRolesEntityDataModel(ConnectionStringHelper.GetConnectionStringName(countryCode));
        }

        public MTIUserRolesEntityDataModel(string connectionStringName) : base(connectionStringName) { }

        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<userrole> userroles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.accessType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
