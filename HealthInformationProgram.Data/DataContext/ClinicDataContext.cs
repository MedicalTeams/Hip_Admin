using System;
using System.Data.Entity;
using HealthInformationProgram.Data.Mapping;
using HealthInformationProgram.Data.Tables;
using HealthInformationProgram.SessionObject;

namespace HealthInformationProgram.Data.DataContext
{
    public class ClinicDataContext :DbContext
    {
        public static ClinicDataContext Create(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException(nameof(countryCode));

            return new ClinicDataContext(ConnectionStringHelper.GetConnectionStringName(countryCode));
        }

        public static ClinicDataContext CreateForLoggedInUser()
        {
            var countryCode = SessionData.Current.LoggedInUser?.Country.Code;

            if (string.IsNullOrEmpty(countryCode))
                throw new InvalidOperationException("Current user does not have a country associated with the current session. Reestablish the session and try again.");

            return new ClinicDataContext(ConnectionStringHelper.GetConnectionStringName(countryCode));
        }

        private ClinicDataContext(string connectionString) : base(connectionString) { }

        public DbSet<curr_sys_info> curr_sys_info { get; set; }
        public DbSet<diag_alert_thrshld> diag_alert_thrshld { get; set; }
        public DbSet<faclty_hw_invtry> faclty_hw_invtry { get; set; }
        public DbSet<lkup_bnfcry> lkup_bnfcry { get; set; }
        public DbSet<lkup_diag> lkup_diag { get; set; }
        public DbSet<lkup_exceptions> lkup_exceptions { get; set; }
        public DbSet<lkup_faclty> lkup_faclty { get; set; }
        public DbSet<lkup_gndr> lkup_gndr { get; set; }
        public DbSet<lkup_orgzn> lkup_orgzn { get; set; }
        public DbSet<lkup_rvisit> lkup_rvisit { get; set; }
        public DbSet<lkup_splmtl_diag> lkup_splmtl_diag { get; set; }
        public DbSet<lkup_splmtl_diag_cat> lkup_splmtl_diag_cat { get; set; }
        public DbSet<ov> ovs { get; set; }
        public DbSet<ov_diag> ov_diag { get; set; }
        public DbSet<raw_visit> raw_visit { get; set; }
        public DbSet<tmp_jsonvisit> tmp_jsonvisit { get; set; }
        public DbSet<tmp_visit_to_proc> tmp_visit_to_proc { get; set; }
        public DbSet<vw_diag_alert> vw_diag_alert { get; set; }
        public DbSet<vw_lkup_all_splmtl_diag> vw_lkup_all_splmtl_diag { get; set; }
        public DbSet<vw_lkup_base_splmtl_diag> vw_lkup_base_splmtl_diag { get; set; }
        public DbSet<vw_lkup_bnfcry> vw_lkup_bnfcry { get; set; }
        public DbSet<vw_lkup_chronic_diag> vw_lkup_chronic_diag { get; set; }
        public DbSet<vw_lkup_diag> vw_lkup_diag { get; set; }
        public DbSet<vw_lkup_faclty> vw_lkup_faclty { get; set; }
        public DbSet<vw_lkup_gndr> vw_lkup_gndr { get; set; }
        public DbSet<vw_lkup_injury_loc_diag> vw_lkup_injury_loc_diag { get; set; }
        public DbSet<vw_lkup_injury_mode_diag> vw_lkup_injury_mode_diag { get; set; }
        public DbSet<vw_lkup_mental_diag> vw_lkup_mental_diag { get; set; }
        public DbSet<vw_lkup_rvisit> vw_lkup_rvisit { get; set; }
        public DbSet<vw_lkup_sti_diag> vw_lkup_sti_diag { get; set; }
        public DbSet<vw_ov_details> vw_ov_details { get; set; }
        public DbSet<vw_raw_data_errs> vw_raw_data_errs { get; set; }

        /*Reports********************************************/
        public DbSet<Tables.Reports.Catalog> Catalog { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new curr_sys_infoMap());
            modelBuilder.Configurations.Add(new diag_alert_thrshldMap());
            modelBuilder.Configurations.Add(new faclty_hw_invtryMap());
            modelBuilder.Configurations.Add(new lkup_bnfcryMap());
            modelBuilder.Configurations.Add(new lkup_diagMap());
            modelBuilder.Configurations.Add(new lkup_exceptionsMap());
            modelBuilder.Configurations.Add(new lkup_facltyMap());
            modelBuilder.Configurations.Add(new lkup_gndrMap());
            modelBuilder.Configurations.Add(new lkup_orgznMap());
            modelBuilder.Configurations.Add(new lkup_rvisitMap());
            modelBuilder.Configurations.Add(new lkup_splmtl_diagMap());
            modelBuilder.Configurations.Add(new lkup_splmtl_diag_catMap());
            modelBuilder.Configurations.Add(new ovMap());
            modelBuilder.Configurations.Add(new ov_diagMap());
            modelBuilder.Configurations.Add(new raw_visitMap());
            modelBuilder.Configurations.Add(new tmp_jsonvisitMap());
            modelBuilder.Configurations.Add(new tmp_visit_to_procMap());
            modelBuilder.Configurations.Add(new vw_diag_alertMap());
            modelBuilder.Configurations.Add(new vw_lkup_all_splmtl_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_base_splmtl_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_bnfcryMap());
            modelBuilder.Configurations.Add(new vw_lkup_chronic_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_facltyMap());
            modelBuilder.Configurations.Add(new vw_lkup_gndrMap());
            modelBuilder.Configurations.Add(new vw_lkup_injury_loc_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_injury_mode_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_mental_diagMap());
            modelBuilder.Configurations.Add(new vw_lkup_rvisitMap());
            modelBuilder.Configurations.Add(new vw_lkup_sti_diagMap());
            modelBuilder.Configurations.Add(new vw_ov_detailsMap());
            modelBuilder.Configurations.Add(new vw_raw_data_errsMap());

            /*Reports*************/
            modelBuilder.Configurations.Add(new Mapping.Reports.CatalogMap());
        }

    }
}
