using System;
using System.Collections.Generic;

namespace SampleProject1.Commands.Dtos
{
    public class AddInvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public string VendorName { get; set; }
        public Decimal AmountDue {get; set;}
        public DateTime DueDate { get; set; }
    }

    public class InvoiceDTO
    {
        public Guid Id { get; set; }

        public string InvoiceNumber { get; set; }

        public Decimal AmountDue {get; set;}

        public Decimal AmountPaid { get; set; }

        public Decimal AmountLeft { get; set; }

        public DateTime DueDate { get; set; }

        public VendorDTO VendorInfo { get; set; }

        public List<PaymentDTO> Payments { get; set; }
    }


    public class InvoiceDetailsDTO
    {
        public Guid Id { get; set; }

        public string InvoiceNumber { get; set; }

        public Decimal AmountDue {get; set;}

        public Decimal AmountPaid { get; set; }

        public Decimal AmountLeft { get; set; }

        public DateTime DueDate { get; set; }

        public VendorDetailsDto Vendor { get; set; }

    }

    


    
    
}