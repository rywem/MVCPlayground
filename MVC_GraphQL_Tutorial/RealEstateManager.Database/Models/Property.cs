using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Database.Models
{
    /// <summary>
    /// https://www.youtube.com/watch?v=XoM1zHZug68&list=PLBMCyCQ4nalaWRYBDKrIOHkFK1Y5AxbrK&index=2
    /// </summary>
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal Value { get; set; }
        public string Family { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
