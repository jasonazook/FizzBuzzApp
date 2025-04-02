using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using FizzBuzzApp.Models;

namespace FizzBuzzApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        [Display(Name = "Start Number")]
        [Range(1, 1000, ErrorMessage = "Please enter a number between 1 and 1000.")]
        public int Start { get; set; } = 1;

        [BindProperty]
        [Display(Name = "End Number")]
        [Range(1, 1000, ErrorMessage = "Please enter a number between 1 and 1000.")]
        public int End { get; set; } = 100;

        public List<FizzBuzzResult> Results { get; set; } = new List<FizzBuzzResult>();

        public void OnGet()
        {
            // Default page load, no calculation yet
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Validate that Start is less than or equal to End
            if (Start > End)
            {
                ModelState.AddModelError("Start", "Start number must be less than or equal to End number.");
                return Page();
            }

            // Calculate FizzBuzz results
            Results = CalculateFizzBuzz(Start, End);
            return Page();
        }

        private List<FizzBuzzResult> CalculateFizzBuzz(int start, int end)
        {
            var results = new List<FizzBuzzResult>();

            for (int i = start; i <= end; i++)
            {
                bool isDivisibleBy3 = i % 3 == 0;
                bool isDivisibleBy5 = i % 5 == 0;

                string output;
                string explanation;
                bool isFizz = false;
                bool isBuzz = false;
                bool isFizzBuzz = false;

                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    output = "FizzBuzz";
                    explanation = $"{i} is divisible by both 3 and 5";
                    isFizzBuzz = true;
                }
                else if (isDivisibleBy3)
                {
                    output = "Fizz";
                    explanation = $"{i} is divisible by 3";
                    isFizz = true;
                }
                else if (isDivisibleBy5)
                {
                    output = "Buzz";
                    explanation = $"{i} is divisible by 5";
                    isBuzz = true;
                }
                else
                {
                    output = i.ToString();
                    explanation = $"{i} is not divisible by 3 or 5";
                }

                results.Add(new FizzBuzzResult
                {
                    Number = i,
                    Output = output,
                    Explanation = explanation,
                    IsFizz = isFizz,
                    IsBuzz = isBuzz,
                    IsFizzBuzz = isFizzBuzz
                });
            }

            return results;
        }
    }
}
