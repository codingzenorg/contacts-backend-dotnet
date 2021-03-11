using System;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ContactsBackendDotnet.Tests
{
    public class TestDbContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<ContactContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<ContactContext>()
                .UseSqlite(_connection).Options;
        }

        public async Task<ContactContext> CreateContextAsync()
        {
            if (_connection != null) 
                return new ContactContext(CreateOptions());
        
            _connection = new SqliteConnection("DataSource=:memory:");
            await _connection.OpenAsync();

            await using var context = new ContactContext(CreateOptions());
            await context.Database.EnsureCreatedAsync();
            return new ContactContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection == null) return;
            _connection.Dispose();
            _connection = null;
        }
    }
}