using Microsoft.EntityFrameworkCore;
using SimpleCrudWithGRPC.Core.Entities;
using SimpleCrudWithGRPC.Core.IRepositories;
using SimpleCrudWithGRPC.Infrastructure.Data;

namespace SimpleCrudWithGRPC.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            _context.Persons.Add(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var existingPerson = await _context.Persons.FirstOrDefaultAsync(p => p.Id == person.Id);
            if (existingPerson == null) return false;

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.NationalCode = person.NationalCode;
            existingPerson.DateOfBirth = person.DateOfBirth;

            _context.Persons.Update(existingPerson);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
