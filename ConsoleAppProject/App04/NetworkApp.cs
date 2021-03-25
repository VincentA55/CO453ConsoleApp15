using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
   public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();

        /// <summary>
        /// Displays the menu for the NewsFeed
        /// </summary>
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading(" Vinnys News Feed  ");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Display All Posts"
                ,"Comment", "Search by author","Remove post", "Like post", "Unlike post", "Quit"
            };

            bool finished = false;

            do
            {
                int amountOfPosts = news.posts.Count;

                switch (ConsoleHelper.SelectChoice(choices))
                {
                    case 1:
                        PostMessage(ConsoleHelper.InputString("Author:"), ConsoleHelper.InputString("Message:")) ;
                        break;

                    case 2:
                        PostImage(ConsoleHelper.InputString("Author:"),ConsoleHelper.InputString("File:"), ConsoleHelper.InputString("Caption:"));
                        break;

                    case 3:
                        if (amountOfPosts < 1)
                        {
                            Console.WriteLine("No posts to display");
                        }
                        else
                        {
                            DisplayAll();
                        }
                        break;

                    case 4:
                        Console.Write("PostNº you would like to comment on:");
                        Comment(ConsoleHelper.InputNumberWithin(1, amountOfPosts), ConsoleHelper.InputString("Comment:"));
                        break;

                    case 5:
                        SearchByAuthor(ConsoleHelper.InputString("Search for:"));
                        break;

                    case 6:
                        Console.Write("PostNº to remove:");
                        RemovePost(ConsoleHelper.InputNumberWithin(1, amountOfPosts));
                        break;

                    case 7:
                        Console.WriteLine("PostNº to Like:");
                        LikePost(ConsoleHelper.InputNumberWithin(1, amountOfPosts));
                        break;

                    case 8:
                        Console.WriteLine("PostNº to Unlike:");
                        UnlikePost(ConsoleHelper.InputNumberWithin(1, amountOfPosts));
                        break;

                    case 9:
                        finished = true;
                        break;
                }
            }
            while (!finished);
        }


        /// <summary>
        /// Displays all the posts from the feed
        /// </summary>
        private void DisplayAll()
        {
            news.Display();
        }

        /// <summary>
        /// post an  image to the feed
        /// </summary>
        private void PostImage(string author, string filename, string caption)
        {
            PhotoPost photoPost = new PhotoPost(author, filename, caption);

            news.AddPhotoPost(photoPost);
            Console.WriteLine();
            Console.WriteLine("Photo posted successfully!");
            Console.WriteLine();
        }

        /// <summary>
        /// post a message to the feed
        /// </summary>
        private void PostMessage(string author, string message)
        {
            MessagePost newPost = new MessagePost(author, message);

            news.AddMessagePost(newPost);
            Console.WriteLine();
            Console.WriteLine("Post posted successfully!");
            Console.WriteLine();
        }

        /// <summary>
        /// adds a comment to a post 
        /// </summary>
        /// <param name="postNo"></param>
        /// <param name="comment"></param>
        private void Comment(int postNo, string comment)
        {
            news.CommentOnPost(postNo, comment);
        }

        /// <summary>
        /// searchs for posts from a given author
        /// </summary>
        /// <param name="author"></param>
        public void SearchByAuthor(string author)
        {
           List<Post> searchResults = news.SearchByAuthor(author);//places the found posts into a list
            

            if (searchResults.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Found {searchResults.Count} result(s) for {author}");
                Console.WriteLine();
         
                foreach(Post post in searchResults)
                {
                    post.Display();
                    Console.WriteLine();   // empty line between posts
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"NO RESULTS FOUND FOR:[ {author} ]!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
            }
        }


        /// <summary>
        /// removes a post from the newsfeed
        /// </summary>
        /// <param name="postNo"></param>
        private void RemovePost(int postNo)
        {
            news.RemovePost(postNo);
        }

        /// <summary>
        /// Likes a post
        /// </summary>
        /// <param name="postNo"></param>
        private void LikePost(int postNo)
        {
            news.LikePost(postNo);
        }

        /// <summary>
        /// Unlikes a post
        /// </summary>
        /// <param name="postNo"></param>
        private void UnlikePost(int postNo)
        {
            news.UnlikePost(postNo);
        }
    }
}
