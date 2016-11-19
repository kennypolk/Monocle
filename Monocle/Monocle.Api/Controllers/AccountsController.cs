using System;
using System.Net;
using System.Web.Http;
using Monocle.Api.Interfaces;
using Monocle.Repository.Entities;
using Monocle.Services.Interfaces;

namespace Monocle.Api.Controllers
{
    public class AccountsController : ApiController, IRestController<Account>
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IHttpActionResult Get()
        {
            var accounts = _accountService.Get();
            return Ok(accounts);
        }

        public IHttpActionResult Get(int id)
        {
            var account = _accountService.Get(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        public IHttpActionResult Post(Account item)
        {
            var id = _accountService.Insert(item);
            if (id == null)
            {
                //TODO: Better error message?
                return InternalServerError();
            }

            var result = _accountService.Get(id.Value);
            return Created($"{Request.RequestUri}{id}", result);
        }

        public IHttpActionResult Put(int id, [FromBody]Account item)
        {
            var account = _accountService.Get(id);
            if (account== null)
            {
                return NotFound();
            }

            var result = _accountService.Update(item);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var account = _accountService.Get(id);
            if (account== null)
            {
                return NotFound();
            }

            var result = _accountService.Delete(id);
            if (result == 0)
            {
                //TODO: Better Error handling
                throw new Exception("I'm an Error");
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
