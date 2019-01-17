using System;
using System.Collections.Generic;

namespace Medicabio.Models
{
    public class Quote
    {
        public string Id { get; set; } //NOTA BENE: non mettere MAI privati gli attributi sennò il bindingi non funziona con la vista...ovviamente.
        public string Uuid { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Status { get; set; }
        public List<ItemProduct> ItemProducts { get; set; }
    }
}
