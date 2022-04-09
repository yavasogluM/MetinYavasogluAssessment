namespace Assessment.Data.Model
{
    public class Contact : BaseCollection
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public bool IsActive { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }

    public class ContactInformation
    {
        public string ContentOfInformation { get; set; }
        public InformationType InformationType { get; set; }   
    }

    public enum InformationType
    {
        PhoneNumber = 1,
        EmailAddress = 2,
        Location = 3
    }
}