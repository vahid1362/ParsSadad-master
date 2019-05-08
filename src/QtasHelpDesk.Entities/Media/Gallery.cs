using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Entities.AuditableEntity;

namespace QtasHelpDesk.Domain.Media
{
  public class Gallery : BaseEntity<int>, IAuditableEntity
    {
        public Gallery()
        {
            GalleryPictures=new List<GalleryPicture>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime RegisterTime { get; set; }
        public int PictureId { get; set; }
        
        public List<GalleryPicture> GalleryPictures { get; set; }
    }
}
