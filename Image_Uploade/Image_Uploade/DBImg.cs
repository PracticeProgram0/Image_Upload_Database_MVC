using Image_Uploade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Image_Uploade
{
    public class DBImg
    {
        public string ImgInsert(string name,string Image)
        {
            using (var contect=new VIVEKEntities())
            {
                var enterimg = new ImageUpload()
                {
                    Name=name,
                    Image=Image,
                };
                contect.ImageUploads.Add(enterimg);
                int result=contect.SaveChanges();

                return "result";
            }
        }
    }
}