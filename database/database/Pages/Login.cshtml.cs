using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using database.Models; // Replace with the correct namespace for your Login model

namespace database.Pages
{
    public class LoginModel : PageModel
    {
        private readonly Login loginModel;

        public bool IsLoggedIn { get; private set; }

        public LoginModel()
        {
            loginModel = new Login();
        }

        public IActionResult OnPost(string username, string password)
        {
            IsLoggedIn = loginModel.CheckLogin(username, password);

            if (IsLoggedIn)
            {
                // Redirect to a success page or perform other actions upon successful login
                return RedirectToPage("/Home");
            }
            else
            {
                // Set a message or perform actions to indicate login failure
                TempData["ErrorMessage"] = "Invalid username or password.";
                return Page(); // Return to the login page with an error message
            }
        }
    }
}
