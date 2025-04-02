namespace FizzBuzzApp.Models
{
    public class FizzBuzzResult
    {
        public int Number { get; set; }
        public string Output { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public bool IsFizz { get; set; }
        public bool IsBuzz { get; set; }
        public bool IsFizzBuzz { get; set; }
    }
}
