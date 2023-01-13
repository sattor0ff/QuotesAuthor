using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class CategoryService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotedb;User Id=postgres;Password=s.arda1717;";
    public CategoryService()
    {
        
    }

    public List<CategoryDto> GetCategories()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM categories";
            var result = connection.Query<CategoryDto>(sql);
            return result.ToList();
        }
    }
    public bool AddCategory(CategoryDto category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into categories (category) values ('{category.Category}')";
            var added = connection.Execute(sql);
            if(added>0) return true;
            return false;
        }
    }

    public bool UpdateCategory(CategoryDto category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update categories set category = '{category.Category}' where id = {category.Id}";
            var added = connection.Execute(sql);
            if(added>0) return true;
            return false;
        }
    }
    public void DeleteCategory(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from categories where id = {id}";
            var deleted = connection.Execute(sql);
            if(deleted > 0) System.Console.WriteLine($"\nId {id} Deleted successfuly.\n");
            else System.Console.WriteLine($"\nId {id} doesn't exists.\n");
        }
    }
}