using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace Dau.Services.Domain.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _environment;
        private readonly IRepository<RoomCatalogImage> _roomCatalogImageRepo;
        private readonly IRepository<CatalogImage> _catalogImageRepo;

        public ImageService(IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment IHostingEnvironment,
            IRepository<RoomCatalogImage> roomCatalogImageRepo,
            IRepository<CatalogImage> catalogImageRepo)
        {
            _httpContextAccessor = httpContextAccessor;
            _environment = IHostingEnvironment;
            _roomCatalogImageRepo= roomCatalogImageRepo;
            _catalogImageRepo= catalogImageRepo;
        }


        //private async Task CropImage(string imagePath)
        //{
        //    var storageFolder = "Files/Images/RoomImages/";
        //    var newFileName = "foo.jpg";
        //    using (var httpClient = new HttpClient())
        //    {
             
        //        using (FileStream fs = System.IO.File.Open(imagePath, FileMode.Open))
        //        {
        //            using (var image = Image.Load(fs))
        //            {
        //                var path = Path.Combine(_environment.WebRootPath, storageFolder) + $@"\{newFileName}";



        //                image.Clone(
        //                    ctx => ctx.Crop(560, 300)).Save(path);
        //            }

        //            fs.Flush();
        //        }
        //    }
        //}
        public async Task<bool> UploadRoomImage(long RoomId)
        { var imagePath = UploadImage();
            if (imagePath == null) return false;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image
          
            var CatalogImage = new CatalogImage {
                    ImageUrl = "/"+imagePath,
                    Alt ="Alt",
                    CreatedDate=DateTime.Now,
                    Published =true,
                    DisplayOrder =0
                };

            var InsertId =_catalogImageRepo.Insert(CatalogImage);
            var RoomCatalogImage = new RoomCatalogImage
            {
                RoomId = RoomId,
                CatalogImageId = InsertId
            };
            _roomCatalogImageRepo.Insert(RoomCatalogImage);
         //   await CropImage(imagePath);
            return true;
        }


        public bool RemoveImage (long CatalogImageId)
        {
            try
            {
                var ImageToRemove = _catalogImageRepo.GetById(CatalogImageId);
                _catalogImageRepo.Delete(ImageToRemove);
                return true;
            }
            catch
            {
                return false;
            }

        }


       private string UploadImage()
        {
            var newFileName = string.Empty;

            if (_httpContextAccessor.HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = _httpContextAccessor.HttpContext.Request.Form.Files;
                var storageFolder = "Files/Images/RoomImages/";

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, storageFolder) + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = storageFolder + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        { file.CopyTo(fs);
                            fs.Flush(); }

                        using (var image = Image.Load(Path.Combine(_environment.WebRootPath, storageFolder) + myUniqueFileName + FileExtension))
                        {
                            // image.Mutate(ctx => ctx.Resize(image.Width / 2, image.Height / 2));
                            //   image.Save(Path.Combine(_environment.WebRootPath, storageFolder) + myUniqueFileName+"Resized" + FileExtension); // Automatic encoder selected based on extension.
                            int imageHeight = Convert.ToInt32(image.Height * 0.778);

                           
                          image.Clone(ctx => ctx.Resize(
                                   new ResizeOptions
                                   {
                                       Size = new SixLabors.Primitives.Size(350, 450),
                                       Mode = ResizeMode.Crop
                                   }))


                           // image.Clone(ctx => ctx.Crop(imageHeight, image.Height))
                                .Save(Path.Combine(_environment.WebRootPath, storageFolder) + myUniqueFileName + "_p6" + FileExtension); 

                        }

                    }
                }

                return PathDB;
            }

            return null;
        }

        public string ImageSplitter(string imageUrl, string imagePostfix)
        {
            //tring imageUrl = "21adea7b-b106-4943-9e7b-771643c336ca.jpg";
            //imagePostfix = _p6

            string[] split = imageUrl.Split(new char[] { '.' }, 2);
            split[1] = split[1].TrimStart();

            string FullImageUrl = imageUrl;
            string SubImageUrl = split[0] + imagePostfix+"." + split[1];
            return SubImageUrl;
        }

        public List<string> ImageSplitterList(List<string> imageUrls, string imagePostfix)
        {
            //tring imageUrl = "21adea7b-b106-4943-9e7b-771643c336ca.jpg";
            //imagePostfix = _p6
            var convertedStrings = new List<string>();
            foreach (var imageUrl in imageUrls)
            {
                string[] split = imageUrl.Split(new char[] { '.' }, 2);
                split[1] = split[1].TrimStart();

                string FullImageUrl = imageUrl;
                string SubImageUrl = split[0] + imagePostfix + "." + split[1];
                convertedStrings.Add(SubImageUrl);
            }

            return convertedStrings;
        }
    }


}
