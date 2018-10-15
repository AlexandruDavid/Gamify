using Gamify.Models;
using System.Collections.Generic;

namespace Gamify.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }  
    }
}