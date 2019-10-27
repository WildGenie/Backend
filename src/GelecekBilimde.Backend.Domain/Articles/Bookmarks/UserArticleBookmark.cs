using System;
using Volo.Abp.Domain.Entities;

namespace GelecekBilimde.Backend.Articles.Bookmarks
{
    public class UserArticleBookmark : Entity
    {
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { UserId, ArticleId };
        }
    }
}