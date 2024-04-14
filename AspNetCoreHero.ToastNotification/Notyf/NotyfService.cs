using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Containers;
using AspNetCoreHero.ToastNotification.Enums;
using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Notyf
{
    public class NotyfService : INotyfService
    { 
        protected IToastNotificationContainer<Models.NotyfNotification> MessageContainer;

        public NotyfService(IMessageContainerFactory messageContainerFactory)
        {
            MessageContainer = messageContainerFactory.Create<Models.NotyfNotification>();
        }
        public virtual void Custom(string message, int? durationInSeconds = null, string backgroundColor = "black", string iconClassName = "home")
        {
            var toastMessage = new Models.NotyfNotification(ToastNotificationType.Custom, message, durationInSeconds);
            toastMessage.Icon = iconClassName;
            toastMessage.BackgroundColor = backgroundColor;
            MessageContainer.Add(toastMessage);
        }

        public virtual void Error(string message, int? durationInSeconds = null)
        {
            var toastMessage = new Models.NotyfNotification(ToastNotificationType.Error, message, durationInSeconds);
            MessageContainer.Add(toastMessage);
        }

        public virtual IEnumerable<Models.NotyfNotification> GetNotifications()
        {
            return MessageContainer.GetAll();
        }

        public virtual void Information(string message, int? durationInSeconds = null)
        {
            var toastMessage = new Models.NotyfNotification(ToastNotificationType.Information, message, durationInSeconds);
            MessageContainer.Add(toastMessage);
        }

        public virtual IEnumerable<Models.NotyfNotification> ReadAllNotifications()
        {
            return MessageContainer.ReadAll();
        }

        public virtual void RemoveAll()
        {
            MessageContainer.RemoveAll();
        }

        public virtual void Success(string message, int? durationInSeconds = null)
        {
            var toastMessage = new Models.NotyfNotification(ToastNotificationType.Success, message, durationInSeconds);
            MessageContainer.Add(toastMessage);
        }

        public virtual void Warning(string message, int? durationInSeconds = null)
        {
            var toastMessage = new Models.NotyfNotification(ToastNotificationType.Warning, message, durationInSeconds);
            MessageContainer.Add(toastMessage);
        }
    }
}
