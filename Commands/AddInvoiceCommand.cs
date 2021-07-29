using System;
using models;
using System.Linq;
using SampleProject1.Commands.Dtos;
using SampleProject1.Data;
using SampleProject1.Exceptions;

namespace SampleProject1.Commands
{
    public class AddInvoiceCommand
    {
        private ApplicationDbContext _context ;

        public AddInvoiceDto AddInvoiceDto;
        public AddInvoiceCommand( AddInvoiceDto addInvoiceDto, ApplicationDbContext context){
            _context = context;
            AddInvoiceDto = addInvoiceDto;
        }

        public Result Handle()
        {
            try
            {
                ValidateInput();

                var invoice = Create(AddInvoiceDto);
                _context.Add(invoice);
                _context.SaveChanges();

                return new Result(){Success=true, Response="Invoice Successfully Created"};
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
        public Invoice Create(AddInvoiceDto Dto)
        {
            var existingVendor =_context.Vendors.FirstOrDefault(x => x.Name ==Dto.VendorName);
            if(existingVendor is null) throw new DomainException("Vendor does not exist");

            var unqiueInvoiceNumber =_context.Invoices.FirstOrDefault(x => x.InvoiceNumber ==Dto.InvoiceNumber);
            if(unqiueInvoiceNumber != null) throw new DomainException("Invoice number already exists!");

            return new Invoice()
            {
                Vendor = existingVendor,
                AmountDue = Dto.AmountDue,
                DueDate = Dto.DueDate,
                InvoiceNumber = Dto.InvoiceNumber,
                AmountLeft = Dto.AmountDue
            };
        }

        public void ValidateInput()
        {
            if(String.IsNullOrEmpty(AddInvoiceDto.InvoiceNumber))
                throw new DomainException("Invoice Number is required");

             if(String.IsNullOrEmpty(AddInvoiceDto.VendorName))
                throw new DomainException("Vendor Name is required");

            if(AddInvoiceDto.AmountDue <= 0 )
                throw new DomainException("Amount has to be more than 0 for invoice");
        }
    }

}