using System;
namespace Medicabio.Models
{
    public class ItemProduct
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        private string Created { get; set; }
        private string Updated { get; set; }
        private Product Product { get; set; }
        private long Quantity { get; set; }

    }
}
