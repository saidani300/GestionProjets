using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface INotificationRepository
    {
        void DeleteNotification(Guid Id);
        Notification GetNotificationByID(Guid Id);
        IEnumerable<Notification> GetNotifications(Guid UserId);
        void InsertNotification(Notification Notification);
        void Notification(Guid userId, Notification notification);
        void Save();
    }
}