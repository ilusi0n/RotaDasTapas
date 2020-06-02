using System.Collections.Generic;

namespace RotaDasTapas.Models.Gateway
{
    public class TapaDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Path> Path { get; set; }
    }
}