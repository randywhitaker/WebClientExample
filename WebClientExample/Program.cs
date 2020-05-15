using System;
using System.Net;
using System.IO;

namespace RandyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string sitename = String.Empty;

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please secify a URL site to retrieve...");
                sitename = Console.ReadLine();
                //throw new ApplicationException ("Specify the URI of the resource to retrieve.");
            }
            else
            {
                sitename = args[0];
            }
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(sitename);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            string pageBody = s.Substring(s.ToLower().IndexOf("<body"));
            pageBody = pageBody.Substring(pageBody.IndexOf(">") + 1);
            pageBody = pageBody.Substring(0, pageBody.ToLower().IndexOf("</body>"));
            pageBody = pageBody.Trim();

            Console.WriteLine();
            Console.WriteLine(pageBody);
            data.Close();
            reader.Close();
        }
    }
}
