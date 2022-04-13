using Assessment.Data.Model;

namespace Assessment.API.Model.Request
{
    public class ContactUpsertRequest
    {
        public string UUId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public string ContentOfInformation { get; set; }
        public InformationType ContentOfInformationType { get; set; }
    }
}