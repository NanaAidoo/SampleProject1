using System;

namespace SampleProject1.Commands.Dtos
{
    public class AddVendorDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }

    public class VendorDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}