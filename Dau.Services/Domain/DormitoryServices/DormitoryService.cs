using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryServices
{
    public class DormitoryService : IDormitoryService
    {

        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormImageRepo;
        private readonly IRepository<CatalogImage> _imageRepo;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTransRepo;

        public DormitoryService(
              ILanguageService languageService,
            IRepository<Room> roomRepository,
            IRepository<RoomTranslation> roomTransRepository,
            IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<DormitoryCatalogImage> dormImageRepository,
            IRepository<CatalogImage> imageRepository,
            IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTransRepository
            )
        {

            _languageService = languageService;
            _roomTransRepo = roomTransRepository;
            _roomRepo = roomRepository;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _dormImageRepo = dormImageRepository;
            _imageRepo = imageRepository;
            _dormitoryTypeRepo      = dormitoryTypeRepository;
            _dormitoryTypeTransRepo= dormitoryTypeTransRepository;

        }


        public List<DormitoriesDataTable> GetDormitoryListTable()
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormImages = from dormImage in _dormImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on dormImage.CatalogImageId equals Image.Id
                             select new { dormImage.DormitoryId, Image.ImageUrl, Image.Published };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new DormitoriesDataTable {
                                 DormitoryId=dorm.Id,
                                 Picture = dormImages.ToList().Where(c=> c.DormitoryId == dorm.Id).FirstOrDefault().ImageUrl,
                                 DormitoryName = dormTrans.DormitoryName,
                                 SKU =dorm.SKU,
                                 DormitoryType =dormitoryType.ToList().Where(c=> c.Id == dorm.DormitoryTypeId).FirstOrDefault().Title,
                                 Published =dorm.Published
                            };


            var model = dormitory.ToList();

            return model;
        }

    }


    public class DormitoriesDataTable
    {
        public long DormitoryId { get; set; }
        public string Picture { get; set; }
        public string DormitoryName { get; set; }
        public string SKU { get; set; }
        public string DormitoryType { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }
}
