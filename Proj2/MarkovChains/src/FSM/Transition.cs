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
    class Transition : ITransition
    {
        //private class variables
	    private IState myTargetState;
	    private IAction myAction;
	    private ICondition myCondition;

	    public IState getTargetState() {
		    return myTargetState;
	    }

	    public IAction getAction() {
		    return myAction;
	    }

	    public void setCondition(ICondition condition) {
		    myCondition = condition;
	    }

	    public void setTargetState(IState targetState) {
		    myTargetState = targetState;
	    }

	    public void setAction(IAction action) {
		    myAction = action;
	    }

	    public Boolean isTriggered() {
		    return myCondition.test();
	    }
    }
}
