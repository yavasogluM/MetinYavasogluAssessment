namespace Assessment.API.Model.Response
{
    public class ContactListResponse
    {
        public string UUId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public string ContentOfInformation { get; set; }
        public int ContentOfInformationType { get; set; }
    }
}