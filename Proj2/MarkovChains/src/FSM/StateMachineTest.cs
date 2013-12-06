using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;
using MarkovChains.FSM;

namespace MarkovChains.FSM
{
    /*
     * A simple testing class that sees if 
     * the state machine works with performing
     * Markov Chaining. Contains all testing inside
     * a single class which makes it easier to use
     * inside of the Game1 class.
     */
    class StateMachineTest
    {
        public void update()
        {
            StateMachine SM = new StateMachine();
            State exploration = new State();
            SM.setCurrentState(exploration);
            SM.getCurrentState().setStateName("exploration");
            SM.getCurrentState().setInitialNote("AA");
            string currentChain = SM.getCurrentState().getInitialNote();
            char currentNote;
            Console.WriteLine("current state: " + SM.getCurrentState().getStateName());
            Console.WriteLine("current note: A");
            Console.WriteLine("current note: A");
            for(int i = 0; i < 50; i++){
                currentNote = SM.update(currentChain);
                Console.WriteLine("currentNote: " + currentNote);
                currentChain += currentNote;
                currentChain = currentChain.Substring(1);
                Console.WriteLine("current chain: " + currentChain);
            }
        }
    }
}
