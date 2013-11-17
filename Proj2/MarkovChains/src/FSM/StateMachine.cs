using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.FSM
{
    class StateMachine : IStateMachine
    {
        //private class variables
        private List<Actions.IAction> actions;
        private IState prevState, currState;

        public StateMachine()
        {
        }

        public List<Actions.IAction> update(Game1 game)
        {
            Boolean triggered = false;
            foreach (ITransition trans in currState.getTransitions())
            {
                if (trans.isTriggered(game))
                {
                    triggered = true;
                    if (currState.getExitAction() != null)
                    {
                        actions.Add(currState.getExitAction());
                    }
                    if (currState.getAction() != null)
                    {
                        actions.Add(currState.getAction());
                    }
                    currState = trans.getTargetState();
                    if (currState.getEntryAction() != null)
                    {
                        actions.Add(currState.getEntryAction());
                    }
                    break;
                }
            }
            if (!triggered)
            {
                actions.Add(currState.getAction());
            }

            return actions;
        }

        public IState getCurrentState()
        {
            return currState;
        }

        public void setCurrentState(IState state)
        {
            currState = state;
        }

        public IState getPreviousState()
        {
            return prevState;
        }

        public void setPreviousState(IState state)
        {
            prevState = state;
        }
    }
}
