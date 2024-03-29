﻿using Microsoft.AspNetCore.Identity;

namespace VendorPortal.API.Models.Domain
{
    public class UserProfile : IdentityUser
    {
        public string? Name { get; set; }
        public string? Organization { get; set; }
        public string? ContactPerson { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? Pincode { get; set; }
        public string? Category { get; set; }

    }
}
