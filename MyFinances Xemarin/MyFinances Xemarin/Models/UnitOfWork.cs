using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances Xemarin.Models
{
    public class UnitOfWork
{
    private readonly SQLiteAsyncConnection _context;
    public UnitOfWork(string dbPath)
    {
        _context = new SQLiteAsyncConnection(dbPath);
        _context.CreateTableAsync<Operations>().Wait();
    }
}
}
