using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using models;
using SampleProject1.Data;
using SampleProject1.Exceptions;
using AutoMapper;
using SampleProject1.Mapper;
using SampleProject1.Commands.Dtos;

namespace SampleProject1.Queries
{
    public class GetInvoicesQuery
    {
        private ApplicationDbContext _context ;
        private IMapper _mapper;

        public GetInvoicesQuery(  ApplicationDbContext context){
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>()).CreateMapper();

            _context = context;
        }
        

        public List<InvoiceDTO> Handle()
        {
            try
            {
               var invoices = _context.Invoices.Include(x => x.Vendor).Include(x => x.Payments).ToList();
               var invoiceDtos = _mapper.Map<List<InvoiceDTO>>(invoices);

             
             return  invoiceDtos;
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