using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        class CharacteristicsPlayer { }
        class Gun { }
        class Follower { }
        class Counter
        {
            public IReadOnlyCollection<Unit> QuantityUnits { get; private set; }
        }
    }
}