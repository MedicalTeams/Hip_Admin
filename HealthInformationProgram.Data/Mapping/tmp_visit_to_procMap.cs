using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Mapping
{
    public class tmp_visit_to_procMap : EntityTypeConfiguration<tmp_visit_to_proc>
    {
        public tmp_visit_to_procMap()
        {
            // Primary Key
            this.HasKey(t => t.visit_to_proc_id);

            // Properties
            this.Property(t => t.visit_uuid)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.staff_mbr_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.oth_diag_descn)
                .HasMaxLength(100);

            this.Property(t => t.oth_splmtl_diag_descn)
                .HasMaxLength(100);

            this.Property(t => t.proc_stat)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.rec_creat_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.rec_updt_user_id_cd)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("tmp_visit_to_proc");
            this.Property(t => t.visit_uuid).HasColumnName("visit_uuid");
            this.Property(t => t.bnfcry_id).HasColumnName("bnfcry_id");
            this.Property(t => t.faclty_id).HasColumnName("faclty_id");
            this.Property(t => t.faclty_hw_invtry_id).HasColumnName("faclty_hw_invtry_id");
            this.Property(t => t.gndr_id).HasColumnName("gndr_id");
            this.Property(t => t.splmtl_diag_cat_id).HasColumnName("splmtl_diag_cat_id");
            this.Property(t => t.rvisit_id).HasColumnName("rvisit_id");
            this.Property(t => t.opd_id).HasColumnName("opd_id");
            this.Property(t => t.infnt_age_mos).HasColumnName("infnt_age_mos");
            this.Property(t => t.staff_mbr_name).HasColumnName("staff_mbr_name");
            this.Property(t => t.cntct_trmnt_cnt).HasColumnName("cntct_trmnt_cnt");
            this.Property(t => t.dt_of_visit).HasColumnName("dt_of_visit");
            this.Property(t => t.diag_id).HasColumnName("diag_id");
            this.Property(t => t.splmtl_diag_id).HasColumnName("splmtl_diag_id");
            this.Property(t => t.oth_diag_descn).HasColumnName("oth_diag_descn");
            this.Property(t => t.oth_splmtl_diag_descn).HasColumnName("oth_splmtl_diag_descn");
            this.Property(t => t.proc_stat).HasColumnName("proc_stat");
            this.Property(t => t.err_cd).HasColumnName("err_cd");
            this.Property(t => t.rec_creat_dt).HasColumnName("rec_creat_dt");
            this.Property(t => t.rec_creat_user_id_cd).HasColumnName("rec_creat_user_id_cd");
            this.Property(t => t.rec_updt_dt).HasColumnName("rec_updt_dt");
            this.Property(t => t.rec_updt_user_id_cd).HasColumnName("rec_updt_user_id_cd");
            this.Property(t => t.visit_to_proc_id).HasColumnName("visit_to_proc_id");
        }
    }
}
