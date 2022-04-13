using System.Threading;
using Assessment.Data.Model;
using Assessment.Data.Repository;

namespace Assessment.Tests
{
    public class AssessmentDBHelper
    {
        private readonly MongoDBConnectionSettings _mongoDbConnectionSettings;
        public readonly RepositoryWrapper _repositoryWrapper;
        public AssessmentDBHelper()
        {
            _mongoDbConnectionSettings = new MongoDBConnectionSettings
            {
                ConnectionString =
                    "mongodb+srv://metin_assessment_dbuser:metintestpass@cluster0.pjbsp.mongodb.net/metin_assessment_db?retryWrites=true&w=majority",
                DBName = "metin_assessment_db"
            };

            _repositoryWrapper = new RepositoryWrapper(_mongoDbConnectionSettings);

        }
    }
}