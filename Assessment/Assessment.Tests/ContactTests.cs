using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Data.Model;
using Assessment.Data.Repository;

namespace Assessment.Tests
{
    using System;
    using Xunit;
    public class ContactTests
    {
        private AssessmentDBHelper _assessmentDbHelper;
        public ContactTests()
        {
            _assessmentDbHelper = new AssessmentDBHelper();
        }
        
        [Theory]
        [InlineData("123456abcc")]
        public async Task Remove_Contact_Test_Failure(string UUId)
        {
            var removeResult = await _assessmentDbHelper._repositoryWrapper.ContactRepository.Remove(UUId);
            Assert.False(removeResult.IsValid);
        }
        
        [Theory]
        [InlineData("123456")]
        public async Task Remove_Contact_Test_Success(string UUId)
        {
            var removeResult = await _assessmentDbHelper._repositoryWrapper.ContactRepository.Remove(UUId);
            Assert.True(removeResult.IsValid, removeResult.Detail);
        }

        [Fact]
        public async Task ContactList_Type_Control()
        {
            var contactList = await _assessmentDbHelper._repositoryWrapper.ContactRepository.GetContacts();
            Assert.IsType<List<Contact>>(contactList);
        }
        
        [Theory]
        [InlineData("istanbul")]
        public async Task ContactListByLocation_Type_Control(string location)
        {
            var contactList = await _assessmentDbHelper._repositoryWrapper.ContactRepository.GetContactsByLocation(location);
            Assert.IsType<List<Contact>>(contactList);
        }

        [Fact]
        public async Task Upsert_Contact_Test()
        {
            var upsertResult = await _assessmentDbHelper._repositoryWrapper.ContactRepository.Upsert(new Contact
            {
                UUID = "123456",
                Name = "metin",
                LastName = "yavasoglu2",
                Firm = "test firm",
                ContactInformation = new ContactInformation
                {
                    ContentOfInformation = "metin@metin.com", 
                    InformationType = InformationType.EmailAddress
                }
            });
            Assert.True(upsertResult.IsValid);
        }
    }
}