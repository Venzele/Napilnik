using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Weapon
    {
        private int _damage;
        private int _bullets;

        public void Fire(Player player)
        {
            if (_bullets > 0)
            {
                player.TakeDamage(_damage);
                _bullets -= 1;
            }
        }
    }

    class Player
    {
        private bool _isAlive = true;

        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new InvalidOperationException();

            if (_isAlive)
            {
                Health -= damage;

                if (Health <= 0)
                    _isAlive = false;
            }
        }
    }

    class Bot
    {
        public Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
