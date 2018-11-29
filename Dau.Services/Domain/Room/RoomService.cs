using Dau.Core.Domain.Dormitory;
using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Language;
using Dau.Core.Domain.Room;
using Dau.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Room
{
  public   class RoomService : IRoomService
    {
        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();

        public void RoomFacilityMapping(room_facility_data _data)
        {
            //for room facility mapping
          //it's too amgigious, seperate it into two
          //one for mapping options and one for mapping the facility it self
            //edit it so that just roomId and facility id have to be passed as parameters

            new room_facility_data
            {
                dormitory_name = "",
                room_type = "",
                facility_title = "Bed",
                facility_option = "Normal"
                
            };

            int facility_option_int_id;

            var data =  new room_facility_data();


                    FacilityTable facility = _context.FacilityTable
                        .FirstOrDefault(f => f.Id == f.FacilityTableTranslation
                        .FirstOrDefault(k => k.FacilityTitle == data.facility_title).FacilityTableNonTransId);


                    DormitoriesTable dormitory = _context.DormitoriesTable
                        .FirstOrDefault(d => d.Id == d.DormitoriesTableTranslation
                        .FirstOrDefault(t => t.DormitoryName == data.dormitory_name).DormitoriesTableNonTransId);

                    RoomTable room = _context.RoomTable
                        .FirstOrDefault(r => r.DormitoryId == dormitory.Id && r.RoomTableTranslation
                        .FirstOrDefault(n => n.RoomType == data.room_type).RoomTableNonTransId== r.Id);



                    if (data.facility_option == "null")
                        facility_option_int_id = 0;
                    else
                    {
                        FacilityOption facility_Option = _context.FacilityOption
                            .FirstOrDefault(o => o.FacilityId == facility.Id && o.FacilityOptionTranslation
                            .FirstOrDefault(ot => ot.FacilityOption== data.facility_option).FacilityOptionNonTransId== o.Id);

                        //if option is null;
                        facility_option_int_id = facility_Option.Id;

                    }

                //facility_option_id ==0
                _context.RoomFacility.Add(new RoomFacility { FacilityId = facility.Id, RoomId = room.Id, FacilityOptionId = facility_option_int_id });
                _context.SaveChanges();
                
            
        }
        
      public void RoomAdd(room_data _data)
        {   //for adding rooms
            //create mini methods for updating the fields if possible
            //since they won't be just one picture now, create a seperate table for 
            //storing image paths and ids, then store the ids and rooms in another table,
            
            new room_data
            {
                room_picture_url = "../../Content/dorm_images/img_0868.jpg?RenditionID=7",
                dormitory_name = "EMU 1",
                room_price = 2200,
                room_price_installment = 2400,
                num_rooms_left = 15,
                room_title_EN = "Triple room",
                room_title_TR = "ÜÇ Kişilik",
                room_type_EN = "Triple room",
                room_type_TR = "ÜÇ Kişilik",
                room_area = 24
            };

            //for languages, if a language field is empty use the standard field

            LanguageTable language_Table_EN = _context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "EN");
                LanguageTable language_Table_TR = _context.LanguageTable.FirstOrDefault(l => l.LanguageCode == "TR");

            var data = new room_data();
             
                    //we have to query dormitory_id.

                    DormitoriesTable dormitory =  _context .DormitoriesTable
                    .FirstOrDefault(d => d.Id == d.DormitoriesTableTranslation
                    .FirstOrDefault(c => c.DormitoryName == data.dormitory_name)
                    .DormitoriesTableNonTransId);

                    RoomTable room = new RoomTable
                    {
                        DormitoryId = dormitory.Id,
                        RoomPictureUrl = data.room_picture_url,
                        RoomPrice = data.room_price,
                        RoomPriceInstallment = data.room_price_installment,
                        RoomArea = data.room_area,
                        NumRoomsLeft = data.num_rooms_left
                    };

                     _context .RoomTable.Add(room);
                     _context .SaveChanges();

                    //English
                     _context .RoomTableTranslation.Add(new RoomTableTranslation
                    {
                        LanguageId = language_Table_EN.Id,
                        RoomTableNonTransId = room.Id,
                        RoomType = data.room_type_EN,
                        RoomTitle = data.room_title_EN
                    });
                     _context .SaveChanges();

                    //Turkish
                     _context .RoomTableTranslation.Add(new RoomTableTranslation
                    {
                        LanguageId = language_Table_TR.Id,
                        RoomTableNonTransId = room.Id,
                        RoomType = data.room_type_TR,
                        RoomTitle = data.room_title_TR
                    });

                     _context .SaveChanges();


              

        }


        public List<RoomsListTable> GetAllRooms()
        {
            var room = new List<RoomsListTable>();
            _context.RoomTable.Select(p => new
            {
                dormitoryId = p.DormitoryId,
                dormitoryName = p.Dormitory.DormitoriesTableTranslation.Select(c=> c.DormitoryName).FirstOrDefault().ToString(),
                numberOfRoomsLeft = p.NumRoomsLeft,
                roomArea = p.RoomArea,
                roomPictureUrl = p.RoomPictureUrl,
                roomPrice = p.RoomPrice,
                roomInstallmentPrice = p.RoomPriceInstallment,
                name = p.RoomTableTranslation.Where(c => c.LanguageId == 1 && c.RoomTableNonTransId == p.Id).Select(c => c.RoomTitle).FirstOrDefault().ToString(),
                roomId = p.Id
            }).ToList().ForEach(p =>
            {
                room.Add(new RoomsListTable
                {dormitoryName = p.dormitoryName,
                dormitoryId = p.dormitoryId,
                roomId = p.roomId,
                   Picture = p.roomPictureUrl,
                Price = p.roomPrice,
                RoomName = p.name,
                SKU = "",
                Quota = p.numberOfRoomsLeft,
                RoomType = p.name,
                Published = true
            });
             



            });

            return room;
        }

    }


    public class room_data
    {
        public String dormitory_name { get; set; }
        public String room_picture_url { get; set; }
        public float room_price { get; set; }
        public float room_price_installment { get; set; }
        public int room_area { get; set; }
        public String room_type_EN { get; set; }
        public String room_type_TR { get; set; }
        public String room_title_EN { get; set; }
        public String room_title_TR { get; set; }
        public int num_rooms_left { get; set; }
    }


    public class room_facility_data
    {
        public String facility_title { get; set; }
        public String dormitory_name { get; set; }
        public String room_type { get; set; }
        public String facility_option { get; set; }
    }



    public class RoomsListTable
    { public string dormitoryName{ get; set; }
     public int dormitoryId{ get; set; }
     public int roomId { get; set; }
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Quota { get; set; }
        public string RoomType { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }
}
