namespace prj.Migrations
{
    using prj.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<prj.Models.MagazineDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "prj.Models.MagazineDb";
        }

        protected override void Seed(MagazineDb context)
        {
            context.Magazines.AddOrUpdate(r => r.Name,
                new Magazine { Name = "Arkakapi", Country = "Turkey" },
                new Magazine { Name = "Backdoor", Country = "UnitedKingdom",
                    Reviews = new List<MagazineReview>()
                {
                    new MagazineReview() { ReviewerName="Hakan", Body="Guzel bir dergi", Rating=9}
                }
                });

            for (int i = 0; i < 1000; i++)
            {
                context.Magazines.AddOrUpdate(r => r.Name,
                    new Magazine { Name= i.ToString(), Country="Turkey",
                //        Reviews = new List<MagazineReview>()
                //{
                //    new MagazineReview() { Rating=i%10, Body="Good"+i, ReviewerName="Anonymous"}
                //}
                });
            }
        }
    }
}
