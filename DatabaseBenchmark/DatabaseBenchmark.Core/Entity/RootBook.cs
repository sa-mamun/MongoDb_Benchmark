using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Core.Entity
{
    public class RootBook
    {
        [BsonId]
        public string Id { get; set; }
        public BookJso BookValue { get; set; }
    }
}