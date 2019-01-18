using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Dau.Services.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryBlockServices
{
    public class DormitoryBlockService : IDormitoryBlockService
    {
        private readonly IUserRolesService _userRolesService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;

        public DormitoryBlockService(
            IRepository<DormitoryBlock> dormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> dormitoryBlockTransRepository,
             ILanguageService languageService,
             IRepository<Dormitory> dormitoryRepository,
             IRepository<DormitoryTranslation> dormitoryTransRepository,
             IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
            _dormitoryBlockRepo = dormitoryBlockRepository;
            _dormitoryBlockTransRepo = dormitoryBlockTransRepository;
            _languageService = languageService;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;

        }

        public List<DormitoryBlocksTable> GetDormitoryBlockListTable()
        {


            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 orderby dormBlock.DisplayOrder ascending
                                 select new DormitoryBlocksTable
                                 {
                                     Name = dormBlockTrans.Name,
                                     Published = dormBlock.Published,
                                     DisplayOrder = dormBlock.DisplayOrder.ToString(),
                                     DormitoryName = _dormitoryTransRepo.List().Where(c => c.LanguageId == CurrentLanguageId && c.DormitoryNonTransId == dormBlock.DormitoryId).FirstOrDefault().DormitoryName,
                                     Id = dormBlock.Id
                                 };



            var model = dormitoryBlock.ToList();

            return model;

        }


        public List<DormitoryBlocksTableList> GetDormitoryBlockByDormitoryIdListTable(long DormitoryId)
        {


            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId && dormBlock.DormitoryId == DormitoryId
                                 orderby dormBlock.DisplayOrder ascending
                                 select new DormitoryBlocksTableList
                                 {
                                     Name = dormBlockTrans.Name,
                                     DisplayOrder = dormBlock.DisplayOrder,
                                     DormitoryBlockId = dormBlock.Id,
                                     Published = dormBlock.Published,
                                     Id = dormBlock.Id

                                 };



            var model = dormitoryBlock.ToList();

            return model;

        }

        public DormitoryBlockCrud GetDormitoryBlockById(long id)
        {
            var DormitoryBlock = _dormitoryBlockRepo.GetById(id);
            if (DormitoryBlock == null) return null;
            var EnglishTransDormBlock = _dormitoryBlockTransRepo.List().ToList().Where(c => c.LanguageId == 1 && c.DormitoryBlockNonTransId == DormitoryBlock.Id).FirstOrDefault();
            var TurkishTransDormBlock = _dormitoryBlockTransRepo.List().ToList().Where(c => c.LanguageId == 2 && c.DormitoryBlockNonTransId == DormitoryBlock.Id).FirstOrDefault();

            var model = new DormitoryBlockCrud
            {
                Dormitory = DormitoryBlock.DormitoryId,
                CreatedOn = DateTime.Now.ToString(),
                UpdatedOn = DateTime.Now.ToString(),
                Published = DormitoryBlock.Published,
                Id = DormitoryBlock.Id,
                localizedContent = new List<DormitoryBlockContentLocalizedTab>
                {
                    new DormitoryBlockContentLocalizedTab
                    {
                        Description = EnglishTransDormBlock.Description,
                        Name= EnglishTransDormBlock.Name,

                    },

                    new DormitoryBlockContentLocalizedTab
                    {
                        Description = TurkishTransDormBlock.Description,
                        Name= TurkishTransDormBlock.Name,

                    }
                }


            };

            return model;

        }



        public bool AddNewDormitoryBlock(DormitoryBlockCrud vm)
        {
            try
            {
                var _englishLanguageId = 1;
                var _turkishLanguageId = 2;

                var newDormitoryBlock = new DormitoryBlock
                {
                    Published = vm.Published,


                    DormitoryId = vm.Dormitory,
                    DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = vm.localizedContent[0].Name,
                         Description =vm.localizedContent[0].Description

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = vm.localizedContent[1].Name,
                         Description =vm.localizedContent[1].Description

                         }

                    }
                };

                _dormitoryBlockRepo.Insert(newDormitoryBlock);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateDormitoryBlock(DormitoryBlockCrud vm)
        {
            try
            {
                var DormitoryBlock = _dormitoryBlockRepo.GetById(vm.Id);
                if (DormitoryBlock == null) return false;
                var EnglishTransDormBlock = _dormitoryBlockTransRepo.List().ToList().Where(c => c.LanguageId == 1 && c.DormitoryBlockNonTransId == DormitoryBlock.Id).FirstOrDefault();
                var TurkishTransDormBlock = _dormitoryBlockTransRepo.List().ToList().Where(c => c.LanguageId == 2 && c.DormitoryBlockNonTransId == DormitoryBlock.Id).FirstOrDefault();

                DormitoryBlock.Published = vm.Published;
                DormitoryBlock.DormitoryId = vm.Dormitory;



                EnglishTransDormBlock.Name = vm.localizedContent[0].Name;
                EnglishTransDormBlock.Description= vm.localizedContent[0].Description;

                TurkishTransDormBlock.Name= vm.localizedContent[1].Name;
                TurkishTransDormBlock.Description= vm.localizedContent[1].Description;

                _dormitoryBlockRepo.Update(DormitoryBlock);

                _dormitoryBlockTransRepo.Update(EnglishTransDormBlock);
                _dormitoryBlockTransRepo.Update(TurkishTransDormBlock);

                return true;
            }
            catch
            {
                return false;
            }




        }


        public bool DeleteDormitoryBlockById(long Id)
        {
            try
            {
                var DormitoryBlock = _dormitoryBlockRepo.GetById(Id);
                if (DormitoryBlock == null) return false;

                _dormitoryBlockRepo.Delete(DormitoryBlock);

                return true;
            }

            catch(Exception e)
            {
               
                return false;
            }
        }

        public class DormitoryBlocksTable
        {
            public string Name { get; set; }
            public bool Published { get; set; }
            public string DisplayOrder { get; set; }
            public string DormitoryName { get; set; }
            public long Id { get; internal set; }
            //public string Edit { get; set; }
        }


        public class DormitoryBlocksTableList
        {
            public string Name { get; set; }
            public bool Published { get; set; }
            public int DisplayOrder { get; set; }
            public long DormitoryBlockId { get; set; }
            public long Id { get; internal set; }
        }


        public class DormitoryBlockContentLocalizedTab
        {
            [Required]
            [Display(Name = "Block Name",
          Description = "The dormitory block name"), DataType(DataType.Text), MaxLength(256)]
            public string Name { get; set; }

            [Display(Name = "Description",
            Description = "The description of the dormitory block"), DataType(DataType.Text), MaxLength(256)]
            public string Description { get; set; }

        }

        public class DormitoryBlockCrud
        {
            public long Id { get; set; }

            [Required]
            [Display(Name = "Dormitory",
             Description = "Choose dormitory to associate dormitory block with.")]
            public long Dormitory { get; set; }



            [Display(Name = "Published",
            Description = "Check to publish this dormitory block (visible in customer area). Uncheck to unpublish (dormitory block is not available in customer area).")]
            public bool Published { get; set; }




            [Display(Name = "Created On",
            Description = "Date and time when this room was created."), DataType(DataType.Text), MaxLength(256)]
            public string CreatedOn { get; set; }

            [Display(Name = "Updated On",
            Description = "Date and time when this room was updated."), DataType(DataType.Text), MaxLength(256)]
            public string UpdatedOn { get; set; }




            public List<DormitoryBlockContentLocalizedTab> localizedContent { get; set; }
            public bool SavedSuccessful { get; set; }
            public bool AlertSuccessful { get; set; }
        }

    }
}
