using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network
    /// application.
    ///
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    ///
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author>
    public class NewsFeed
    {
        public readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            MessagePost post = new MessagePost("Vinny", "This is the very first post for FaceBook 2(beta)");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost("jimmy", "NewsFeedPhoto1.jpeg", "The very first Photo!");
            AddPhotoPost(photoPost);

            MessagePost post2 = new MessagePost("Bimmy", "Lovely weather we are having today");
            AddMessagePost(post2);

            MessagePost post3 = new MessagePost("Timmy", "Lol rofl lmao this social media feed sux!!!11!");
            AddMessagePost(post3);
        }

        ///<summary>
        /// Add a text post to the news feed.
        ///
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        ///
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            int i = 1;

            // display all text posts
            foreach (Post post in posts)
            {
                Console.WriteLine($"Post nº:[{i}]");
                post.Display();
                Console.WriteLine();   // empty line between posts
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                Console.WriteLine();
                i++;
            }
        }

        /// <summary>
        /// adds a comment to an existing post
        /// </summary>
        /// <param name="postNo"></param>
        /// <param name="comment"></param>
        public void CommentOnPost(int postNo, string comment)
        {
            int i = 0;

            foreach (Post post in posts)
            {
                if (postNo == i + 1)
                {
                    post.AddComment(comment);
                    break;
                }
                i++;
            }
        }

        /// <summary>
        /// returns a List of posts that have a matching author
        /// </summary>
        /// <param name="author"></param>
        /// <returns>List(Post)</returns>
        public List<Post> SearchByAuthor(string author)
        {
            List<Post> searchResults = new List<Post>();

            foreach (Post post in posts)
            {
                if (author.ToLower().Equals(post.Username.ToLower()))
                {
                    searchResults.Add(post);
                }
            }

            return searchResults;
        }

        /// <summary>
        /// removes a post based on its PostNº
        /// </summary>
        /// <param name="postNo"></param>
        public void RemovePost(int postNo)
        {
            int i = 0;
            bool postRemoved = false;

            foreach (Post post in posts)
            {
                if (postNo == i + 1)
                {
                    posts.Remove(post);
                    Console.WriteLine($"PostNº [{postNo}] removed");
                    Console.WriteLine();
                    postRemoved = true;
                    break;
                }
                i++;
            }

            if (!postRemoved)//not sure it this validation is necessary
            {
                Console.WriteLine($"PostNº [{postNo}] not found!");
            }
        }
       
    }
}