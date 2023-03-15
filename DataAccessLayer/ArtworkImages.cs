using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ArtworkImages
    {
        public int ID { get; set; }
        public int ArtworkID { get; set; }
        public string AltText { get; set; }
        public string ImagePath { get; set; }
        public bool IsCover { get; set; }
    }
}
