using System;
using System.Collections.Generic;

namespace OrderManagement.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }

        // Zmiana właściwości na nullable
        public Customer? Customer { get; set; }

        // Inicjalizacja listy domyślną wartością
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
