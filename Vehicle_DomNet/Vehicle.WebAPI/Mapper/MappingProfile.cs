using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Routing.Constraints;
using Vehicle.DAL;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.WebAPI.Models;
using static System.Collections.Specialized.BitVector32;

namespace Vehicle.WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, VehicleMakeModel>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMakeGetModel>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMakePostModel>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelGetModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelPostModel>().ReverseMap();

            CreateMap<VehicleType, VehicleTypeModel>().ReverseMap();
            CreateMap<VehicleTypeModel, VehicleTypeGetModel>().ReverseMap();
            CreateMap<VehicleTypeModel, VehicleTypePostModel>().ReverseMap();

            CreateMap<VehicleEntity, VehicleEntityModel>().ReverseMap();
            CreateMap<VehicleEntityModel, VehicleEntityGetModel>().ReverseMap();
            CreateMap<VehicleEntityModel, VehicleEntityPostModel>().ReverseMap();

            CreateMap<Engine, EngineModel>().ReverseMap();
            CreateMap<EngineModel, EngineGetModel>().ReverseMap();
            CreateMap<EngineModel, EnginePostModel>().ReverseMap();

            CreateMap<FuelType, FuelTypeModel>().ReverseMap();
            CreateMap<FuelTypeModel, FuelTypeGetModel>().ReverseMap();
            CreateMap<FuelTypeModel, FuelTypePostModel>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<UserModel, UserGetModel>().ReverseMap();
            CreateMap<UserModel, UserPostModel>().ReverseMap();
            CreateMap<UserModel, UserRegisterModel>().ReverseMap();

            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<RoleModel, RolePostModel>().ReverseMap();
            CreateMap<RoleModel, RoleGetModel>().ReverseMap();

            CreateMap<Colour, ColourModel>().ReverseMap();
            CreateMap<ColourModel, ColourPostModel>().ReverseMap();
            CreateMap<ColourModel, ColourGetModel>().ReverseMap();

            CreateMap<Seats, SeatsModel>().ReverseMap();
            CreateMap<SeatsModel, SeatsGetModel>().ReverseMap();
            CreateMap<SeatsModel, SeatsPostModel>().ReverseMap();

            CreateMap<SeatType, SeatTypeModel>().ReverseMap();
            CreateMap<SeatTypeModel, SeatTypeGetModel>().ReverseMap();
            CreateMap<SeatTypeModel, SeatTypePostModel>().ReverseMap();

            CreateMap<SeatTypeColour, SeatTypeColourModel>().ReverseMap();
            CreateMap<SeatTypeColourModel, SeatTypeColourGetModel>().ReverseMap();
            CreateMap<SeatTypeColourModel, SeatTypeColourPostModel>().ReverseMap();

            CreateMap<Transmission, TransmissionModel>().ReverseMap();
            CreateMap<TransmissionModel, TransmissionGetModel>().ReverseMap();
            CreateMap<TransmissionModel, TransmissionPostModel>().ReverseMap();

        }
    }
}
