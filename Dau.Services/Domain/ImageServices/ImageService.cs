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
using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Feature;

namespace Dau.Services.Domain.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<Booking> _bookingRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _environment;
        private readonly IRepository<RoomCatalogImage> _roomCatalogImageRepo;
        private readonly IRepository<CatalogImage> _catalogImageRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormCatalogImageRepo;
        private readonly IRepository<Dormitory> _dormRepo;

        public ImageService(IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment IHostingEnvironment,
            IRepository<RoomCatalogImage> roomCatalogImageRepo,
            IRepository<CatalogImage> catalogImageRepo,
            IRepository<DormitoryCatalogImage> dormCatalogImageRepo,
            IRepository<Dormitory> dormRepo,
            IRepository<Booking> bookingRepo,
            IRepository<Features> featuresRepo)
        {
            _featuresRepo = featuresRepo;
            _bookingRepo = bookingRepo;
            _httpContextAccessor = httpContextAccessor;
            _environment = IHostingEnvironment;
            _roomCatalogImageRepo= roomCatalogImageRepo;
            _catalogImageRepo= catalogImageRepo;
            _dormCatalogImageRepo=dormCatalogImageRepo;
            _dormRepo = dormRepo;

        }







        public bool uploadDormitoryLogoImage(long DormitoryId)
        {
            var imagePath = UploadImage("Files/Images/DormitoryImages/");
            if (imagePath == null || imagePath.Length <= 0) return false;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image

            var dormitory = _dormRepo.GetById(DormitoryId);
            dormitory.DormitoryLogoUrl = "/" + imagePath;
            _dormRepo.Update(dormitory);

           
            return true;
        }

        public bool uploadBookingReceiptImage(long BookingId)
        {
        
            var imagePath = UploadImage("Files/Images/UploadedReceipts/");
            if (imagePath == null || imagePath.Length <= 0) return false;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image

            var booking = _bookingRepo.GetById(BookingId);
          
          booking.ReceiptUrl= "/" + imagePath;
            _bookingRepo.Update(booking);


            return true;
        }


        public bool uploadDormitoryImage(long DormitoryId)
        {
            var imagePath = UploadImage("Files/Images/DormitoryImages/");
            if (imagePath == null || imagePath.Length <= 0) return false;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image

            var CatalogImage = new CatalogImage
            {
                ImageUrl = "/" + imagePath,
                Alt = "Alt",
                CreatedDate = DateTime.Now,
                Published = true,
                DisplayOrder = 0
            };

            var InsertId = _catalogImageRepo.Insert(CatalogImage);
            var DormitoryCatalogImage = new DormitoryCatalogImage
            {
                DormitoryId = DormitoryId,
                CatalogImageId = InsertId
            };
            _dormCatalogImageRepo.Insert(DormitoryCatalogImage);
            return true;
        }

        public bool UploadRoomImage(long RoomId)
        { var imagePath = UploadImage("Files/Images/RoomImages/");
            if (imagePath == null || imagePath.Length<=0) return false;
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


       private string UploadImage(string _storageFolder)
        {
            var newFileName = string.Empty;

            if (_httpContextAccessor.HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = _httpContextAccessor.HttpContext.Request.Form.Files;
                var storageFolder = _storageFolder;

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
                if (imageUrl.ToLower().IndexOf('.') != -1) {//checks if the image contains . as in if it has .jpg not njust a string or /
                
                string[] split = imageUrl.Split(new char[] { '.' }, 2);
                split[1] = split[1].TrimStart();

                string FullImageUrl = imageUrl;
                string SubImageUrl = split[0] + imagePostfix + "." + split[1];
                convertedStrings.Add(SubImageUrl);
                }
            }

            return convertedStrings;
        }
        
        public string PrepareImageForMobileApi (string imageUrl)
        {
            var CurrentSystemUrl = (_httpContextAccessor.HttpContext.Request.IsHttps) ? "https://" : "http://" + _httpContextAccessor.HttpContext.Request.Host.Value.ToString();
            if (imageUrl == null|| imageUrl.Length <= 0)
                return CurrentSystemUrl + "/Content/dist/img/default-image_100.png"; 
            return CurrentSystemUrl + imageUrl;
        }

        public List<string> PrepareImageForMobileApi(List<string> imageUrls)
        {
            var CurrentSystemUrl = (_httpContextAccessor.HttpContext.Request.IsHttps) ? "https://" : "http://" + _httpContextAccessor.HttpContext.Request.Host.Value.ToString();
            var convertedStrings = new List<string>();
            if (imageUrls == null) return null;
            foreach (var imageUrl in imageUrls)
            {
                string modifiedImageUrl;
                if (imageUrl == null )
                {
                    modifiedImageUrl = CurrentSystemUrl + "/Content/dist/img/default-image_100.png";
                }
                else {  modifiedImageUrl = CurrentSystemUrl + imageUrl; }
              
                convertedStrings.Add(modifiedImageUrl);
            }

            return convertedStrings;
            }

        public bool UploadFeatureImage(long FeatureId)
        {

             var imagePath = UploadImage("Files/Images/FeaturesIcons/");
                if (imagePath == null || imagePath.Length <= 0) return false;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image
            var feature = _featuresRepo.GetById(FeatureId);
                feature.IconUrl = "/" + imagePath;
            _featuresRepo.Update(feature);


                return true;
            
        }


    }


}
