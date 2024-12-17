using SimpleCrudWithGRPC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudWithGRPC.Application.IServices
{
    public interface IPersonService
    {
        Task<bool> CreatePersonAsync(PersonDto person);
        Task<PersonDto> GetPersonByIdAsync(int id);
        Task<bool> UpdatePersonAsync(PersonDto person);
        Task<bool> DeletePersonAsync(int id);
        Task<IEnumerable<PersonDto>> GetAllPersonsAsync();
    }
}
