using System.ComponentModel.DataAnnotations;

namespace BabyStoreCore.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }
        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
