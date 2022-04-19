using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Weapon
    {
        private readonly int _damage;
        private int _bullets;
        private int _bulletsPerShot;

        public bool TryFire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (_bullets >= _bulletsPerShot)
            {
                player.TakeDamage(_damage);
                _bullets -= _bulletsPerShot;
                return true;
            }

            return false;
        }
    }

    class Player
    {
        public int Health { get; private set; }
        public bool IsAlive { get; private set; }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(paramName: "Урон должен быть больше 0");

            if (IsAlive)
            {
                Health -= damage;

                if (Health <= 0)
                    IsAlive = false;
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.IsAlive)
            {
                _weapon.TryFire(player);
            }
        }
    }
}