﻿using DatabaseBenchmark.Core;
using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class BookModel
    {
        public List<BookJso> GenerateKeyValueBooks { get; set; }
        public List<RootBook> RootBooks { get; set; }

        private readonly IRootBookService _rootBookService = new RootBookService();

        public (string startTime, string endTime, TimeSpan finalCount, List<RootBook> rootBooks) ListOfBookObject(int total)
        {
            int flag = 0, limit = 100000;
            string finalStartTime = "", finalEndTime = "";
            TimeSpan timeSpan;
            TimeSpan finalCount = new TimeSpan(0, 0, 0);
            var randomBookGenerator = new RandomBookGenerator();

            while (total >= limit)
            {
                total = total - limit;
                RootBooks = new List<RootBook>();

                for (int i = 0; i < limit; i++)
                {
                    string key = Guid.NewGuid().ToString();
                    var bookList = randomBookGenerator.GenerateBooks();
                    //var json = GenerateKeyValue(bookList, key);

                    var bookJso = new BookJso
                    {
                        Key = key,
                        Books = bookList
                    };

                    var rootBook = new RootBook
                    {
                        Id = key,
                        BookValue = bookJso
                    };

                    RootBooks.Add(rootBook);
                }

                string startTime = DateTime.Now.ToString("h:mm:ss tt");

                if(flag == 0)
                {
                    finalStartTime = startTime;
                    flag = 1;
                }

                _rootBookService.AddRootBook(RootBooks);

                string endTime = DateTime.Now.ToString("h:mm:ss tt");
                finalEndTime = endTime;

                timeSpan = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                finalCount = finalCount.Add(timeSpan);
            }

            if(total != 0 && total < 100000)
            {
                RootBooks = new List<RootBook>();

                for (int i = 0; i < total; i++)
                {
                    string key = Guid.NewGuid().ToString();
                    var bookList = randomBookGenerator.GenerateBooks();
                    //var json = GenerateKeyValue(bookList, key);

                    var bookJso = new BookJso
                    {
                        Key = key,
                        Books = bookList
                    };

                    var rootBook = new RootBook
                    {
                        Id = key,
                        BookValue = bookJso
                    };

                    RootBooks.Add(rootBook);
                }

                string startTime = DateTime.Now.ToString("h:mm:ss tt");

                if (flag == 0)
                {
                    finalStartTime = startTime;
                }

                _rootBookService.AddRootBook(RootBooks);

                string endTime = DateTime.Now.ToString("h:mm:ss tt");
                finalEndTime = endTime;

                timeSpan = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

                finalCount = finalCount.Add(timeSpan);
            }

            return (finalStartTime, finalEndTime ,finalCount, RootBooks);
        }


        public string GenerateKeyValue(List<Book> books, string key)
        {
            GenerateKeyValueBooks = new List<BookJso>();

            var bookJso = new BookJso
            {
                Key = key,
                Books = books
            };
            string json = ConvertObjToJson(bookJso);

            return json;
        }

        public string ConvertObjToJson(BookJso bookJsoLists)
        {
            string json = JsonConvert.SerializeObject(bookJsoLists);
            return json;
        }
    }
}