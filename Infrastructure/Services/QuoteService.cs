using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotedb;User Id=postgres;Password=s.arda1717;";
    public QuoteService()
    {
        
    }

    public List<QuoteDto> GetQuotes()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM quotes";
            var result = connection.Query<QuoteDto>(sql);
            return result.ToList();
        }
    }
    public bool AddQuote(QuoteDto quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into quotes (quoteText, author, categoryid) values ('{quote.QuoteText}', '{quote.Author}', '{quote.CategoryId}' )";
            var added = connection.Execute(sql);
            if(added>0) return true;
            return false;
        }
    }

    public bool UpdateQuote(QuoteDto quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update quotes set quoteText = '{quote.QuoteText}', author = '{quote.Author}', categoryid = '{quote.CategoryId}' where id = {quote.Id}";
            var added = connection.Execute(sql);
            if(added>0) return true;
            return false;
        }
    }
    public void DeleteQuote(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from quotes where id = {id}";
            var deleted = connection.Execute(sql);
            if(deleted > 0) System.Console.WriteLine($"\nId {id} Deleted successfuly.\n");
            else System.Console.WriteLine($"\nId {id} doesn't exists.\n");
        }
    }

    public List<QuoteDto> GetQuotes(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"SELECT * FROM quotes q join categories c on q.categoryid = c.id where q.categoryid = {id};";
            var result = connection.Query<QuoteDto>(sql);
            return result.ToList();
        }
    }
    public List<QuoteDto> GetRandomQuotes()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"select * from quotes order by random() limit 2;";
            var result = connection.Query<QuoteDto>(sql);
            return result.ToList();
        }
    }
}