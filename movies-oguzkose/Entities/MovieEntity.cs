using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_oguzkose.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public int ReleaseYear { get; set; }
        public string Writer { get; set; }
        public string Category { get; set; }
        public string ImdbUrl { get; set; }
        public decimal Score { get; set; }
        public int Review { get; set; }
    }
}
