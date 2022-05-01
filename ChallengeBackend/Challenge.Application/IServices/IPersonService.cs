using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;

namespace Challenge.Application.IServices
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person> GetPersonByIdAsync(int? id);
        Task<Person> GetPersonByNameAsync(string name);
        Task<Person> GetPersonByCPFAsync(string cpf);
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task<Person> DeleteAsync(Person person);
    }
}
