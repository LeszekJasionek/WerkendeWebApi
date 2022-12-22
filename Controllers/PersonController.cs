using BeePortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeePortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;


        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("id")] // pobiera listę użytkowników przy pomocy podanego numeru id
        public async Task<ActionResult<List<Person>>> GetPerson(int id)
        {
            var person = await _context.BeePeople.FindAsync(id);
            if (person == null)
                return BadRequest("Person not found");

            return Ok(person);
        }


        [HttpGet] // pobiera listę użytkowników
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return Ok(await _context.BeePeople.ToListAsync());                
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            /*
            var dbPerson = await _context.BeePeople.FindAsync(person.PersonId);
            if (dbPerson != null)
                return BadRequest($"User with ID {person.PersonId} already exists");
            */
            
            
            person.PersonNumber = Random.Shared.Next(100000, 999999);
            _context.BeePeople.Add(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.BeePeople.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            // sprawdzam czy person jest w aktualnej bazie danych
            var dbPerson = await _context.BeePeople.FindAsync(person.PersonId);
            if (dbPerson == null)
                return BadRequest("Hero not found");

            dbPerson.BeeMail = person.BeeMail;
            dbPerson.FirstName = person.FirstName;
            dbPerson.MiddleName = person.MiddleName;
            dbPerson.LastName = person.LastName;
            dbPerson.PlaceOfBirth = person.PlaceOfBirth;
            dbPerson.AddressId = person.AddressId;
            dbPerson.Email = person.Email;
            dbPerson.PhoneNumber = person.PhoneNumber;

            await _context.SaveChangesAsync();
            return Ok(await _context.BeePeople.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.BeePeople.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found");

            _context.BeePeople.Remove(dbHero);
            _context.SaveChanges();

            return Ok(await _context.BeePeople.ToListAsync());
        }

    }
}
