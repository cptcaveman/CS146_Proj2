using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.src.Enemies;
using MarkovChains.src.Player;
using MarkovChains.Screens;

namespace MarkovChains.src.Conditions
{
    class NotEnemyNearby : ICondition
    {
        public Boolean test()
        {
            foreach (Enemy e in TestScreen._enemyList)
            {
                if (e._transFlag == true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
