using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Actions
{
    /**
     * The Action interface for the FSM.
     * This is where the actual Markov chaining
     * happens.
     */

    public interface IAction
    {
        /**
         * Generates the next note to play
         * and then returns the name of said note.
         */
        //string nextNote();
    }
}
