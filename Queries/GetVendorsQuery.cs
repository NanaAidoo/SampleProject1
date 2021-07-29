using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using models;
using SampleProject1.Data;
using SampleProject1.Exceptions;
using AutoMapper;
using SampleProject1.Mapper;



namespace SampleProject1.Queries
{
    public class GetVendorsQuery
    {
        private ApplicationDbContext _context ;
        private IMapper _mapper;

        public GetVendorsQuery(  ApplicationDbContext context){
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>()).CreateMapper();
            _context = context;
        }

        public List<Vendor> Handle()
        {
            try
            {
               var vendors = _context.Vendors.Include(x => x.Invoices)
               .ToList();

               return _mapper.Map<List<Vendor>>(vendors);
             
                //return vendors;
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
    }
}