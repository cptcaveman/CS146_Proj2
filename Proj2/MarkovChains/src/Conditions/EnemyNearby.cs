using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.src.Enemies;
using MarkovChains.src.Player;

namespace MarkovChains.src.Conditions
{
    class EnemyNearby : ICondition
    {
        public Boolean test()
        {

            if (Enemy._transFlag == false)
            {
                return true;
            }
            return false;
        }
    }
}
