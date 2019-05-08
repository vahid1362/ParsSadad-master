using System;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Entities.AuditableEntity;

namespace QtasHelpDesk.Domain.Identity
{
    public class AppLogItem : IAuditableEntity
    {
        public int Id { set; get; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public int EventId { get; set; }

        public string Url { get; set; }

        public string LogLevel { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string StateJson { get; set; }
    }
}