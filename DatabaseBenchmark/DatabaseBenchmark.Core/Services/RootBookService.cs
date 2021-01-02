﻿using DatabaseBenchmark.Core.DbConnection;
using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Services
{
    public class RootBookService : IRootBookService
    {
        private readonly IRepository<RootBook> _repository = new Repository<RootBook>("RootBook", new MongoDbConnection());

        public void AddRootBook(List<RootBook> rootBooks)
        {
            _repository.Insert(rootBooks);
        }

        public RootBook GetBookById(string id)
        {
            return _repository.GetObject(id);
        }
    }
}
