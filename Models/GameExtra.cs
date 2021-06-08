using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameExtra
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public int ExtraId { get; set; }
        public Game Game { get; set; }
        public Extra Extra { get; set; }
    }
}
