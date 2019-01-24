using System;
namespace Medicabio.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Uuid { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Description { get; set; }
        public int Pack { get; set; }
        public string ArticleNumber { get; set; }
        public Price Price { get; set; }
    }
}
