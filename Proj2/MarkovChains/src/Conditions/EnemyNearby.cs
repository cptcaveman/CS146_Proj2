using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.src.Enemies;
using MarkovChains.src.Player;
using MarkovChains.Screens;

namespace MarkovChains.src.Conditions
{
    class EnemyNearby : ICondition
    {
        public Boolean test()
        {
            foreach (Enemy e in TestScreen._enemyList)
            {
                if (e._transFlag == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
