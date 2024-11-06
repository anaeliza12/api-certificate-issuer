using Api.Certification.AppDomain.Model;
using Api.Certification.AppDomain.Utils.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Api.Certification.Infra.ApiSettings.Repositories.Context
{
    public class MySQLContext(DbContextOptions<MySQLContext> options) : DbContext(options)
    {
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<PdfFileModel> PdfFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = DBConfig.DefaultConnection;
            options.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentModel>()
       .ToTable("students");

            modelBuilder.Entity<StudentModel>()
                .HasKey(s => s.Id);
        }
    }
}
