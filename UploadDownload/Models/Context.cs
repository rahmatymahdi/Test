using System.Data.Entity;

namespace UploadDownload.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public System.Data.Entity.DbSet<UploadDownload.Models.File> Files { get; set; }
    
    }
}
