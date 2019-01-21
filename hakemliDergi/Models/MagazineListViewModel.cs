using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj.Models
{
    public class MagazineListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int CountOfReviews { get; set; }
    }
}