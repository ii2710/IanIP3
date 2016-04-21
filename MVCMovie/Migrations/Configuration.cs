namespace IP3Project.Migrations
{
    using IP3Project.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IP3Project.Models.ReportDBContext>
    {
        public Configuration()
        {
          AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IP3Project.Models.ReportDBContext context)
        {
            context.Reports.AddOrUpdate(i => i.ReportTitle,
                new Report
                {
                    ReportTitle = "Wiring Issues",
                    Date = DateTime.Parse("2016-1-11"),
                    Reporter = "Jim Devo",
                    Details = "Faulty Wiring, also im working with idiot.",
                    ID = 1
                },

                 new Report
                 {
                     ReportTitle = "Door Loose",
                     Date = DateTime.Parse("2015-12-1"),
                     Reporter = "Tim Gualt",
                     Details = "Door Feels loose ps, send halp",
                     ID = 2
                 },

                 new Report
                 {
                     ReportTitle = "Cracked Window",
                     Date = DateTime.Parse("2016-1-1"),
                     Reporter = "Tim Gault",
                     Details = "A crack has appeared in the window, needs immediate sorting. i think alan's been trying to get in again.",
                     ID = 3
                 },

               new Report
               {
                   ReportTitle = "Coffee machine f****d",
                   Date = DateTime.Parse("2016-3-11"),
                   Reporter = "Alan Alan",
                   Details = "Caffiene supplies running low, tim is looking tasty",
                   ID = 4
               }
           );

        }

    }
}
