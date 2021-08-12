using System;
using models.Enums;

namespace models
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Decimal Amount {get; set;}

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        public Invoice Invoice { get; set; }

        public Vendor Vendor { get; set; }
    }

    
}