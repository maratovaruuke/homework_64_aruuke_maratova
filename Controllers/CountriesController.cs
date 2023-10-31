using Homework_64_aruuke_maratova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework_64_aruuke_maratova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly WebApiContext _db;

        public CountriesController(WebApiContext context)
        {
            _db = context;

            if (!_db.CountriesNew.Any())
            {

                _db.CountriesNew.Add(new Country() { Name = "Kyrgyzstan", Capital = "Bishkek", CountryCode = "996", Region = "Chuy" });

                _db.CountriesNew.Add(new Country() { Name = "Turkiye", Capital = "Ankara", CountryCode = "996", Region = "Istanbul" });
                _db.CountriesNew.Add(new Country() { Name = "South Korea", Capital = "Seoul", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "China", Capital = "Beijing", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Japan", Capital = "Tokio", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Kazakstan", Capital = "Astana", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Uzbekistan", Capital = "Tashkent", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Russia", Capital = "Moskva", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Mongolia", Capital = "UlanBator", CountryCode = "996", Region = "Chuy" });
                _db.CountriesNew.Add(new Country() { Name = "Indonesia", Capital = "Djakarta", CountryCode = "996", Region = "Chuy" });

                _db.SaveChanges();

            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _db.CountriesNew.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {

            Country country = await _db.CountriesNew.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)

                return NotFound();

            return new ObjectResult(country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            _db.CountriesNew.Add(country);
            await _db.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult<Country>> Put(Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            if (!_db.CountriesNew.Any(x => x.Id == country.Id))
            {
                return NotFound();
            }

            _db.Update(country);
            await _db.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> Delete(int id)

        {

            Country country = _db.CountriesNew.FirstOrDefault(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            _db.CountriesNew.Remove(country);

            await _db.SaveChangesAsync();

            return Ok(country);

        }

        [HttpGet("search")]
        public IActionResult SearchCountryByName([FromQuery] string name)
        {
            var country = _db.CountriesNew.FirstOrDefault(c => c.Name.Contains(name));
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
    }
}
