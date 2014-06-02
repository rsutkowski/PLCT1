using System;
using System.Linq;
using System.Web.Http;
using DemoWeb.Models;

namespace DemoWeb.Controllers.Api
{
    [Authorize]
    public class MessageController : ApiController
    {
        private readonly IMessageRepository _repository;
        // GET: api/messages
        public MessageController()
        {
            _repository = new MessageRepository(new DataStore());
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.GetMessages().AsEnumerable());
        }

        // GET: api/messages/5
        public IHttpActionResult GetMessage(int id)
        {
            Message message = _repository.GetMessageById(id);
            return Ok(message);
        }

        [Route("api/message/starred")]
        public IHttpActionResult GetStarredMessages()
        {
            return Ok(_repository.GetMessages().Where(m => m.Favorited == true).AsEnumerable());
        }

        [Route("api/message/unstarred")]
        public IHttpActionResult GetUnstarredMessages()
        {
            return Ok(_repository.GetMessages().Where(m => m.Favorited == false).AsEnumerable());
        }


        // POST: api/Messages
        public void Post(string message)
        {
            var newMessage = new Message {Body = message, Created = DateTime.Now};
            _repository.InsertMessage(newMessage);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.DeleteMessage(id);
            _repository.Save();
        }

        [Route("api/message/{id:int}/star/")]
        [HttpPost]
        public IHttpActionResult StarMessage(int id)
        {
            Message msg = _repository.GetMessageById(id);
            msg.Favorited = !msg.Favorited;
            _repository.UpdateMessage(msg);
            _repository.Save();
            return Ok();
        }
    }
}