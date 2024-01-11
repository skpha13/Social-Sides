using backend.Models.DTOs;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequestDTO message)
        {
            var messageToSend = new Message()
            {
                Notification = new Notification()
                {
                    Title = message.Title,
                    Body = message.Body
                },
                Token = message.DeviceToken
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(messageToSend);
            return Ok(result);
        }
    }
}
