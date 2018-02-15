using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareCam.Contentful
{
    public interface IContentHub
    {
        Task<object> GetContentById(string Id);
        Task<object> SearchContentByTags(string tagKey);
    }
}
