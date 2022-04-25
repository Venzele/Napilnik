using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        public void Enable()
        {
            _enable = true;
            _effects.StartEnableAnimation();
        }

        public void Disabled()
        {
            _enable = false;
            _pool.Free(this);
        }
    }
}