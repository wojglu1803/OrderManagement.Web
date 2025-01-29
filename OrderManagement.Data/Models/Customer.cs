using System.Collections.Generic;

namespace OrderManagement.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Inicjalizacja listy domyślną wartością
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
