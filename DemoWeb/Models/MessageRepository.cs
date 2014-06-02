using System;
using System.Data.Entity;
using System.Linq;

namespace DemoWeb.Models
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        #region IMessageRepository

        private readonly DataStore _context;

        public MessageRepository(DataStore dataContext)
        {
            _context = dataContext;
        }

        public IQueryable<Message> GetMessages()
        {
            return _context.Messages.AsQueryable();
        }

        public Message GetMessageById(int messageId)
        {
            return _context.Messages.Find(messageId);
        }

        public void InsertMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(int messageId)
        {
            Message message = _context.Messages.Find(messageId);
            _context.Messages.Remove(message);
        }

        public void UpdateMessage(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion
    }
}