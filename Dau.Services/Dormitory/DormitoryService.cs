using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Dau.Services.Dormitory
{
   public class DormitoryService : IDormitoryService
    {
        private fees_and_facilitiesContext _context= new fees_and_facilitiesContext();


        public List<string> GetListAllDormitoriesByLangAndType (int _dormitory_type_id, int _lang_id)
        {
            List<string> listDormitories = new List<string>();
            using (var context = _context)
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



                context.DormitoriesTable.Where(d => d.DormitoryTypeId == _dormitory_type_id).ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == _lang_id).ToList().ForEach(dorm_trans =>
                    {
                        listDormitories.Add(dorm_trans.DormitoryName);
                    });


                });

            }

            return listDormitories;
        }


        public List<SelectListItem> GetSelectListDormitories(int _lang_id)
        {

            List<SelectListItem> Dormitories = new List<SelectListItem>();
            Dormitories.Add(new SelectListItem { Value = "-1", Text = ""});

            using (var context = _context)
            {
                var dormitories = context.DormitoriesTable
                                    .Include(dormitory_trans => dormitory_trans.DormitoriesTableTranslation)
                                    .Include(dormitory_room => dormitory_room.RoomTable)

                                    .ToList();



                context.DormitoriesTable.ToList().ForEach(dorm =>
                {
                    dorm.DormitoriesTableTranslation.Where(r => r.LanguageId == _lang_id).ToList().ForEach(dorm_trans =>
                    {

                        Dormitories.Add(new SelectListItem { Value = dorm_trans.DormitoriesTableNonTransId.ToString(), Text = dorm_trans.DormitoryName });

                    });


                });

            }


            return Dormitories;
        }
    }
}
