using System.ComponentModel.DataAnnotations;

namespace UploadDownload.Models
{
    public class File:Token
    {
        public byte[] FileBytes { get; set; }
        [StringLength(200)]
        public string FileName { get; set; }
    }
}