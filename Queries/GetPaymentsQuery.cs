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
    public class GetPaymentsQuery
    {
        private ApplicationDbContext _context ;
        private IMapper _mapper;

        public GetPaymentsQuery(  ApplicationDbContext context){
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>()).CreateMapper();
            _context = context;
        }

        public List<PaymentDTO> Handle()
        {
            try
            {
               var payments = _context.Payments
               .Include(x => x.Invoice).ThenInclude(x => x.Vendor)
               .ToList();

               var payDTO = new List<PaymentDTO>();

            //    foreach(var pay in payments)
            //    {
            //        payDTO.Add(
            //            new PaymentDTO()
            //            {
            //                Id = pay.Id,
            //                Amount = pay.Amount,
            //                PaymentStatus = pay.PaymentStatus,
            //                PaymentDate = pay.PaymentDate,
            //                Invoice = new InvoiceDetailsDTO(){
            //                    Id = pay.Invoice.Id,
            //                 DueDate = pay.Invoice.DueDate,
            //                 AmountDue = pay.Invoice.AmountDue,
            //                 AmountLeft = pay.Invoice.AmountLeft,
            //                 AmountPaid = pay.Invoice.AmountPaid,
            //                 InvoiceNumber = pay.Invoice.InvoiceNumber,
            //                 Vendor = new VendorDetailsDto()
            //                 {
            //                     Id = pay.Invoice.Vendor.Id,
            //                     Name = pay.Invoice.Vendor.Name,
            //                     Email = pay.Invoice.Vendor.Email,
            //                     Phone = pay.Invoice.Vendor.Phone
            //                 }
            //                }
            //            }
            //        );
            //    }
             
                return _mapper.Map<List<PaymentDTO>>(payments);
                //return payDTO;
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