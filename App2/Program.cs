using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        public static void GenerateNewObject()
        {
            //Создание объекта на карте
        }

        public static void RandomizeChance()
        {
            _chance = Random.Range(0, 100);
        }

        public static int CountSalary(int hoursWorked)
        {
            return _hourlyRate * hoursWorked;
        }
    }
}