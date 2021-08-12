using System;
using System.Linq;
using models;
using SampleProject1.Commands.Dtos;
using SampleProject1.Data;
using SampleProject1.Exceptions;


namespace SampleProject1.Commands
{
    public class AddPaymentCommand
    {
        private ApplicationDbContext _context ;

         public AddPaymentDto AddPaymentDto;
         public AddPaymentCommand( AddPaymentDto addPaymentDto, ApplicationDbContext context){
             _context = context;
             AddPaymentDto = addPaymentDto;
         }

         public Result Handle()
         {
             try
             {
                var payment = Create(AddPaymentDto);
                _context.Add(payment);
                _context.SaveChanges();

                return new Result(){Success=true, Response="Payment has been successful!"};
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

         public Payment Create(AddPaymentDto Dto)
         {
            var existingInvoice =_context.Invoices.FirstOrDefault(x => x.InvoiceNumber ==Dto.InvoiceNumber);
            if(existingInvoice is null) throw new DomainException("Invoice does not exist");

            if(Dto.Amount > existingInvoice.AmountLeft) throw new DomainException($"Payment is over the remaining balance of :  {existingInvoice.AmountLeft}");

            existingInvoice.AmountPaid += Dto.Amount;

            existingInvoice.AmountLeft = existingInvoice.AmountLeft - Dto.Amount;

            // var config = newMapperConfiguration(cfg => cfg.CreateMap<Invoice, AddInvoiceDto>())
            // var mapper = config.CreateMapper();
            // var source = new Payment();
            // source.Invoice = existingInvoice
            // source.PaymentDate = DateTime.Now
            // var destination = mapper.Map<Invoice, AddInvoiceDto>(source)
            
            var payment = new Payment()
             {
                 Invoice = existingInvoice,
                PaymentDate = DateTime.Now,
                 Amount = Dto.Amount,
             };

             
            int result = DateTime.Compare(payment.PaymentDate, existingInvoice.DueDate);

            if (result > 0)
            {
                payment.PaymentStatus = models.Enums.PaymentStatus.OverDue;
            } else 
            {
                payment.PaymentStatus = models.Enums.PaymentStatus.OnTime;
            }


             return payment;
         }

         public void ValidateInput(AddPaymentCommand command)
         {
             if(command.AddPaymentDto.Amount < 1)
                throw new DomainException("Payment amount must be more than 0");

            if(command.AddPaymentDto.Amount < 1)
                throw new DomainException("Payment amount must be more than 0");
         }
    }
}