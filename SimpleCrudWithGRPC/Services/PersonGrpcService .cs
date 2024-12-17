using Grpc.Core;
using SimpleCrudWithGRPC.Application.DTOs;
using SimpleCrudWithGRPC.Application.IServices;
using SimpleCrudWithGRPC.Protos;

namespace SimpleCrudWithGRPC.Services
{
    public class PersonGrpcService : PersonService.PersonServiceBase
    {
        private readonly IPersonService _personService;

        public PersonGrpcService(IPersonService personService)
        {
            _personService = personService;
        }

        public override async Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request, ServerCallContext context)
        {
            var success = await _personService.CreatePersonAsync(new PersonDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = request.NationalCode,
                DateOfBirth = DateTime.Parse(request.DateOfBirth)
            });

            return new CreatePersonResponse { Success = success };
        }

        public override async Task<GetPersonByIdResponse> GetPersonById(GetPersonByIdRequest request, ServerCallContext context)
        {
            var person = await _personService.GetPersonByIdAsync(request.Id);
            if (person == null) throw new RpcException(new Status(StatusCode.NotFound, "Person not found"));

            return new GetPersonByIdResponse
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth.ToString("yyyy-MM-dd")
            };
        }

        public override async Task<GetAllPersonsResponse> GetAllPersons(GetAllPersonsRequest request, ServerCallContext context)
        {
            var persons = await _personService.GetAllPersonsAsync();

            var response = new GetAllPersonsResponse();
            response.Persons.AddRange(persons.Select(person => new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NationalCode = person.NationalCode,
                DateOfBirth = person.DateOfBirth.ToString("yyyy-MM-dd")
            }));

            return response;
        }

        public override async Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
        {
            var success = await _personService.UpdatePersonAsync(new PersonDto
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = request.NationalCode,
                DateOfBirth = DateTime.Parse(request.DateOfBirth)
            });

            return new UpdatePersonResponse { Success = success };
        }

        public override async Task<DeletePersonResponse> DeletePerson(DeletePersonRequest request, ServerCallContext context)
        {
            var success = await _personService.DeletePersonAsync(request.Id);

            return new DeletePersonResponse { Success = success };
        }

    }
}
