using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj.Models
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<string> Editors { get; set; }
        public virtual ICollection<string> Authors { get; set; }
        public virtual ICollection<string> Referees { get; set; }
        //Virtual anahtar kelimesi entity framework'de magazine.Reviews olarak erismek icin
        public virtual ICollection<MagazineReview> Reviews { get; set; }
    }
}