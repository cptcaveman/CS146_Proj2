using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.FSM
{
    public interface IState
    {
        /**
	     * Determines the action appropriate for being in this state. 
	     * @return Action for being in this state.
	     */
        Actions.IAction getAction();

        /**
         * sets the action returned while in the state.
         * @param action action to set
         */
        void setAction(Actions.IAction action);

        /**
         * Generates the action for entering this state.
         * @return The action associated with entering this state.
         */
        Actions.IAction getEntryAction();

        /**
         * Sets the action for entering the state.
         * @param action Entrance action.
         */
        void setEntryAction(Actions.IAction action);

        /**
         * Retrieves the action for exiting this state.
         * @return The action associated with exiting this state.
         */
        Actions.IAction getExitAction();

        /**
         * Sets the action for exiting the state.
         * @param action Exit action.
         */
        void setExitAction(Actions.IAction action);


        /**
         * Accessor for all transitions out of this state.
         * @return The outbound transitions from this state.
         */
        List<ITransition> getTransitions();

        /**
         * Sets the transition collection for this state.
         * @param trans the transitions
         */
        void setTransitions(List<ITransition> trans);
    }
}
