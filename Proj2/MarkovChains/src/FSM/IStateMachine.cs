using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MarkovChains.FSM;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;


namespace MarkovChains.FSM
{
    /**
     * The StateMachine interface that applies transitions
     * between states and keeps track of the entire state
     * of the state machine
     */

    public interface IStateMachine
    {
        /**
         * Member function that sets the current
         * state.
         * @param A state.
         */
        void setCurrentState(IState state);

        /**
         * Member function that gets the current
         * state.
         * @return The current state.
         */
        IState getCurrentState();

        /**
         * Member function that updates the
         * state machine. The update applies the markov
         * chaining for current state as long as the
         * state remains active. If a transition occurs, the
         * state machine will switch states, which will
         * create a new markov process.
         * @param a string that contains the currentNote and
         *          a Random variable.
         */
        string update(string currentNote);
    }
}
