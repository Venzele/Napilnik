using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    }

    class Mover
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }

        public void Move()
        {
            //Do move
        }
    }

    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public void Attack()
        {
            //attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }
}