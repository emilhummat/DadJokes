using System.ComponentModel.DataAnnotations;

namespace DadJokes.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }




    }
}
