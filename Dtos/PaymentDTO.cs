using System;
using models.Enums;

namespace SampleProject1.Commands.Dtos
{
    public class PaymentDetailsDTO
    {
        public Guid Id { get; set; }

        public Decimal Amount {get; set;}

        public Status PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        public InvoiceDetailsDTO Invoice { get; set; }

        public VendorDetailsDto Vendor { get; set; }
    }

     public class PaymentDTO
    {
        public Guid Id { get; set; }

        public Decimal Amount {get; set;}

        public Status PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        
    }

    


    
    
}