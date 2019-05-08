using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Entities.AuditableEntity;

namespace QtasHelpDesk.Domain.Media
{
    public partial class Picture : BaseEntity<int>, IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the picture binary
        /// </summary>
        public byte[] BinaryData { get; set; }

    
    }
}
