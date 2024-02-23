using VendorPortal.API.Models.Domain;

namespace VendorPortal.API.Models.Dto
{
    public class RFPDto
    {
        public string Title { get; set; }
        public string UploadDocument { get; set; }
        public string Project { get; set; }
        public string EndDate { get; set; }
        public string CategoryId { get; set; }

    }
}
