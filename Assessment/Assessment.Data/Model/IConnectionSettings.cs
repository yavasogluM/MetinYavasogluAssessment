namespace Assessment.Data.Model
{
    public interface IConnectionString
    {
        string ConnectionString { get; set; }
        string DBName { get; set; }
    }
}