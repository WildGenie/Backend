using System;
using Volo.Abp.Domain.Entities;

namespace GelecekBilimde.Backend.Articles
{
    public class Article : Entity<Guid>
    {
        public bool AllowComments { get; set; }
        public int AuthorId { get; set; }
        public int[] Categories { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Sticky { get; set; }
        public int[] Tags { get; set; }
        public string Title { get; set; }
    }
}