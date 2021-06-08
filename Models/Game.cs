using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [ForeignKey("OsSystem")]
        public int SystemId { get; set; }
        public OsSystem OsSystem { get; set; }
        public ICollection<GameExtra> GamesExtras { get; set; }
    }
}
