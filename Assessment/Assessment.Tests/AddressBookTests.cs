using Assessment.Data;
using Assessment.Data.Model;
using Assessment.Data.Repository;
using MongoDB.Bson.Serialization;

namespace Assessment.Tests
{
    using System;
    using Xunit;

    public class AddressBookTests
    {
        private string collectionName = "AddressBookCollection";
        private MongoDBConnectionSettings _mongoDbConnectionSettings;
        public AddressBookTests()
        {
            _mongoDbConnectionSettings = new MongoDBConnectionSettings
            {
                
            };
        }
        
        [Fact]
        public void Test1()
        {
            AddressBookRepository a = new AddressBookRepository(_mongoDbConnectionSettings, collectionName);
        }
    }
}