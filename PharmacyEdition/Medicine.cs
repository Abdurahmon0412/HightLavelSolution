using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyEdition
{
    public class Medicine
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LeftCount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Medicine( string name, decimal price,
            DateTime expirationDate, DateTime createdAt)
        {
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            CreatedAt = createdAt;
            UpdatedAt = new DateTime();
        }
    }
}
