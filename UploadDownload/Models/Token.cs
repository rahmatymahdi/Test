using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadDownload.Models
{
    public class Token
    {
        public Token()
        {
            Id = System.Guid.NewGuid().ToString("N");
            Created=DateTime.Now;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None),StringLength(36)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
    }
}