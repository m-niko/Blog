using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Blog.Infrastructure;

namespace Blog.Model.Post
{
    public class Post
    {
        public Post(PostContent content, PublishingDates publishingDates)
        {
            Contract.Requires(content != null && publishingDates != null);
            Content = content;
            PublishingDates = publishingDates;
            Tags = new List<Tag>();
            Categories = new List<Category>();
        }
        public PostContent Content { get; private set; }
        public PublishingDates PublishingDates { get; private set; }

        public List<Tag> Tags { get; private set; }

        public List<Category> Categories { get; private set; }

        public Result<Tag> AddTag(Tag tag)
        {
            if (tag != null)
            {
                Tags.Add(tag);
                return Result.Ok(tag);
            }
            return Result.Fail<Tag>("tag is null");
        }

        public Result AddCategory(Category category)
        {
            if (category != null)
            {
                Categories.Add(category);
                return Result.Ok();
            }
            return Result.Fail("category is null");
        }

        public override string ToString()
        {
            return $"{Content.Title}, {Content.Summary}, {PublishingDates.PublishingDateBeg}";
        }

        public static Post Create(PostContent content, PublishingDates publishingDates)
        {
            return null;
            //return new Post(content, publishingDates);
        }
    }

    public sealed class PublishingDates
    {
        protected PublishingDates(DateTime dateBeg, DateTime dateEnd)
        {
            PublishingDateBeg = dateBeg;
            PublishingDateEnd = dateEnd;
        }
        public DateTime PublishingDateBeg { get; private set; }
        public DateTime PublishingDateEnd { get; private set; }

        public static Result<PublishingDates> Create(DateTime dateBeg, DateTime dateEnd)
        {
            if (dateBeg > dateEnd)
                return Result.Fail<PublishingDates>("dateBeg > dateEnd");

            return Result.Ok(new PublishingDates(dateBeg, dateEnd));
        }
    }

    public sealed class PostContent
    {
        protected PostContent(string title, string summary, string text)
        {
            Title = title;
            Summary = summary;
            Text = text;
        }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Text { get; private set; }

        public static Result<PostContent> Create(string title, string summary, string text)
        {
            if(string.IsNullOrWhiteSpace(title))
                return Result.Fail<PostContent>("title will not be null");
            if(string.IsNullOrWhiteSpace(summary))
                return Result.Fail<PostContent>("summary will not be null");
            if(string.IsNullOrWhiteSpace(text))
                return Result.Fail<PostContent>("text will not be null");

            return Result.Ok(new PostContent(title, summary, text));
        }
    }

    public class Category
    {
        public string Title { get; set; }

        protected Category(string title)
        {
            Title = title;
        }

        public static Result<Category> Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Fail<Category>("title is null or white space");

            return Result.Ok(new Category(title));
        }
    }
}
