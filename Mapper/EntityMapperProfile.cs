using models;
using SampleProject1.Commands.Dtos;

namespace SampleProject1.Mapper
{
    public class EntityMapperProfile : AutoMapper.Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<Vendor, VendorDTO>();
            CreateMap<Vendor, VendorDetailsDTO>();
            CreateMap<Payment, PaymentDTO>()
            .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(x => x.PaymentStatus.ToString()));
            CreateMap<Invoice, InvoiceDTO>()
            .ForMember(dest => dest.VendorInfo, opt => opt.MapFrom(x => x.Vendor));
            CreateMap<Invoice, InvoiceDetailsDTO>();
      
        }
    }
}