using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
        public List<Person> Person { get; set; }

        public City(int id, string name, string uf)
        {
            Id = id;
            Name = name;
            Uf = uf;
        }

        public City(string name, string uf)
        {
            Name = name;
            Uf = uf;
        }
    }
}
