using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bloggy
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var BloggyUserInterface = new BloggyUserInterface();

            BloggyUserInterface.Run();



            //List<Blogpost> post = new List<Blogpost>();
            //string line = "------------------------------------------------------------------------------------------";
            //while (true)
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine($"-----------------------------------------MENU--------------------------------------------- ");
            //    Console.WriteLine();
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.WriteLine("PRESS 1 TO: LIST BLOGPOSTS. PRESS 2 TO: CHANGE TITLE OF A BLOGPOST. PRESS 3 TO: DELETE A POST");
            //    Console.WriteLine("PRESS 4 TO: CREATE A NEW POST. PRESS 5 TO EDIT COMMENTS. AND PRESS 0 TO QUIT! ");
            //    Console.ForegroundColor = ConsoleColor.White;
            //    string Input = Console.ReadLine();
            //    if (Input == "0")
            //    {
            //        break;
            //    }

            //    switch (Input)
            //    {
            //        case "1":
            //            Console.Clear();
            //            Console.WriteLine(line);
            //            BloggyDataRepository.GetBlogPosts(sqlConnectionString);
            //            Console.WriteLine(line);
            //            break;

            //        case "2":
            //            Console.Clear();
            //            Console.WriteLine(line);
            //            BloggyDataRepository.GetBlogPosts(sqlConnectionString);
            //            Console.WriteLine(line);
            //            BloggyDataRepository.ChangeBlogPost(sqlConnectionString);
            //            Console.WriteLine(line);
            //            break;

            //        case "3":
            //            Console.Clear();
            //            Console.WriteLine(line);
            //            BloggyDataRepository.GetBlogPosts(sqlConnectionString);
            //            Console.WriteLine(line);
            //            BloggyDataRepository.DeletePost(sqlConnectionString);
            //            Console.WriteLine(line);
            //            break;

            //        case "4":
            //            Console.Clear();
            //            Console.WriteLine(line);
            //            BloggyDataRepository.GetBlogPosts(sqlConnectionString);
            //            Console.WriteLine(line);
            //            BloggyDataRepository.CreatePost(sqlConnectionString);
            //            Console.WriteLine(line);
            //            break;
            //        case "5":
            //            Console.Clear();
            //            Comments(sqlConnectionString);
            //            break;
            //        default:
            //            Console.WriteLine("ENTER A VALID COMMAND!");
            //            break;
        }
    

        //static void Display()
        //{
        //    // implementera metoden som visar gränssnittet istället för att ha allt i samma metod.    
        //    //
        //    //List<Blogpost> post = new List<Blogpost>();
        //    //foreach (var posta in post)
        //    //{

        //    //}
        //}
       
//        static void Comments(string sqlConnectionstring)
//        {
//            string line = "------------------------------------------------------------------------------------------";
//            while (true)
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine($"-----------------------------COMMENT MENU----------------------------------------");
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine();
//                Console.WriteLine($"PRESS: 1 TO VIEW COMMENTS PRESS: 2 TO ADD A COMMENT. PRESS: 2 TO EDIT A COMMENT. ");
//                Console.WriteLine($"PRESS: 3 TO REMOVE A COMMENT PRESS 4 TO VIEW BLOGPOSTS COMMENTS OR 0 TO RETURN TO MENU.");
//                Console.ForegroundColor = ConsoleColor.White;

//                int input2 = int.Parse(Console.ReadLine());
//                if (input2 == 0)
//                {
//                    Console.Clear();
//                    break;
//                }
//                switch (input2)
//                {
//                    case 1:
//                        Console.Clear();
//                        GetComments(sqlConnectionstring);
//                        break;
//                    case 2:
//                        Console.Clear();
//                        Console.WriteLine("BLOG POSTS");
//                        BloggyDataRepository.GetBlogPosts(sqlConnectionstring);
//                        Console.WriteLine(line);
//                        Console.WriteLine("COMMENTS");
//                        GetComments(sqlConnectionstring);
//                        Console.WriteLine(line);
//                        CreateComments(sqlConnectionstring);
//                        break;
//                    case 3:
//                        Console.Clear();
//                        GetComments(sqlConnectionstring);
//                        Console.WriteLine(line);
//                        DeleteComment(sqlConnectionstring);
//                        break;
//                    case 4:
//                        Console.Clear();
//                        BloggyDataRepository.GetBlogPosts(sqlConnectionstring);
//                        Console.WriteLine(line);
//                        ShowComments(sqlConnectionString);
//                        break;
//                }


