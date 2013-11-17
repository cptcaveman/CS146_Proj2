using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.FSM
{
    class Transition : ITransition
    {
        //private class variables
	    private IState myTargetState;
	    private Actions.IAction myAction;
	    private Conditions.ICondition myCondition;

	    public IState getTargetState() {
		    return myTargetState;
	    }

	    public Actions.IAction getAction() {
		    return myAction;
	    }

	    public void setCondition(Conditions.ICondition condition) {
		    myCondition = condition;
	    }

	    public void setTargetState(IState targetState) {
		    myTargetState = targetState;
	    }

	    public void setAction(Actions.IAction action) {
		    myAction = action;
	    }

	    public Boolean isTriggered(Game1 game) {
		    return myCondition.test(game);
	    }
    }
}
