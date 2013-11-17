using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.FSM
{
    public interface ITransition
    {
        /**
	     * Accesses the state that this transition leads to.
	     * @return The state this transition leads to.
	     */
         IState getTargetState();

        /**
         * Sets the target state of this transition.
         * @param targetState The target state.
         */
        void setTargetState(IState targetState);

        /**
         * Generates the action associated with taking this transition.
         * @return The action associated with taking this transition.
         */
        Actions.IAction getAction();

        /**
         * Sets the action for enacting the transition.
         * @param action Transition action.
         */
        void setAction(Actions.IAction action);

        /**
         * Sets the condition that determines if the transition is triggered.
         * @param condition A testable condition.
         */
        void setCondition(Conditions.ICondition condition);

        /**
         * Determines if this transition is triggered.
         * @return True if triggered, false if not.
         */
        Boolean isTriggered(Game1 game);
    }
}
