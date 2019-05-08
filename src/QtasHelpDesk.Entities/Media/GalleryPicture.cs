using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Entities.AuditableEntity;

namespace QtasHelpDesk.Domain.Media
{
    public class GalleryPicture : BaseEntity<int>, IAuditableEntity
    {
        public string Title { get; set; }

        [ForeignKey("Gallery")]
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        [ForeignKey("Picture")]
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
   

    }
}
