using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
 public   class GetRoomsService : IGetRoomsService
    {
        public List<RoomSectionViewModel> GetRooms()
        {
            List<RoomSectionViewModel> modelList = new List<RoomSectionViewModel>
            {
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Single Room",
                DormitoryBlock="A block",
                GenderAllocation="Females only",
                NoOfStudents = 1,
                BedType = "Normal Bed",
                Price = "5.3456,00",
                //  PriceOld ,
                RoomsQuota = 0,
                HasDeposit = false,
                ShowPrice = true,
            },

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Quadruble Room",
                 GenderAllocation="Males",
                NoOfStudents = 4,
                DormitoryBlock="C block",
                BedType = "Bunk Bed",
                Price = "2.3456,00",
                PriceOld="2.3456,00",
                RoomsQuota = 2,
                HasDeposit = false,
                ShowPrice = true,
            },
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Double room",
                NoOfStudents = 2,
                 GenderAllocation="Males and female",
                DormitoryBlock="Alfam vista",
                BedType = "Normal Bed",
                Price = "3.3456,00",
                //  PriceOld ,
                RoomsQuota = 3,
                HasDeposit = true,
                ShowPrice = true,
            },
new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Studio apartment",
                NoOfStudents = 2,
                DormitoryBlock="C block",
                 GenderAllocation="Females only",
                BedType = "Normal Bed",
                Price = "6.3456,00",
                PriceOld="8.3456,00",
                RoomsQuota = 4,
                HasDeposit = true,
                ShowPrice = false,
            },

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Single Room",
                NoOfStudents = 1,
                 GenderAllocation="Males only",
                DormitoryBlock="B block",
                BedType = "Normal Bed",
                Price = "6.3456,00",
                PriceOld="8.3456,00",
                RoomsQuota = 0,
                HasDeposit = false,
                ShowPrice = true,
            }
,

new RoomSectionViewModel
            {
                RoomId = 345,
                RoomName = "Studio apartment",
                NoOfStudents = 2,
                BedType = "Normal Bed",
                 GenderAllocation="Males and female",
                DormitoryBlock="Alfam studio block",
                Price = "6.3456,00",
                PriceOld="8.3456,00",
                RoomsQuota = 4,
                HasDeposit = false,
                ShowPrice = true,
            }
            };

            return modelList;
        }
    }

    public class RoomSectionViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string GenderAllocation { get; set; }
        public int NoOfStudents { get; set; }
        public string DormitoryBlock { get; set; }
        public string BedType { get; set; }
        public string Price { get; set; }
        public string PriceOld { get; set; }
        public int RoomsQuota { get; set; }
        public bool HasDeposit { get; set; }
        public bool ShowPrice { get; set; }

    }
}
