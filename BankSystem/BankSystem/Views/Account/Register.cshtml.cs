using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Views.Account
{
    public class RegisterViewModel : PageModel
    {
            [BindProperty]
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string Email { get; set; }

            [BindProperty]
            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [BindProperty]
            [Required(ErrorMessage = "Confirm Password is required.")]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
            public string UserId   { get; set; }
            public void OnGet()
            {
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page(); // Redisplay form with errors
                }

                // Handle registration logic here
                return RedirectToPage("/Account/Login");
            }
        }
    }


