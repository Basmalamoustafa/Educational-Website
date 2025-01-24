using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using database.Models; // Assuming DB class is in this namespace

public class RegisterModel : PageModel
{
	[BindProperty]
	public string Username { get; set; }

	[BindProperty]
	public string Email { get; set; }

	[BindProperty]
	public string Password { get; set; }

	public IActionResult OnPost()
	{
		// Instantiate DB class
		DB db = new DB();

		// Call InsertUser method with user input
		db.InsertUser(Username, Email, Password);

		// Redirect to another page after successful insertion
		return RedirectToPage("/Home");
	}
}
