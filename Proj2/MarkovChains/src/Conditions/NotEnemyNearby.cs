using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.src.Enemies;
using MarkovChains.src.Player;

namespace MarkovChains.src.Conditions
{
    class NotEnemyNearby : ICondition
    {
        public Boolean test()
        {
            if (Enemy._transFlag == true)
            {
                return true;
            }
            return false;
        }
    }
}
