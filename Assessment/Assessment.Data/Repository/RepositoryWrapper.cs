namespace Assessment.Data.Repository
{
    public interface IRepositoryWrapper
    {
        IContactRepository ContactRepository { get; }
    }
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Model.IConnectionString _mongoDBConnectionString;
        public RepositoryWrapper(Model.IConnectionString mongoDBConnectionString)
        {
            _mongoDBConnectionString = mongoDBConnectionString;
        }
        
        private IContactRepository contactRepository;
        public IContactRepository ContactRepository
        {
            get
            {
                if (contactRepository == null)
                {
                    contactRepository = new ContactRepository(_mongoDBConnectionString, "contact_collection");
                }
                return contactRepository;
            }
        }
    }
}