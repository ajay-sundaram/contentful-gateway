using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using CareCam.Contentful;
using Newtonsoft.Json;


namespace ContentGateway.Controllers
{
    [RoutePrefix("api/content")]
    public class ContentController : ApiController
    {
        private readonly IContentHub contentHub;
        public ContentController(IContentHub _contentHub)
        {
            this.contentHub = _contentHub;
        }

        public async Task<IHttpActionResult> GetContent()
        {
            return Ok(new { success = "Yes" });
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> GetContent(string id)
        {
            var content = await contentHub.GetContentById(id);
            if (content == null)
                return NotFound();

            return Ok(content);
        }

        [Route("search/{tag}")]
        public async Task<IHttpActionResult> GetContentsByTag(string tag)
        {
            var contents = await contentHub.SearchContentByTags(tag);
            if (contents == null)
                return NotFound();

            return Ok(contents);

        }

    }
}
