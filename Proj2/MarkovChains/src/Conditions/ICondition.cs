using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Conditions
{
    public interface ICondition
    {
        /**
         * Evaluates the decision node's condition and returns the true or false result.
         * @return Result of evaluating the conditional expression.
         */
        Boolean test(Game1 game);
    }
}
