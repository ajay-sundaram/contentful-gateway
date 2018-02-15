using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareCam.Contentful.Interfaces;
using Contentful.NET;

namespace CareCam.Contentful.BusinessObjects
{
    internal class Recipe : IRecipe
    {
        private readonly IContentfulClient contentfulClient;

        public Recipe(string accessToken, string space)
        {
            this.contentfulClient = new ContentfulClient(accessToken, space);
        }

    }
}
