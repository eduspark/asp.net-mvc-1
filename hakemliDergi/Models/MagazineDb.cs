using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prj.Models
{
    public class MagazineDb : DbContext //for DbContext download Entity framework from Nuget
    {

        public MagazineDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<MagazineReview> Reviews { get; set; }
    }
}