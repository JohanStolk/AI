using System.Text.RegularExpressions;

namespace Eonics.AI.Core;

public static class FirstComponent
{
    public static bool ValidateEmail(string email)
    {
        // Regular expression pattern for email validation
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        // Check if the email matches the pattern
        return Regex.IsMatch(email, pattern);
    }
}

