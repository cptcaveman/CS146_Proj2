using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.FSM;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;
using Microsoft.Xna.Framework;

namespace MarkovChains.FSM
{
    /**
     * The Transition interface that allows us to change
     * States (notes).
     */

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
        IAction getAction();

        /**
         * Sets the action for enacting the transition.
         * @param action Transition action.
         */
        void setAction(IAction action);

        /**
         * Sets the condition that determines if the transition is triggered.
         * @param condition A testable condition.
         */
        void setCondition(ICondition condition);

        /**
         * Determines if this transition is triggered.
         * @return True if triggered, false if not.
         */
        Boolean isTriggered();
    }
}
