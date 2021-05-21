using System.Text.RegularExpressions;

namespace OESP.Domain.Validates
{
    public static class EmailValidate
    {
        static Regex _mailRx = new Regex(
        @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

        public static bool EmailIsValid(string email)
        {
            return (_mailRx.IsMatch(email)? true:false);
        }
    }
}