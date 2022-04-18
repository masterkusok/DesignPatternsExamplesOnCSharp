using System.Collections;

namespace Flyweight
{
    internal class EmployeeDB
    {
        private Hashtable _flyweights;
        private string CreateKey(EmployeeFlyweight ef)
        {
            return $"{ef.Company}_{ef.Position}";
        }
        public int GetNumberOfExistingFlyweights => _flyweights.Count;
        public EmployeeDB(List<EmployeeFlyweight> flyweightsList)
        {
            _flyweights = new Hashtable();
            foreach(EmployeeFlyweight ef in flyweightsList)
            {
                _flyweights.Add(CreateKey(ef), ef);
            }
        }
        public EmployeeFlyweight GetOrCreateFlyweight(EmployeeFlyweight ef)
        {
            if (!_flyweights.ContainsKey(CreateKey(ef)))
            {
                Console.WriteLine("Can't find such flyweight, creating new");
                _flyweights[CreateKey(ef)] = ef;
            }
            else
            {
                Console.WriteLine("Getting flyweight from DB");
            }
            return (EmployeeFlyweight)_flyweights[CreateKey(ef)];
        }
    }
}
