﻿using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WastingNoTime.Contacts.Infrastructure;

namespace WastingNoTime.Contacts.Tests;

public class TestDbContextFactory : IDisposable
{
    private readonly DbConnection _connection = new SqliteConnection("DataSource=:memory:");
    public async Task<ContactContext> CreateContextAsync()
    {
        await _connection.OpenAsync();

        var context = new ContactContext(new DbContextOptionsBuilder<ContactContext>().UseSqlite(_connection).Options);
        await context.Database.EnsureCreatedAsync();
        
        return context;
    }

    public void Dispose() =>
        _connection.Dispose();
}