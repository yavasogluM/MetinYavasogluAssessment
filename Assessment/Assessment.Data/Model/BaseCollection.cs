using System;

namespace Assessment.Data.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// MongoDB Base Collection Class
    /// </summary>
    public class BaseCollection
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public string RowId => Id.ToString();
        
        [BsonElement("createdat")]
        public DateTime? CreatedAt { get; set; }
        
        [BsonElement("updatedat")]
        public DateTime? UpdatedAt { get; set; }
    }
}