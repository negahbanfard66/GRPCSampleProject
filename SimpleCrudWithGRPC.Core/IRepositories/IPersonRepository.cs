using SimpleCrudWithGRPC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudWithGRPC.Core.IRepositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<bool> AddPersonAsync(Person person);
        Task<Person> GetPersonByIdAsync(int id);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(int id);
    }
}
