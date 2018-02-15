using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareCam.Contentful.Interfaces;
using Contentful.NET;
using Contentful.NET.DataModels;
using Contentful.NET.Search.Filters;
using Contentful.NET.Search;
using System.Threading;
using CareCam.Contentful.Enums;
using System.Configuration;

namespace CareCam.Contentful.BusinessObjects
{
    internal class Article : IArticle
    {
        private readonly IContentfulClient contentfulClient;
        private readonly string contentType = ConfigurationManager.AppSettings["ArticleContentType"];
        private CancellationToken cancellationToken;

        public Article(string accessToken,string space)
        {
            this.contentfulClient = new ContentfulClient(accessToken, space);
        }

        public async Task<Entry> GetArticleById(string articleId)
        {
            
            try
            {
                var article = await contentfulClient.GetAsync<Entry>(cancellationToken, articleId);
                return article;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<SearchResult<Entry>> GetArticlesByTag(string tagKey)
        {
            var searchFilters = new ISearchFilter[] {
                new EqualitySearchFilter(BuiltInProperties.ContentType,contentType),
                new EqualitySearchFilter("fields.tags",tagKey.ToLower())
            };

            try
            {
                var articles = await contentfulClient.SearchAsync<Entry>(cancellationToken, searchFilters);

                if (articles.Total == 0)
                    return new SearchResult<Entry> { Total=0, Items=null };

                return articles;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
    }
}
