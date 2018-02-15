using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentful.NET;
using Contentful.NET.DataModels;


namespace CareCam.Contentful.Interfaces
{
    internal interface IArticle
    {
        Task<Entry> GetArticleById(string articleId);
        Task<SearchResult<Entry>> GetArticlesByTag(string tagKey);
    }
}
