using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.FSM
{
    class State : IState
    {
        //private class variables
	    private Actions.IAction myAction, myEntryAction, myExitAction;
	    private List<ITransition> myTransitions;

	    public Actions.IAction getAction() {
		    return myAction;
	    }

	    public Actions.IAction getEntryAction() {
		    return myEntryAction;
	    }

	    public Actions.IAction getExitAction() {
		    return myExitAction;
	    }

	    public List<ITransition> getTransitions() {
		    return myTransitions;
	    }

	    public void setAction(Actions.IAction action) {
		    myAction = action;
	    }

	    public void setEntryAction(Actions.IAction action) {
		    myEntryAction = action;
	    }

	    public void setExitAction(Actions.IAction action) {
		    myExitAction = action;
	    }

	    public void setTransitions(List<ITransition> trans) {
		    myTransitions = trans;
	    }
    }
}
