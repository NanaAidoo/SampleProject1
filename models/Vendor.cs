using System;
using System.Collections.Generic;

namespace models
{
    public class Vendor
    {
        public Guid Id { get; set; }

        public List<Invoice> Invoices { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // public Vendor()
        // {
        //     Invoices = new List<Invoice>();
        // }
    }

    
}