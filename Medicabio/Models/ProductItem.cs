using System;
using SQLite;

namespace Medicabio.Models
{
    public class ProductItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
    }
}
