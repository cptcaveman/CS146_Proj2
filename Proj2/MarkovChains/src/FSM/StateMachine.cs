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
    class StateMachine : IStateMachine
    {
        //private class variables
        private IState _currentState;

        public void setCurrentState(IState state)
        {
            _currentState = state;
        }

        public IState getCurrentState()
        {
            return _currentState;
        }

        public string update(string currentNote)
        {
            string chain = currentNote;
            Transition trans = (Transition)_currentState.getTransitions();
            if(trans != null && trans.isTriggered()){
                {
                    setCurrentState(trans.getTargetState());
                    chain = _currentState.getInitialNote();
                }
            }
            Console.WriteLine("current state: " + _currentState.getStateName());
            return _currentState.findNextNote(chain);
        }
    }
}
