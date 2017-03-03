using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_movie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciation du context
            DataModelContainer context = new DataModelContainer();

            // Instanciation de la classe User et creation d'un user factice
            User user = new User();

            // var query = context.UserSet.Where(u => u.Login.Contains("r")).ToList();

            // Console.WriteLine(query);

            user.Login  = "Patrick";
            user.Password = "azerty123";
            user.Name = "Pierre";
            user.Surname = "Leblanc";

            // Add from context user in UserSet collection
            context.UserSet.Add(user);

            // Add user to database
            context.SaveChanges();

        }
    }
}
