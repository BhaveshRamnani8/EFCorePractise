using EFCorePractise.Models;
using System.Diagnostics.Metrics;

namespace EFCorePractise.Manager
{
    internal class CRUDOperations
    {
        private static ContextManager _context;

        public CRUDOperations()
        {
            _context = new ContextManager();
        }

        internal void InsertData()
        {
            var country = GetCountry();
            var state = GetStateFromCountry(country.Id);
            var city = GetCityFromState(state.Id);

            _context.Employees.Add(new Employee()
            {                
                FirstName = "Bhavesh",
                LastName = "Ram",
                Email = "bhavesh.ramnani08@gmail.com",
                Gender = "M",
                MaritalStatus = 0,
                BirthDate = new DateTime(2001, 8, 22),
                Hobbies = "Gyming, Sports",
                Image = "",
                Salary = 50000,
                Address = "Pal : 11",
                CountryId = country.Id,
                StateId = state.Id,
                CityId = city.Id,
                ZipCode = "395005",
                Password = "Ada7845@123"
            });

            //AddStateAndCity();
            //AddEmployeess();

            _context.SaveChanges();
        }

        private void AddStateAndCity()
        {
            _context.State.Add(new State { Name = "Maharashtra", CountryId = 1 });
            _context.State.Add(new State { Name = "Uttar Pradesh", CountryId = 1 });
            _context.State.Add(new State { Name = "California", CountryId = 2 });
            _context.City.Add(new City { Name = "Los Angeles", StateId = 3 });            
            _context.City.Add(new City { Name = "Mumbai", StateId = 2 });
            _context.City.Add(new City { Name = "Ahemdabad", StateId = 1 });
        }

        private void AddEmployeess()
        {
            _context.Employees.Add(new Employee()
            {
                FirstName = "Haresh",
                LastName = "Patel",
                Email = "harsh.patel23@gmail.com",
                Gender = "M",
                MaritalStatus = 0,
                BirthDate = new DateTime(1999, 11, 12),
                Hobbies = "Music, Dancing, Reading",
                Image = "",
                Salary = 35000,
                Address = "Near d-Mart",
                CountryId = 1,
                StateId = 2,
                CityId = 3,
                ZipCode = "395052",
                Password = "7854H@123"
            });

            _context.Employees.Add(new Employee()
            {
                FirstName = "Shanaya",
                LastName = "Shinganiya",
                Email = "shanayaShin45@gmail.com",
                Gender = "F",
                MaritalStatus = 1,
                BirthDate = new DateTime(1996, 6, 26),
                Hobbies = "Music, Dancing",
                Image = "",
                Salary = 45000,
                Address = "Street no 10",
                CountryId = 2,
                StateId = 4,
                CityId = 2,
                ZipCode = "695052",
                Password = "shinchan@123"
            });
        }

        private static Country GetCountry()
        {
            var country = new Country() { Name = "India" };
            var countryExists = _context.Country.FirstOrDefault(x => x.Name == country.Name);

            if (countryExists is null)
            {
                _context.Country.Add(country);
                _context.SaveChanges();
            }
            else
            {
                country = countryExists;
            }
            return country;
        }

        private static State GetStateFromCountry(int countryId)
        {
            var state = new State() { Name = "Gujarat", CountryId = countryId };
            var stateExists = _context.State.FirstOrDefault(x => x.Name == state.Name && x.CountryId == countryId);

            if (stateExists is null)
            {
                _context.State.Add(state);
                _context.SaveChanges();
            }
            else
            {
                state = stateExists;
            }
            return state;
        }

        private static City GetCityFromState(int stateId)
        {
            var city = new City() { Name = "Surat", StateId = stateId };
            var cityExists = _context.City.FirstOrDefault(x => x.Name == city.Name && x.StateId == stateId);

            if (cityExists is null)
            {
                _context.City.Add(city);
                _context.SaveChanges();
            }
            else
            {
                city = cityExists;
            }
            return city;
        }

        internal void UpdateData()
        {
            var employee = _context.Employees.Find(1);

            if (employee != null)
            {
                employee.Email = @"ramnani8@gmail.com";
                employee.Address = "Shree Ram Appartments, Adajan ";
                _context.SaveChanges();
            }
        }

        internal void ReadData()
        {
            var empList = _context.Employees.Where(x => x.Salary > 10000).ToList();

        }

        internal void RemoveData()
        {
            var employee = _context.Employees.Find(1);
            if (employee == null)
                return;
            
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
