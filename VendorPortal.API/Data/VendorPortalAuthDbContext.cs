﻿

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VendorPortal.API.Models.Domain;

namespace VendorPortal.API.Data
{
    public class VendorPortalAuthDbContext : IdentityDbContext<UserProfile>
    {
        public VendorPortalAuthDbContext(DbContextOptions<VendorPortalAuthDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = "7f541d69 - 7524 - 4077 - bcb8 - bdbe3fd836e0";
            var vendorRoleId = "1beefd77-dac2-4b30-b285-4407bfd1507f";
            var projectHeadRoleId = "8bb312cb-0bbc-4788-9b55-8520aaa01e35";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=adminRoleId,
                    ConcurrencyStamp=adminRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id=vendorRoleId,
                    ConcurrencyStamp=vendorRoleId,
                    Name="Vendor",
                    NormalizedName="Vendor".ToUpper()
                },
                new IdentityRole
                {
                    Id=projectHeadRoleId,
                    ConcurrencyStamp=projectHeadRoleId,
                    Name="ProjectHead",
                    NormalizedName="ProjectHead".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }

    }
}
