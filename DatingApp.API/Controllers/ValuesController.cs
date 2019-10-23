using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{

    // Example
    // http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            //This will go to our database get the values and present them in a list and store them in somthing called Values
            var values = await _context.Values.ToListAsync();
            //This will return the variable called values 
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //The int id allows us to use the id paramiter in our code.
        public async Task<IActionResult> GetValue(int id)
        {
            //This will go to the table with the ID spcified and look for it then will pick the first value it finds that
            //matches! X is the value we have just got so it will get ID from the value then store it in Value which
            //we can then use and will return
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
