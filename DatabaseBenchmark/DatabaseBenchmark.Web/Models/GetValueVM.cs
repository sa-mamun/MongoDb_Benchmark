﻿using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DatabaseBenchmark.Web.Models
{
    public class GetValueVM
    {
        [DisplayName("Enter Book Key: ")]
        public string BookKey { get; set; }

        private readonly IRootBookService _rootBookService;

        public GetValueVM()
        {
            _rootBookService = DependencyResolver.Current.GetService<IRootBookService>();
        }

        public async Task<RootBook> GetBookValue(string id)
        {
            var result = await _rootBookService.GetBookByIdAsync(id);
            return result;
        }
    }
}