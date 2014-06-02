using System.Linq;

namespace DemoWeb.Models
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetMessages();
        Message GetMessageById(int messageId);
        void InsertMessage(Message student);
        void DeleteMessage(int messageId);
        void UpdateMessage(Message student);
        void Save();
    }
}