using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;

namespace IP3Project.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string ReportTitle { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Reporter { get; set; }
        public string Details { get; set; }

        public string Priority { get; set; }

    }

    public class ReportDBContext : DbContext
    {
        public ReportDBContext()
        {
            Database.SetInitializer<ReportDBContext>
                (new MigrateDatabaseToLatestVersion<ReportDBContext,
                    IP3Project.Migrations.Configuration>());
        }
        public DbSet<Report> Reports { get; set; }
    }
}
