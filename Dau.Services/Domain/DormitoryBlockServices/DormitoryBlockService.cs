using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Dau.Services.Security;
using System;
using System.Collections.Generic;
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
               _dormitoryBlockTransRepo=dormitoryBlockTransRepository;
            _languageService = languageService;
            _dormitoryRepo= dormitoryRepository;
            _dormitoryTransRepo= dormitoryTransRepository;

        }

        public List<DormitoryBlocksTable>  GetDormitoryBlockListTable()
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
                                     DormitoryName = _dormitoryTransRepo.List().Where(c=> c.LanguageId==CurrentLanguageId && c.DormitoryNonTransId== dormBlock.DormitoryId).FirstOrDefault().DormitoryName
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
                                     Published = dormBlock.Published

                                 };



            var model = dormitoryBlock.ToList();

            return model;

        }



    }

    public class DormitoryBlocksTable
    {
        public string Name { get; set; }
        public bool Published { get; set; }
        public string DisplayOrder { get; set; }
        public string DormitoryName { get; set; }
        //public string Edit { get; set; }
    }


    public class DormitoryBlocksTableList
    {
        public string Name { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public long DormitoryBlockId { get; set; }

    }
}
