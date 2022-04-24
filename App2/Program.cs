using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        class Weapon
        {
            private int _bullets;
            private int _bulletsPerShot;

            public bool CanShoot() => _bullets >= _bulletsPerShot && _bulletsPerShot > 0;

            public void Shoot() => _bullets -= _bulletsPerShot;
        }
    }
}