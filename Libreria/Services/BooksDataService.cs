using Dapper;
using Libreria.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Services
{
    public class BooksDataService: IBooksDataService
    {
        private readonly IConfiguration _configuration;
        private IList<Book> _books;
        private readonly string _connectionString;

        public BooksDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");

            
            var list = new List<Book>();
            _books = list;
            for (int i = 1; i < 8; i++)
            {
                list.Add(new Book
                {
                    Copertina = $"<img src=\"book.png\" alt=\"Book Icon\" height=\"42\" width=\"42\">"
                    //Titolo = $"Harry Potter {i}",
                    //Autore = $"J.K. Rowling",
                    //DataAcquisto = $"Anni 2000",
                    //Finito = true
                });

                
            }
        }
        public IEnumerable<Book> GetBooks()
        {
            
            //return _books;
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"SELECT [Id]
                                            ,[Titolo]
                                            ,[Autore]
                                            ,[DataAcquisto]
                                            ,[Finito]
                                        FROM [dbo].[Books]");
            }
        }
        /*
        public Book GetBook()
        {
            return _books.FirstOrDefault();
        }*/

        public void InsertBook(string title, string author, string date, bool done)
        {
            var book = new Book();

            book.Titolo = title;
            book.Autore = author;
            book.DataAcquisto = date;
            book.Finito = done;
            _books.Add(book);

        }
    }
}
