namespace Assessment.Data.Model
{
    public interface IConnectionString
    {
        string UserName { get; set; }
        string Password { get; set; }
        string DBName { get; set; }
        string ConnectionString { get; set; }
        string TableName { get; set; }
    }
}