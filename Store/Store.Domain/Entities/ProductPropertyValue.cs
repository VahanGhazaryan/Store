using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class ProductPropertyValue
    {
        [Key]
        public int ID { get; set; }
        public string Value { get; set; }
        public int? ProductProperyId { get; set; }
        public ProductProperty ProductPropery { get; set; }
     }
}
