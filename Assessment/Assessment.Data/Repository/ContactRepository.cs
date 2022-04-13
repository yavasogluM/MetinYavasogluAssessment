using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Common;
using Assessment.Data.Model;

namespace Assessment.Data.Repository
{
    
    public interface IContactRepository : IBaseRepository<Model.Contact>
    {
        Task<ProcessResult<bool>> Remove(string UUId);
        Task<ProcessResult<bool>> Delete(string UUId);
        Task<ProcessResult<Contact>> Upsert(Contact contact);
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContact(string UUId);
        Task<List<Contact>> GetContactsByLocation(string location);
    }

    public class ContactRepository : BaseRepository<Model.Contact>, IContactRepository
    {
        public ContactRepository(Model.IConnectionString connectionString, string collectionName) : base(connectionString,
            collectionName)
        {
            
        }

        public async Task<ProcessResult<bool>> Remove(string UUId)
        {
            try
            {
                var dbContact = await GetByFilterAsync(x => x.UUID == UUId);
                if (dbContact != null)
                {
                    throw new Exception($"{UUId} does not exist!");
                }
                dbContact.IsActive = false;
                dbContact.UpdatedAt = DateTime.Now;
                await UpdateAsync(dbContact.RowId, dbContact);
                return new ProcessResult<bool>
                {
                    IsValid = true,
                    ResultObject = true
                };
            }
            catch (Exception e)
            {
                return new ProcessResult<bool>
                {
                    Detail = e.ToString(),
                    IsValid = false,
                    ResultObject = false
                };
            }
        }

        public async Task<ProcessResult<bool>> Delete(string UUId)
        {
            try
            {
                if (!(await IsExistAsync(x => x.UUID == UUId)))
                {
                    throw new Exception($"{UUId} does not exist!");
                }

                await DeleteItemAsync(x => x.UUID == UUId);
                return new ProcessResult<bool>
                {
                    IsValid = true,
                    ResultObject = true
                };
            }
            catch (Exception e)
            {
                return new ProcessResult<bool>
                {
                    Detail = e.ToString(),
                    IsValid = false,
                    ResultObject = false
                };
            }
        }
        
        public async Task<ProcessResult<Contact>> Upsert(Contact contact)
        {
            try
            {
                var dbContact = await GetByFilterAsync(x => x.UUID == contact.UUID);
                if (dbContact != null)
                {
                    dbContact.UUID = contact.UUID;
                    dbContact.Firm = contact.Firm;
                    dbContact.Name = contact.Name;
                    dbContact.LastName = contact.LastName;
                    dbContact.ContactInformation = contact.ContactInformation;
                    dbContact.UpdatedAt = DateTime.Now;
                    dbContact.IsActive = true;
                    await UpdateAsync(dbContact.RowId, dbContact);
                }
                else
                {
                    dbContact = contact;
                    dbContact.IsActive = true;
                    dbContact.CreatedAt = DateTime.Now;
                    await InsertItemAsync(dbContact);
                }

                return new ProcessResult<Contact>
                {
                    IsValid = true, 
                    ResultObject = dbContact
                };
            }
            catch (Exception e)
            {
                return new ProcessResult<Contact>
                {
                    Detail = e.ToString(),
                    IsValid = false
                };
            }
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await GetListByFilterAsync(x => x.IsActive);
        }

        public async Task<Contact> GetContact(string UUId)
        {
            return await GetByFilterAsync(x => x.UUID == UUId);
        }
        
        public async Task<List<Contact>> GetContactsByLocation(string location)
        {
            return await GetListByFilterAsync(x => x.IsActive && x.ContactInformation.InformationType == InformationType.Location && x.ContactInformation.ContentOfInformation.Contains(location));
        }
    }
}