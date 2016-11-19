using System;
using System.Net;
using System.Web.Http;
using Monocle.Api.Interfaces;
using Monocle.Repository.Entities;
using Monocle.Services.Interfaces;

namespace Monocle.Api.Controllers
{
    [RoutePrefix("api/stories/{id:int}/posts")]
    public class PostsController : ApiController, IRestController<Post>
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_postService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            var post = _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        public IHttpActionResult Post(Post item)
        {
            var id = _postService.Insert(item);
            if (id == null)
            {
                //TODO: Better error message?
                return InternalServerError();
            }

            var result = _postService.Get(id.Value);
            return Created($"{Request.RequestUri}{id}", result);
        }

        public IHttpActionResult Put(int id, [FromBody]Post item)
        {
            var post = _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            var result = _postService.Update(item);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var post = _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            var result = _postService.Delete(id);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
