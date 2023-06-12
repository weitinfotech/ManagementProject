using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUtil
{
    public class ImageOperations
    {
        
        public ImageOperations()
        {
            
        }

        public string ImageUpload(IFormFile file)
        {
            string filename = null;
            if (file != null)
            {
                string filedir = Path.Combine( "Images");
                filename = Guid.NewGuid() + "_" + file.FileName;
                string filePath=Path.Combine(filedir, filename);
                using(FileStream fs=new FileStream(filePath,FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }
            return filename;
        }
    }
}
