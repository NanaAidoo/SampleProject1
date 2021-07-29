using System;

namespace SampleProject1.Commands.Dtos
{
    public class AddPaymentDto
    {
        public Decimal Amount {get; set;}
        public string InvoiceNumber { get; set; }
    }
}