//            }
//        }
//        static void GetComments(string sqlConnectionstring)
//        {
//            List<comments> Comments = new List<comments>();

//            using (SqlConnection sqlconnection = new SqlConnection(sqlConnectionstring))
//            {
//                sqlconnection.Open();
//                string SqlQuery = "Select * from Comment";

//                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
//                var reader = sqlCommand.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.WriteLine($"Id: {reader[0]} Author: {reader[1]} DateTime: {reader[2]} Comment: {reader[3]} BlogPost: {reader[4]}");
//                }


//            }
//        }

//        static List<comments> CreateComments(string sqlConnectionstring)
//        {
//            List<comments> comments = new List<comments>();
//            using (SqlConnection sqlconnection = new SqlConnection(sqlConnectionString))
//            {
//                sqlconnection.Open();
//                Console.WriteLine("Wich blog post do you want to comment?");
//                int blogpost = int.Parse(Console.ReadLine());

//                Console.Write("Enter author: ");
//                string author = Console.ReadLine();

//                Console.Write("Enter your comment: ");
//                string content = Console.ReadLine();
//                DateTime date = DateTime.Now;

//                string SqlQuery = $"Insert Comment(author, DateTime, CommentText, BlogPostID) values(@Author, '{date}', @content, @blogPostid)";

//                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
//                sqlCommand.Parameters.Add(new SqlParameter("@blogPostid", blogpost));
//                sqlCommand.Parameters.Add(new SqlParameter("@Author", author));
//                sqlCommand.Parameters.Add(new SqlParameter("@Content", content));

//                var reader = sqlCommand.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.WriteLine($"Id: {reader[0]} Title: {reader[1]} Author: {reader[2]} Created: {reader[3]} BlogPost: {reader[4]} Updated: {reader[5]}");
//                }
//                return comments;
//            }
//        }
//        static void DeleteComment(string SqlConnectionstring)
//        {
//            using (SqlConnection sqlconnection = new SqlConnection(sqlConnectionString))
//            {
//                sqlconnection.Open();
//                Console.WriteLine("Wich comment do you want to DELETE?");

//                int WichPost = int.Parse(Console.ReadLine());
//                string SqlQuery = $"DELETE FROM comment WHERE id = @wichpost";

//                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
//                sqlCommand.Parameters.Add(new SqlParameter("@wichpost", WichPost));

//                var reader = sqlCommand.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.WriteLine($"Id: {reader[0]} Title: {reader[1]} Author: {reader[2]} Created: {reader[3]} BlogPost: {reader[4]} Updated: {reader[5]}");
//                }
//            }


//        }
//        static void ShowComments(string sqlConnectionstring)
//        {
//            Console.WriteLine("Wich blog posts comment do you want to see?");
//            int uInput = int.Parse(Console.ReadLine());

//            using (SqlConnection sqlconnection = new SqlConnection(sqlConnectionstring))
//            {
//                sqlconnection.Open();
//                string SqlQuery = "select * from BlogPost inner join Comment on Comment.BlogPostID = BlogPost.id where BLOGPOST.id = @wichpost";

//                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
//                sqlCommand.Parameters.Add(new SqlParameter("@wichpost", uInput));
//                var reader = sqlCommand.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.WriteLine($"Id: {reader[0]} Author: {reader[1]} DateTime: {reader[2]} Comment: {reader[3]}");
//                }
//            }
       //}
    }
}



