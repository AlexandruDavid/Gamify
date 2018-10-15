using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamify.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> GameIds { get; set; }
    }
}