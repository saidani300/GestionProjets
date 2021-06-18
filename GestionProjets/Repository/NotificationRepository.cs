using GestionProjets.DBContext;
using GestionProjets.Helpers;
using GestionProjets.Hubs;
using GestionProjets.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly QalitasContext _dbContext;
        private readonly IUserConnectionManager _userConnectionManager;
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public NotificationRepository(QalitasContext dbContext , IUserConnectionManager userConnectionManager, IHubContext<NotificationHub> notificationHubContext)
        {
            _dbContext = dbContext;
            _userConnectionManager = userConnectionManager;
            _notificationHubContext = notificationHubContext;
        }

        public Notification GetNotificationByID(Guid Id)
        {
            return _dbContext.Notifications.Find(Id);
        }

        public IEnumerable<Notification> GetNotifications(Guid UserId)
        {
            return _dbContext.Notifications.Where(A => A.UserId == UserId);
        }

        public void InsertNotification(Notification Notification)
        {
            if (Notification != null)
            {
                _dbContext.Notifications.Add(Notification);

                Save();
            }
        }

        public void DeleteNotification(Guid Id)
        {
            var Notification = _dbContext.Notifications.Find(Id);
            _dbContext.Notifications.Remove(Notification);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async void Notification(Guid userId , Notification notification)
        {
            var connections = _userConnectionManager.GetUserConnections(userId.ToString());
            if (connections != null && connections.Count > 0)
            {
                foreach (var connectionId in connections)
                {
                    await _notificationHubContext.Clients.Client(connectionId).SendAsync("sendToUser", notification);
                }
            }
        }
    }
}
