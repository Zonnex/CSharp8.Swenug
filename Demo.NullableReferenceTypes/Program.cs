using System;

#nullable disable

namespace Demo.NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string nullString = null;
            string name = GetName();

            _ = nullString.Length;
            _ = name.Length;

            User user = new User();
            user.Email = NormalizeEmail(user.Email);
        }

        static string GetName()
        {
            return "Hello";
        }

        static string NormalizeEmail(string email)
        {
            return email.ToUpper();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string UserName { get; set; }
    }
}
