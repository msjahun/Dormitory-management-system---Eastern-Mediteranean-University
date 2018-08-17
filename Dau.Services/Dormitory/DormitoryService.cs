using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Data;
using Microsoft.EntityFrameworkCore;

namespace Dau.Services.Dormitory
{
   public class DormitoryService : IDormitoryService
    {
        private fees_and_facilitiesContext _context;

        public DormitoryService(fees_and_facilitiesContext _context)
        {
            this._context = _context;
        }

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

    }
}
