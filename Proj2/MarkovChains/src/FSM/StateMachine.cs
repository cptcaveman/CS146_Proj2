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

        public string update(string currentNote, Random rand)
        {
            return _currentState.findNextNote(currentNote, rand);
        }
    }
}
