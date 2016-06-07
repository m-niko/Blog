using System;
using Blog.Infrastructure;
using Blog.Model.Post;

namespace Blog.Console
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            CreatePost("c#", "supper c#", "this is supper c#", DateTime.Today, DateTime.Now)
                .OnSuccess(() => WriteLine("supper"))
                .OnFailure(()=> WriteLine("fail"));
        }

        private static void WriteLine(object o)
        {
            System.Console.WriteLine(o);
            System.Console.ReadKey();
        }

        private static Result CreatePost(string title, string summary, string text, DateTime dateBeg,
            DateTime dateEnd)
        {
            var onePostContent = PostContent.Create(title, summary, text);
            var twoPostContent = PostContent.Create(title, summary, text);
            var publishingDates = PublishingDates.Create(dateBeg, dateEnd);
            var category = Category.Create("Programming");
            var tag = Tag.Create("c#");

            return Result.Combine(onePostContent, twoPostContent, publishingDates, category, tag)
                .OnSuccess(() => new Post(onePostContent.Value, publishingDates.Value))
                .OnSuccess(post =>
                {
                    post.AddTag(tag.Value).OnSuccess(t => WriteLine(t.Title));
                    post.AddCategory(category.Value).OnSuccess(() => WriteLine("category added success"));
                }).OnFailure(WriteLine)
                .OnBoth(System.Console.WriteLine);
        }
    }
}
