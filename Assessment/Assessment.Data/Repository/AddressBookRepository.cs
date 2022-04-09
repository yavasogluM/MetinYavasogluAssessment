
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Data.Model;

namespace Assessment.Data.Repository
{
    public interface IAddressBookRepository : IBaseRepository<Model.AddressBook>
    {
        Task Remove(string UUId);
        Task Upsert(Model.AddressBook addressBook);
        Task<List<Model.AddressBook>> GetAddressBooks();
        Task<Model.AddressBook> GetAddressBook(string UUId);
    }

    public class AddressBookRepository : BaseRepository<Model.AddressBook>, IAddressBookRepository
    {
        public AddressBookRepository(Model.IConnectionString connectionString, string collectionName) : base(connectionString,
            collectionName)
        {
            
        }

        public Task Remove(string UUId)
        {
            throw new System.NotImplementedException();
        }

        public Task Upsert(AddressBook addressBook)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<AddressBook>> GetAddressBooks()
        {
            throw new System.NotImplementedException();
        }

        public Task<AddressBook> GetAddressBook(string UUId)
        {
            throw new System.NotImplementedException();
        }
    }
}