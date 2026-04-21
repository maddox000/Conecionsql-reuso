using ConexionSql.Models.A_PAN_OPC;
using ConexionSql.Models.Acondicionado;
using ConexionSql.Models.Entrega;
using ConexionSql.Models.Equipos;
using ConexionSql.Models.Estados;
using ConexionSql.Models.IbPer;
using ConexionSql.Models.Lavado;
using ConexionSql.Models.Materiales;
using ConexionSql.Models.Procesos;
using ConexionSql.Models.Procesos.Controles;
using ConexionSql.Models.Recepciones;
using ConexionSql.Models.Reuso;
using ConexionSql.Models.Reusos;
using ConexionSql.Models.Sectores;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Models.Procesos.Controles;


namespace ConexionSql.Data
{
    public class ConexionSqlContext : DbContext
    {
        public ConexionSqlContext(DbContextOptions<ConexionSqlContext> options)
            : base(options)
        {
        }

        // Nombres exactos que usa el proyecto
        public DbSet<IbPer> IbPers { get; set; }
        public DbSet<IbPerUni> IbPerUni { get; set; }
        public DbSet<IbPerCar> IbPerCar { get; set; }
        public DbSet<IbSec> IbSectores { get; set; }
        public DbSet<TbPro> TbPro { get; set; }
        public DbSet<TbProDet> TbProDet { get; set; }
        public DbSet<TbRec> TbRec { get; set; }
        public DbSet<IbMat> IbMat { get; set; }
        public DbSet<TbRecDet> TbRecDet { get; set; }
        public DbSet<IbEst> IbEst { get; set; }
        public DbSet<TbProAco> TbProAco { get; set; }
        public DbSet<TbProAcoDet> TbProAcoDet { get; set; }
        public DbSet<IbEqu> IbEqu { get; set; }
        public DbSet<IbEquPti> IbEquPti { get; set; }
        public DbSet<IbProTci> IbProTci { get; set; }
        public DbSet<TbEnt> TbEnt { get; set; }
        public DbSet<TbEntDet> TbEntDet { get; set; }
        public DbSet<TbProLav> TbProLav { get; set; }
        public DbSet<TbProLavDet> TbProLavDet { get; set; }
        public DbSet<IbLavLti> IbLavLti { get; set; }
        public DbSet<IbLavTci> IbLavTci { get; set; }
        public DbSet<IbMatRev> IbMatRevisiones { get; set; }
        public DbSet<IbMatEti> IbMatEti { get; set; }
        public DbSet<TbReu> TbReu { get; set; }
        public DbSet<APanOpc> APanOpc { get; set; }
        public DbSet<IbProEst> IbProEst { get; set; }
        public DbSet<IbEstPro> IbEstPro { get; set; }
        public DbSet<TbReuPac> TbReuPac { get; set; }
        public DbSet<TbProPte> TbProPte { get; set; }
        public DbSet<TbProPteUbi> TbProPteUbi { get; set; }
        public DbSet<TbProDetPte> TbProDetPte { get; set; }
        public DbSet<TbProPteRes> TbProPteRes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IbPer>(entity =>
            {
                entity.ToTable("IB_PER");
                entity.HasKey(e => e.IbPerId);
            });

            modelBuilder.Entity<IbPerUni>(entity =>
            {
                entity.ToTable("IB_PER_UNI");
                entity.HasKey(e => e.IbPerUniId);
            });

            modelBuilder.Entity<IbPerCar>(entity =>
            {
                entity.ToTable("IB_PER_CAR");
                entity.HasKey(e => e.IbPerCarId);
            });

            modelBuilder.Entity<IbSec>(entity =>
            {
                entity.ToTable("IB_SEC");
                entity.HasKey(e => e.IbSecId);
            });

            modelBuilder.Entity<TbPro>(entity =>
            {
                entity.ToTable("TB_PRO");
                entity.HasKey(e => e.TbProId);
            });

            modelBuilder.Entity<TbRec>(entity =>
            {
                entity.ToTable("TB_REC");
                entity.HasKey(e => e.TbRecId);
            });

            modelBuilder.Entity<TbRecDet>(entity =>
            {
                entity.ToTable("TB_REC_DET");
                entity.HasKey(e => e.TbRecDetId);
            });

            modelBuilder.Entity<TbEnt>(entity =>
            {
                entity.ToTable("TB_ENT");
                entity.HasKey(e => e.TbEntId);
            });

            modelBuilder.Entity<TbEntDet>(entity =>
            {
                entity.ToTable("TB_ENT_DET");
                entity.HasKey(e => e.TbEntDetId);
            });


        }
    }
}
