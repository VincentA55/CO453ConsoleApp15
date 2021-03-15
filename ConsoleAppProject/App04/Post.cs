using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    public class Post
    {
        private int likes;

        private readonly List<String> comments;


        // username of the post's author
        public String Username { get; }

        public DateTime Timestamp { get; }

        /// <summary>
        /// Constructor for the post class
        /// </summary>
        /// <param name="author"></param>
        public Post(string author)
        {
            this.Username = author;
            Timestamp = DateTime.Now;


            likes = 0;
            comments = new List<String>();
        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>
        /// <param name="text">
        /// The new comment to add.
        /// </param>        
        public void AddComment(String text)
        {
            comments.Add(text);
        }
    }
}
