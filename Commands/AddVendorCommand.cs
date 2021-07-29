using System;
using models;
using SampleProject1.Commands.Dtos;
using SampleProject1.Data;
using SampleProject1.Exceptions;
using System.Linq;

namespace SampleProject1.Commands
{
    public class AddVendorCommand
    {
        private ApplicationDbContext _context ;

        public AddVendorDto AddVendorDto;
        public AddVendorCommand( AddVendorDto addVendorDto, ApplicationDbContext context)
        {
            _context = context;
            AddVendorDto = addVendorDto;
        }

        public Result Handle()
        {
            try
            {
                ValidateInput();
                 
                var existingVendor = _context.Vendors.ToList().Find(x => x.Name == AddVendorDto.Name);
                if(existingVendor !=null)
                    throw new DomainException("Vendor already exists!");

                var vendor = Create(AddVendorDto);
                _context.Add(vendor);
                _context.SaveChanges();
                
                return new Result(){Success=true, Response ="Vendor Successfully added!"};
            }
             catch(DomainException ex)
            {
               throw ex;
            }
            catch(Exception ex)
            {
               throw ex;
            }
        }

        public Vendor Create(AddVendorDto Dto)
        {
            return new Vendor()
            {
                Name = Dto.Name,
                Phone = Dto.Phone,
                Email = Dto.Email
            };
        }

        public void ValidateInput()
        {
            if(String.IsNullOrEmpty(AddVendorDto.Name ))
                throw new DomainException("Vendor Name is  required.");
        }
    }
}