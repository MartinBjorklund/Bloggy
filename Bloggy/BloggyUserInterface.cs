using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggy
{
    public class BloggyUserInterface
    {

        private readonly BloggyDataRepository bloggyDataRepository = new BloggyDataRepository();

        public void Run()
        {
            DisplayMenu();
        }


        private void DisplayMenu()
        {
            List<Blogpost> post = new List<Blogpost>();
            string line = "------------------------------------------------------------------------------------------";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"-----------------------------------------MENU--------------------------------------------- ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("PRESS 1 TO: LIST BLOGPOSTS. PRESS 2 TO: CHANGE TITLE OF A BLOGPOST. PRESS 3 TO: DELETE A POST");
                Console.WriteLine("PRESS 4 TO: CREATE A NEW POST. PRESS 5 TO EDIT COMMENTS. AND PRESS 0 TO QUIT! ");
                Console.ForegroundColor = ConsoleColor.White;
                string Input = Console.ReadLine();
                if (Input == "0")
                {
                    break;
                }

                switch (Input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(line);
                        DisplayAllPosts(true);
                        Console.WriteLine(line);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(line);
                        DisplayAllPosts(true);
                        Console.WriteLine(line);
                        BloggyDataRepository.ChangeBlogPost();
                        Console.WriteLine(line);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine(line);
                        DisplayAllPosts(true);
                        Console.WriteLine(line);
                        BloggyDataRepository.DeletePost();
                        Console.WriteLine(line);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(line);
                        DisplayAllPosts(true);
                        Console.WriteLine(line);
                        BloggyDataRepository.CreatePost();
                        Console.WriteLine(line);
                        break;
                    case "5":
                        Console.Clear();
                        //Comments();
                        break;
                    default:
                        Console.WriteLine("ENTER A VALID COMMAND!");
                        break;
                }
            }

            void DisplayAllPosts(bool listAllData)
            {
                List<Blogpost> blogposts = bloggyDataRepository.GetBlogPosts(listAllData);
                foreach (var blogpost in blogposts)
                {
                    Console.WriteLine($"Id: {blogpost.Id} Author: {blogpost.Author} Date: {blogpost.Date} Content: {blogpost.Description} Updated: {blogpost.Updated}");
                }

            }
            //Id = reader.GetInt32(0),
            //            Title = reader.GetString(1),
            //            Author = reader.GetString(2),
            //            Date = reader.GetDateTime(3),
            //            Description = reader.GetString(4),
            //            Updated = reader.GetString(5),

        }
    }
    
}
