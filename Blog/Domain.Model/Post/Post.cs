using System;
using System.Diagnostics.Contracts;

namespace Blog.Model.Post
{
    public class Post
    {
        public Post(PostContent content, PublishingDates publishingDates)
        {
            Contract.Requires(content != null && publishingDates != null);
            Content = content;
            PublishingDates = publishingDates;
        }
        public PostContent Content { get; set; }
        public PublishingDates PublishingDates { get; set; }

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

    public class PublishingDates
    {
        public PublishingDates(DateTime dateBeg, DateTime dateEnd)
        {
            Contract.Requires(dateBeg < dateEnd);
            PublishingDateBeg = dateBeg;
            PublishingDateEnd = dateEnd;
        }
        public DateTime PublishingDateBeg { get; private set; }
        public DateTime PublishingDateEnd { get; private set; }
    }

    public class PostContent
    {
        public PostContent(string title, string summary, string text)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(summary) &&
                              !string.IsNullOrWhiteSpace(text));
            Title = title;
            Summary = summary;
            Text = text;
        }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Text { get; private set; }
    }
}
