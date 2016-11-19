using System;
using System.Net;
using System.Web.Http;
using Monocle.Api.Interfaces;
using Monocle.Repository.Entities;
using Monocle.Services.Interfaces;

namespace Monocle.Api.Controllers
{
    public class StoriesController : ApiController, IRestController<Story>
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_storyService.Get());
        }

        public IHttpActionResult Get(int id)
        {
            var story = _storyService.Get(id);
            if (story == null)
            {
                return NotFound();
            }

            return Ok(story);
        }

        public IHttpActionResult Post(Story item)
        {
            var id = _storyService.Insert(item);
            if (id == null)
            {
                //TODO: Better error message?
                return InternalServerError();
            }

            var result = _storyService.Get(id.Value);
            return Created($"{Request.RequestUri}{id}", result);
        }

        public IHttpActionResult Put(int id, [FromBody]Story item)
        {
            var story = _storyService.Get(id);
            if (story == null)
            {
                return NotFound();
            }

            var result = _storyService.Update(story);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var story = _storyService.Get(id);
            if (story == null)
            {
                return NotFound();
            }

            var result = _storyService.Delete(id);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
