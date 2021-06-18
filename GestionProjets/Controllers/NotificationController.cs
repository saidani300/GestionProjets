using GestionProjets.AuthorizationAttributes;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        [HttpGet("{id}")]
        [Ref("Notification0")]

        public IActionResult GetById(Guid id)
        {
            var notification = _notificationRepository.GetNotificationByID(id);

            return new OkObjectResult(notification);

        }

        [HttpGet]
        [Ref("Notification1")]

        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var notification = _notificationRepository.GetNotifications(new Guid(LoggedInuserId));

            return new OkObjectResult(notification);

        }
    }
}
