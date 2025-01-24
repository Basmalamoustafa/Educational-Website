using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace database.Pages
{
    public class PaymentModel : PageModel
    {
        public IActionResult OnPost(string name, string cardnumber, string expmonth, string expyear, string cvv)
        {
            // Perform validations on the form fields
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("Name", "Name is required.");
            }

            // Validate card number length (example: should be 16 digits)
            if (cardnumber?.Length != 16)
            {
                ModelState.AddModelError("CardNumber", "Card number must be 16 digits.");
            }

            // You can add more validations for expiration month, year, CVV, etc.

            // Check if there are model errors
            if (!ModelState.IsValid)
            {
                // If there are validation errors, return the page with the errors
                return Page();
            }

            // If the model is valid, process the payment (send to your payment processor)
            // This is where you would typically interact with your payment gateway or perform further actions

            try
            {
                // Code to process payment (communicate with payment processor, etc.)
                // This is where you will handle the payment processing logic

                // Redirect to a success page if the payment is successful
                return RedirectToPage("/Home");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during payment processing
                ModelState.AddModelError(string.Empty, "Payment processing failed. Please try again later.");
                // You might log the exception for further investigation
                return Page();
            }
        }
    }
}
