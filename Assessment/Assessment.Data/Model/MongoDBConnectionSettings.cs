namespace Assessment.Data.Model
{
    public class MongoDBConnectionSettings : IConnectionString
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
    }
}