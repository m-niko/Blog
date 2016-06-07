using Blog.Infrastructure;

namespace Blog.Model.Post
{
    public class Tag
    {
        private Tag(string title)
        {
            Title = title;
        }
        public string Title { get; set; }

        public static Result<Tag> Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Fail<Tag>("tag is null or white space");

            return Result.Ok(new Tag(title));
        }
    }
}
