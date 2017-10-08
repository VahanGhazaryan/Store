using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class User : ModelBase
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
