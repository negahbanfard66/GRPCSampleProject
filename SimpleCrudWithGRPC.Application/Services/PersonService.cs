using SimpleCrudWithGRPC.Application.DTOs;
using SimpleCrudWithGRPC.Application.IServices;
using SimpleCrudWithGRPC.Core.Entities;
using SimpleCrudWithGRPC.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudWithGRPC.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreatePersonAsync(PersonDto person)
        {
            var entity = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth
            };
            return await _repository.AddPersonAsync(entity);
        }

        public async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            if (person == null) return null;

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth
            };
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            var persons = await _repository.GetAllPersonsAsync();

            return persons.Select(person => new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth
            });
        }

        public async Task<bool> UpdatePersonAsync(PersonDto person)
        {
            var entity = new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth
            };
            return await _repository.UpdatePersonAsync(entity);
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            return await _repository.DeletePersonAsync(id);
        }
    }
}
