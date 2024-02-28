using SQLite;
using WeatherApp.Common.Constants;
using System.Linq.Expressions;
using WeatherApp.Models.Entities;
using WeatherApp.Domain.Persistence;

namespace WeatherApp.Maui.Services.Persistence;

public class MobileDatabase : IMobileDatabase
{
    private readonly string _dbName;

    public SQLiteAsyncConnection ConnAsync { get; init; }

    public MobileDatabase(string dbName)
    {
        _dbName = dbName;
        var connStr = GetConnectionString();
        ConnAsync = new SQLiteAsyncConnection(connStr);
        ConnAsync.ExecuteScalarAsync<string>($"PRAGMA key={Database.CipherPassword}");

    }

    private SQLiteConnectionString GetConnectionString()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _dbName);
        var connStr = new SQLiteConnectionString(dbPath, SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache, true, Database.CipherPassword);

        return connStr;
    }

    public Task InsertAllAsync<T>(IEnumerable<T> list) where T : class, IEntity, new()
        => ConnAsync.InsertAllAsync(list, typeof(T));

    public Task UpdateAllAsync<T>(IEnumerable<T> list) where T : class, IEntity, new()
     => ConnAsync.UpdateAllAsync(list);

    public Task<int> CountAsync<T>() where T : class, IEntity, new()
        => ConnAsync.Table<T>().CountAsync();

    public Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new()
        => ConnAsync.Table<T>().CountAsync(expression);

    public Task<int> DeleteAllAsync<T>() where T : class, IEntity, new()
        => ConnAsync.DeleteAllAsync<T>();

    public Task<int> DeleteAsync<T>(int id) where T : class, IEntity, new()
        => ConnAsync.DeleteAsync<T>(id);

    public Task<int> DeleteAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new()
        => ConnAsync.Table<T>().DeleteAsync(expression);

    public Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new()
        => ConnAsync.Table<T>().FirstOrDefaultAsync(expression);

    public Task<List<T>> ToListAsync<T>() where T : class, IEntity, new()
        => ConnAsync.Table<T>().ToListAsync();

    public Task<List<T>> Where<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new()
        => ConnAsync.Table<T>().Where(expression).ToListAsync();

    public async Task<int> InsertAsync<T>(T item) where T : class, IEntity, new()
        => await ConnAsync.InsertAsync(item);

    public async Task<int> UpdateAsync<T>(T item) where T : IEntity
        => await ConnAsync.UpdateAsync(item);

    public async Task<int> InsertOrUpdateAsync<T>(T item) where T : class, IEntity, new()
    {
        //if (item.Id != 0)
        //{
        //    return await UpdateAsync(item);
        //}
        //else
        //{
        //    return await InsertAsync(item);
        //}
        return 0;
    }

}
