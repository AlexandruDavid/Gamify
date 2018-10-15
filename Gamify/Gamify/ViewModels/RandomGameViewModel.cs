using Gamify.Models;
using System.Collections.Generic;

namespace Gamify.ViewModels
{
    public class RandomGameViewModel
    {
        public Game Game { get; set; }
        public List<Customer> Customers { get; set; }
    }
}