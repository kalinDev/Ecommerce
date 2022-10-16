using ECommerce.Application.Notifications;

namespace ECommerce.Application.Interfaces
{
    public interface INotifier
    {
        void Handle(Notification notification);
        List<Notification> GetNotifications();
        bool HasNotification();
    }
}
