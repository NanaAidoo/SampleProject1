using System;
using System.Collections.Generic;

namespace SampleProject1.Commands.Dtos
{
    public class VendorDetailsDTO
    {
        public Guid Id { get; set; }

        public List<InvoiceDTO> Invoices { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public VendorDetailsDTO()
        {
            Invoices = new List<InvoiceDTO>();
        }
    }
}