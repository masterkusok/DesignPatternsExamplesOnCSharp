namespace Flyweight
{
    // Context class keeps unique data for every employee
    class EmployeeContext
    {
        private EmployeeFlyweight _flyweight;
        private string _name;
        private string _surname;
        public EmployeeContext(string name, string surname, EmployeeFlyweight flyweight)
        {
            _name = name;
            _surname = surname; 
            _flyweight = flyweight;
        }
        public void DoJob()
        {
            _flyweight.DoJob(_name, _surname);
        }
    }
    // Flyweight class keeps shared data for all employees, in my example it keeps company and position
    class EmployeeFlyweight
    {
        private string _company;
        private string _position;
        public string Company { get => _company; }
        public string Position { get => _position; }
        public EmployeeFlyweight(string company, string position)
        {
            _company = company;
            _position = position;
        }
        public void DoJob(string name, string surname)
        {
            Console.WriteLine($"{name} {surname} does work of {_position} in {_company}");
        }

    }
    class Program
    {
        static void DoJobOfNewSpecialist(EmployeeDB db, string name, string surname,
            string company, string position)
        {
            EmployeeContext employee = new EmployeeContext(name, surname,
                db.GetOrCreateFlyweight(new EmployeeFlyweight(company, position)));
            employee.DoJob();
        }
        static void Main()
        {
            EmployeeDB db = new EmployeeDB(new List<EmployeeFlyweight>
            {
                new EmployeeFlyweight("Microsoft", "Director"),
                new EmployeeFlyweight("Apple", "Director"),
                new EmployeeFlyweight("Microsoft", "Developer"),
                new EmployeeFlyweight("Amazon", "Manager")
            });
            Console.WriteLine($"Now exist {db.GetNumberOfExistingFlyweights} flyweights");
            DoJobOfNewSpecialist(db, "John", "Nolan", "Microsoft", "Developer");
            DoJobOfNewSpecialist(db, "Ivan", "Ivanov", "Microsoft", "Manager");
            Console.WriteLine($"Now exist {db.GetNumberOfExistingFlyweights} flyweights");
        }
    }
}