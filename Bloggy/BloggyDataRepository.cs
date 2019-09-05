using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Bloggy
{
    public class BloggyDataRepository
    {
        public const string sqlConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SuperBloggy;Integrated Security=True";


        public  List<Blogpost> GetBlogPosts(bool Post)
        {
            List<Blogpost> posts = new List<Blogpost>();

            using (SqlConnection sqlconnection = new SqlConnection())
            {
                sqlconnection.Open();
                string SqlQuery = "Select * from BLOGPOST";

                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Blogpost blogpost = new Blogpost
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        Date = reader.GetDateTime(3),
                        Description = reader.GetString(4),
                        Updated = reader.GetString(5),
                    };

                    posts.Add(blogpost);
                }
            }
            return posts;
        }
        public static void ChangeBlogPost()
        {

            using (SqlConnection sqlconnection = new SqlConnection())
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"-----------------------------------UPDATE MENU--------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("PRESS 1: TO UPDATE TITLE PRESS 2: TO UPDATE AUTHOR PRESS 3: TO UPDATE CONTENT ");
                    Console.WriteLine($"                      OR PRESS 0 TO RETURN HOME                              ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string Choice = Console.ReadLine();
                    sqlconnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlconnection;

                    if (Choice == "0")
                    {
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine("WHICH BLOGPOST DO YOU WANT TO UPDATE?");
                    int WichPost = int.Parse(Console.ReadLine());


                    switch (Choice)
                    {
                        case "1":
                            Console.WriteLine("What should the new title say?");
                            string updateTitle = Console.ReadLine();
                            sqlCommand.CommandText = "Update blogpost set title = @updateTitle where id = @wichPost";
                            sqlCommand.Parameters.Add(new SqlParameter("@updateTitle", updateTitle));
                            break;

                        case "2":
                            Console.WriteLine("Who is the new author?");
                            string updateAuthor = Console.ReadLine();
                            sqlCommand.CommandText = "Update blogpost set author = @updateAuthor where id = @wichPost";
                            sqlCommand.Parameters.Add(new SqlParameter("@updateAuthor", updateAuthor));
                            break;

                        case "3":
                            Console.WriteLine("Enter the new Content");
                            string updateContent = Console.ReadLine();
                            sqlCommand.CommandText = "Update blogpost set description = @updateContent where id = @wichPost";
                            sqlCommand.Parameters.Add(new SqlParameter("@UpdateContent", updateContent));
                            break;

                        default:
                            break;

                    }

                    sqlCommand.Parameters.Add(new SqlParameter("@wichpost", WichPost));

                    sqlCommand.ExecuteNonQuery();

                }
            }
        }
        public static void DeletePost()
        {
            using (SqlConnection sqlconnection = new SqlConnection())
            {
                sqlconnection.Open();
                Console.WriteLine("Which blogpost title do you want to DELETE?");

                int WichPost = int.Parse(Console.ReadLine());
                string SqlQuery = $"DELETE FROM BLOGPOST WHERE id = @wichpost DELETE FROM COMMENT WHERE BLOGPOSTID = @WICHPOST ";

                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
                sqlCommand.Parameters.Add(new SqlParameter("@wichpost", WichPost));

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} Title: {reader[1]} Author: {reader[2]} Created: {reader[3]} BlogPost: {reader[4]} Updated: {reader[5]}");
                }
            }
        }
        public static void CreatePost()
        {
            using (SqlConnection sqlconnection = new SqlConnection())
            {
                sqlconnection.Open();

                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                Console.WriteLine("Enter your content: ");
                string content = Console.ReadLine();
                DateTime date = DateTime.Now;

                string SqlQuery = $"Insert blogpost(title, author, created, description, updated) values(@Title, @Author, '{date}', @content, '{date}')";

                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlconnection);
                sqlCommand.Parameters.Add(new SqlParameter("@Title", title));
                sqlCommand.Parameters.Add(new SqlParameter("@Author", author));
                sqlCommand.Parameters.Add(new SqlParameter("@Content", content));

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} Title: {reader[1]} Author: {reader[2]} Created: {reader[3]} BlogPost: {reader[4]} Updated: {reader[5]}");
                }
            }
        }
    }
}
