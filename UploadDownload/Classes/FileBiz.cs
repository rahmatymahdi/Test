using System;
using System.IO;
using System.Linq;
using System.Web;

namespace UploadDownload.Classes
{
    public class FileBiz
    {
        public static readonly FileBiz Instance=new FileBiz();
        public string Add(HttpPostedFile file)
        {
            if ((file == null) || (file.ContentLength <= 0) || string.IsNullOrEmpty(file.FileName))
                throw new Exception("فایل معتبر نمی باشد");
            using (var ctx = new Models.Context())
            {
                var model = new Models.File() { FileName = file.FileName };
                using (var reader = new BinaryReader(file.InputStream))
                {
                    model.FileBytes = reader.ReadBytes(file.ContentLength);
                }
                ctx.Files.Add(model);
                ctx.SaveChanges();
                return model.Id;
            }
        }
        public Models.File Find(string id)
        {
            using (var ctx = new Models.Context())
            {
                var file = ctx.Files.FirstOrDefault(i => i.Id == id);
                //var file = ctx.Files.FirstOrDefault();
                if (file==null)
                {
                    throw new Exception("فایل معتبر نمی باشد");
                }
                return file;
            }
        }
        public void RemoveScheduler()
        {
            using (var ctx = new Models.Context())
            {
                var date = DateTime.Now.AddDays(-1);
                //حذف تمام فایلهایی که بیش از یک روز ذخیره شده اند
                var files=ctx.Files.Where(i=>i.Created<date);
                if (files.Any())
                {
                    ctx.Files.RemoveRange(files);
                    ctx.SaveChanges();
                }
                
            }
        }
    }
}