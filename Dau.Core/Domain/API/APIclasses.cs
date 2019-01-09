using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.API
{

    public class FacilitiesListGetRoomById
    {
        public string pictureUrl { get; set; }
        public string facilityname { get; set; }
        public long facilityId { get; set; }
    }

    public class BodyGetRoomById
    {
        public List<string> pictureUrl { get; set; }
        public long roomId { get; set; }
        public int roomQuota { get; set; }
        public double roomPrice { get; set; }
        public List<FacilitiesListGetRoomById> facilitiesList { get; set; }
    }

    public class RootObjectGetRoomById
    {
        public string response { get; set; }
        public BodyGetRoomById body { get; set; }
    }
    public class RoomGetRoomByDormitoryId
    {
        public string pictureUrl { get; set; }
        public string dormitoryName { get; set; }
        public string bedType { get; set; }
        public double roomSize { get; set; }
        public int roomQuotaRemaining { get; set; }
        public double roomPrice { get; set; }
        public long roomId { get; set; }
        public long dormitoryId { get; set; }
    }

    public class BodyGetRoomByDormitoryId
    {
        public List<RoomGetRoomByDormitoryId> rooms { get; set; }
    }

    public class RootObjectGetRoomByDormitoryId
    {
        public string response { get; set; }
        public BodyGetRoomByDormitoryId body { get; set; }
    }

    public class DormitoryGetMostPopularDormitories
    {
        public string pictureUrl { get; set; }
        public string dormitoryName { get; set; }
        public string dealsText { get; set; }
        public long dormitoryId { get; set; }
    }

    public class BodyGetMostPopularDormitories
    {
        public List<DormitoryGetMostPopularDormitories> dormitories { get; set; }
    }

    public class RootObjectGetMostPopularDormitories
    {
        public string response { get; set; }
        public BodyGetMostPopularDormitories body { get; set; }
    }

    public class DormitoryGetHighlyRatedDormitories
    {
        public string pictureUrl { get; set; }
        public string dormitoryName { get; set; }
        public string dealsText { get; set; }
        public long dormitoryId { get; set; }
    }

    public class BodyGetHighlyRatedDormitories
    {
        public List<DormitoryGetHighlyRatedDormitories> dormitories { get; set; }
    }

    public class RootObjectGetHighlyRatedDormitories
    {
        public string response { get; set; }
        public BodyGetHighlyRatedDormitories body { get; set; }
    }


    public class FacilitiesListGetDormitoryDetailById
    {
        public string pictureUrl { get; set; }
        public string facilityname { get; set; }
        public long facilityId { get; set; }
    }

    public class BodyGetDormitoryDetailById
    {
        public string dormitoryname { get; set; }
        public string dormitoryShortDescription { get; set; }
        public List<string> imageUrls { get; set; }
        public string dormitotyFullDescription { get; set; }
        public List<FacilitiesListGetDormitoryDetailById> facilitiesList { get; set; }
        public string dormitoryPolicies { get; set; }
    }

    public class RootObjectGetDormitoryDetailById
    {
        public string response { get; set; }
        public BodyGetDormitoryDetailById body { get; set; }
    }

    public class DormitoryGetDormitories
    {
        public string pictureUrl { get; set; }
        public string dormitoryName { get; set; }
        public string dormitoryDescription { get; set; }
        public double ratingNumber { get; set; }
        public string ratingText { get; set; }
        public long dormitoryId { get; set; }
    }

    public class BodyGetDormitories
    {
        public List<DormitoryGetDormitories> dormitories { get; set; }
    }

    public class RootObjectGetDormitories
    {
        public string response { get; set; }
        public BodyGetDormitories body { get; set; }
    }
    public class BookingGetBookingsByCustomerId
    {
        public long roomId { get; set; }
        public string dormitoryDescription { get; set; }
        public long dormitoryId { get; set; }
        public string dormitoryname { get; set; }
        public string pictureUrl { get; set; }
        public double ratingNumber { get; set; }
        public string ratingText { get; set; }
        public string bookingDate { get; set; }
        public string checkInDate { get; set; }
        public string bookingStatus { get; set; }
        public long bookingNumber { get; set; }
    }

    public class BodyGetBookingsByCustomerId
    {
        public List<BookingGetBookingsByCustomerId> bookings { get; set; }
    }

    public class RootObjectGetBookingsByCustomerId
    {
        public string response { get; set; }
        public BodyGetBookingsByCustomerId body { get; set; }
    }

    public class BodyGetBooking
    {
        public long bookingId { get; set; }
        public string dateOfBooking { get; set; }
        public string timeOfBooking { get; set; }
        public string checkInDate { get; set; }
        public string checkInSemester { get; set; }
    }

    public class RootObjectGetBooking
    {
        public string response { get; set; }
        public BodyGetBooking body { get; set; }

    }

    public class CreateUser
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userImageString { get; set; }
        public string userGender { get; set; }
    }


    public class AuthenticationInput
    {
    
       
        public string Username { get; set; }
        public string password { get; set; }
    }

    public class BodyAuthentication
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserImageUrl { get; set; }
        public string UserGender { get; set; }
            }

    public class RootObjectAuthentication
    {
        public string response { get; set; }
        public BodyAuthentication body { get; set; }
    }


    public class BodyBookingByBookingId
    {
        public long dormitoryId { get; set; }
        public string bookingDate { get; set; }
        public string bookingStatus { get; set; }
        public string paymentConfirmationExpiryDate { get; set; }
        public long bookingNo { get; set; }
        public string roomBooked { get; set; }
        public string dormitoryName { get; set; }
    }

    public class RootObjectBookingByBookingId
    {
        public string response { get; set; }
        public BodyBookingByBookingId body { get; set; }
    }



    
    public class FacilityFacilitiesFilter
    {
        public long facilityId { get; set; }
        public string facilityName { get; set; }
    }

    public class BodyFacilitiesFilter
    {
        public List<FacilityFacilitiesFilter> facilities { get; set; }
    }

    public class RootObjectFacilitiesFilter
    {
        public string response { get; set; }
        public BodyFacilitiesFilter body { get; set; }
    }
}
