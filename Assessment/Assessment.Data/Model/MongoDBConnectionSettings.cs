namespace Assessment.Data.Model
{
    public class MongoDBConnectionSettings : IConnectionString
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DBName { get; set; }
        public string ConnectionString { get; set; }
        /// <summary>
        /// CollectionName
        /// </summary>
        public string TableName { get; set; }
    }
}