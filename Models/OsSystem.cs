using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OsSystem
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
