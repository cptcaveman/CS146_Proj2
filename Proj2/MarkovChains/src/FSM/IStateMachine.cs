using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MarkovChains.src.FSM
{
    public interface IStateMachine
    {
        /**
         * The member function that performs the update on the FSM:
	     * - Test transitions for current state and moves to new state.
	     * - Returns a list of IActions that result from the current
	     *   state and any transitions, entrances and exits that may occur.
	     * returns A list of actions produced by evaluating the FSM.
	     */

        List<Actions.IAction> update(Game1 game);

        /**
         * Retrieves the current state of the finite state machine.
         * returns the current state of the finite state machine
         */

        IState getCurrentState();

        /**
         * Sets the current state of the finite state machine.
         */

        void setCurrentState(IState state);

        /**
         * Retrieves the previous state of the finite state machine.
         * returns the previous state of the finite state machine.
         */

        IState getPreviousState();

        /**
         * Sets the previous state of the finite state machien.
         */

        void setPreviousState(IState state);
    }
}
