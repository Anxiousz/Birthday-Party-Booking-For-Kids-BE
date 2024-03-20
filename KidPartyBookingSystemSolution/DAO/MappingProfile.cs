using AutoMapper;
using BusinessObjects.Request;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects.Request;

namespace DAO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestPartyHostDTO, PartyHost>();
            CreateMap<RequestRegisteredUserDTO, RegisteredUser>();
            CreateMap<RequestAccountLoginDTO, Admin>();
            CreateMap<RequestAccountLoginDTO, RegisteredUser>();
            CreateMap<RequestAccountLoginDTO, staff>();
            CreateMap<RequestAccountLoginDTO, PartyHost>();
            CreateMap<RequestMenuPartyHostDTO, MenuPartyHost>();
            CreateMap<RequestStaffDTO, staff>();
            CreateMap<RequestPackageCreateDTO, Package>();
            CreateMap<RequestPackageUpdateDTO, Package>();
            CreateMap<RequestConfigDTO, Config>();
            CreateMap<RequestUpdateConfigDTO, Config>();
            CreateMap<RequestRoomDTO, Room>();
            CreateMap<RequestPostDTO, Post>();
            CreateMap<RequestVoucherDTO, Voucher>();
            CreateMap<RequestUpdateRegisteredUserDTO, RegisteredUser>();
            CreateMap<RequestUpdatePartyHostDTO, PartyHost>();
            CreateMap<RequestMenuOrderDTO, MenuOrder>();
            CreateMap<RequestCreatePaymentDTO, Payment>();
            CreateMap<RequestCreateTransactionBookingDTO, TransactionBooking>();
            CreateMap<RequestBookingDTO, Booking>();
            CreateMap<RequestUpdateMenuPartyHostDTO, MenuPartyHost>();
            CreateMap<RequestCreatePostDTO,Post>();
            CreateMap<RequestUpdateRoomDTO, Room>();
            CreateMap<RequestFeedbackDTO, Feedback>();
        }
    }
}
