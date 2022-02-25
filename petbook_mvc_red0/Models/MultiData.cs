using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petbook_mvc_red0.Models
{
    public class MultiData
    {
        public List<Found> found_details { get; set; }
        public List<Lost> lost_details { get; set; }
        public List<Adoption> adoption_details { get; set; }
    }
}