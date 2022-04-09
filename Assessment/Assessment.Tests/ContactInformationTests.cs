using Assessment.Data.Model;
using Assessment.Data.Repository;

namespace Assessment.Tests
{
    using System;
    using Xunit;
    public class ContactInformationTests
    {
        private string collectionName = "ContactInformationCollection";
        private MongoDBConnectionSettings _mongoDbConnectionSettings;
        public ContactInformationTests()
        {
            _mongoDbConnectionSettings = new MongoDBConnectionSettings
            {
                
            };
        }
        
        [Fact]
        public void Test1()
        {
            ContactInformationRepository a = new ContactInformationRepository(_mongoDbConnectionSettings, collectionName);
        }
    }
}