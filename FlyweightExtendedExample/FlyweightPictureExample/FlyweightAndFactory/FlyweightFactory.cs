using System;
using System.Collections.Generic;

namespace FlyweightPictureExample.FlyweightAndFactory
{
    public class FlyweightFactory
    {
        List<Flyweight> _flyweightList;

        public FlyweightFactory()
        {
            _flyweightList = new List<Flyweight>();
        }

        public Flyweight GetOrCreateFlyweight(Flyweight neededFlyweight)
        {
            foreach(Flyweight flyweight in _flyweightList)
            {
                if(flyweight == neededFlyweight)
                {
                    return flyweight;
                }
            }
            _flyweightList.Add(neededFlyweight);
            return neededFlyweight;
        }

    }
}
