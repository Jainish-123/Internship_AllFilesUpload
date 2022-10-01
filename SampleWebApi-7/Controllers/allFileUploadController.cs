using classADO_7;
using SampleWebApi_7.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SampleWebApi_7.Controllers
{
    public class allFileUploadController : ApiController
    {
        webapiEntities db = new webapiEntities();
        string upFileName, ext, filepath;

        [Route ("api/allFileUpload/uploadAllFile")]
        [HttpPost]
        public string uploadAllFile()           //public async Task<string> uploadAllFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            HttpContext context = HttpContext.Current;

            string root = context.Server.MapPath("~/App_Data");

            //MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(root);

            try
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[i];

                    upFileName = Path.GetFileName(file.FileName).Trim('"');

                    ext = Path.GetExtension(upFileName);

                    filepath = Path.Combine(root, upFileName);

                    HttpContext.Current.Request.Files[i].SaveAs(filepath);

                    InsertFileData(filepath);
                }

                //await Request.Content.ReadAsMultipartAsync(provider);

                //foreach (var file in provider.FileData)
                //{
                //    string name = file.Headers.ContentDisposition.FileName.Trim('"');

                //    string localFileName = file.LocalFileName;

                //    string filepath = Path.Combine(root, name);

                //    File.Move(localFileName, filepath);

                //    InsertFileData(filepath);
                //}
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "File uploaded.";
        }

        public void InsertFileData(string path)
        {
            test obj = new test();
            obj.connection();
            obj.InsertAllFile(path);
            db.SaveChanges();
        }
    }
}
