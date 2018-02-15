using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareCam.Contentful.Interfaces;
using System.Configuration;
using CareCam.Contentful.BusinessObjects;

namespace CareCam.Contentful
{
    public class ContentHub : IContentHub
    {
        private readonly IArticle article;
        private readonly IRecipe recipe;
       
        //Contentful Configurations
        private readonly string accessToken = ConfigurationManager.AppSettings["AccessToken"];
        private readonly string space = ConfigurationManager.AppSettings["Space"];

        public ContentHub()
        {
            this.article = new Article(accessToken,space);
            this.recipe = new Recipe(accessToken, space);
        }

        public async Task<object> GetContentById(string Id)
        {
            var content = await article.GetArticleById(Id);
            return content;
        }

        public async Task<object> SearchContentByTags(string tagKey)
        {
            var contents = await article.GetArticlesByTag(tagKey);
            return contents;
        }
    }
}
