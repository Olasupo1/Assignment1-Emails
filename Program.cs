using System;
using System.Collections.Generic;

namespace Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new string[]
            {
                "dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"
            };

            System.Console.WriteLine(UniqueEmails(array));
        }

        private static int UniqueEmails(string[] array)
        {
            // using HashSet to store the unique email addresses
            var uniqueEmails = new HashSet<string>();

            foreach(string value in array)
            {
                var split = value.Split("@");

                // sanitize the "local name" part by reemoving ".", and every character after "plus"
                var sanitized =  SanitizePlus(SanitizeDot(split[0]));
                var email = sanitized + "@" + split[1];
                uniqueEmails.Add(email);
            }

            return uniqueEmails.Count;
        }



        private static string SanitizePlus(string value)
        {
            return value.Split('+')[0];
        }

        private static string SanitizeDot(string value)
        {
            return value.Replace(".", "");
        }
    }
}
