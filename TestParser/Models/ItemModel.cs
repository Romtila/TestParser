using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDb.Models
{
    public class ItemModel : Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ItemModel(Item item)
        {
            Title = item.Title;
            Price = item.Price;
            City = item.City;
            ItemRef = item.ItemRef;
            PhotoRef = item.PhotoRef;
        }

        public ItemModel()
        {
        }
    }
}
