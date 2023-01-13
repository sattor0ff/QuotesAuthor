using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private QuoteService _quoteService;
        public QuoteController()
        {
            _quoteService = new QuoteService();
        }
        [HttpGet("Quotes")]
        public List<QuoteDto> Quote()
        {
            return _quoteService.GetQuotes();
        }
        [HttpPost("Add")]
        public bool Add(QuoteDto quote)
        {
            return _quoteService.AddQuote(quote);
        }
        [HttpPut("Update")]
        public bool Update(QuoteDto quote)
        {
            return _quoteService.UpdateQuote(quote);
        }
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _quoteService.DeleteQuote(id);
        }
        [HttpGet("CategoryFromQuote")]
        public List<QuoteDto> Quote(int id)
        {
            return _quoteService.GetQuotes(id);
        }
        [HttpGet("RandomQuote")]
        public List<QuoteDto> GetRandomQuotes()
        {
            return _quoteService.GetRandomQuotes();
        }
    }