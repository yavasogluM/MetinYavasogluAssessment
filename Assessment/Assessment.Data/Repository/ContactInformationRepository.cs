namespace Assessment.Data.Repository
{
    
    public interface IContactInformationRepository : IBaseRepository<Model.Contact>
    {
        
    }

    public class ContactInformationRepository : BaseRepository<Model.Contact>, IContactInformationRepository
    {
        public ContactInformationRepository(Model.IConnectionString connectionString, string collectionName) : base(connectionString,
            collectionName)
        {
            
        }
    }
}