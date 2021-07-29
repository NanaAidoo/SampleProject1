using System;
using System.Collections.Generic;
using SampleProject1.Commands.Dtos;

namespace models
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public string InvoiceNumber { get; set; }

        public Decimal AmountDue {get; set;}

        public Decimal AmountPaid { get; set; }

        public Decimal AmountLeft { get; set; }

        public DateTime DueDate { get; set; }

        public Vendor Vendor { get; set; }

        public List<Payment> Payments { get; set; }
    }

    
}