using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;
using Challenge.Domain.IRepository;
using Challenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> DeleteAsync(Person person)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetPersonByIdAsync(int? id)
        {
            return await _context.Person.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
            Person person = await _context.Person.Include(x => x.City).FirstOrDefaultAsync(x => x.Name == name);
            return person;
        }

        public async Task<Person> GetPersonByCPFAsync(string cpf)
        {
            Person person = await _context.Person.Include(x => x.City).FirstOrDefaultAsync(x => x.Cpf == cpf);
            return person;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            IEnumerable<Person> persons = await _context.Person.Include(x=> x.City).ToListAsync();
            return persons;
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
