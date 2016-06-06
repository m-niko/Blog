using System;
using Blog.Infrastructure;
using Blog.Model.Post;

namespace Blog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Maybe<Post> post = new Post(new PostContent("Hello", "c# this is supper", "c# with me supper"),
                new PublishingDates(DateTime.Today, DateTime.Now));

            Maybe<Post> post1 = Post.Create(new PostContent("Hello", "c# this is supper", "c# with me supper"),
                new PublishingDates(DateTime.Today, DateTime.Now));

            System.Console.WriteLine(post);
            System.Console.ReadKey();
        }
    }
}
