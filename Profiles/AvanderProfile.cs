using AutoMapper;
using Avander.Dtos;
using Avander.Models;

namespace Avander.Profiles
{
    public class AvanderProfile : Profile
    {
        public AvanderProfile()
        {
            CreateMap<Vehicle, VehicleReadDto>();

            CreateMap<Shop, ShopReadDto>();

            CreateMap<MeasurementPoint, MeasurementPointReadDto>();

            CreateMap<Measurement, MeasurementReadDto>();
            CreateMap<MeasurementCreateDto, Measurement>();
            CreateMap<MeasurementUpdateDto, Measurement>();
            CreateMap<Measurement, MeasurementUpdateDto>();
        }
    }
}