using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.FSM;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;

namespace MarkovChains.FSM
{
    /** 
     * The State interface which will represent the
     * game states that are possible (Combat, Exploration, etc.)
     * Each of these states will have their own transition matrix
     * and state vector (represented as a 2D array and dictionary,
     * respectively.
     */

    public interface IState
    {
        /**
         * Member function that finds the next note in the
         * state vector to play. This performs the Markov
         * chaining needed for the AI.
         * @param a string variable that represents the
         *          current chain, which consists of the
         *          previous and current note
         * @return a char variable that represents the
         *          next note to play.
         */
        char findNextNote(string currentChain);

        /**
         * Member function that returns the list of transitions
         * that go from this state to another state.
         * @return a list of transitions.
         */
        LinkedList<ITransition> getTransitions();

        /**
         * Member function that sets the list of transitions
         * for this state.
         * @param a list of transitions.
         */
        void setTransitions(LinkedList<ITransition> transitions);

        /**
         * Member function that sets the name of the current
         * state.
         * @param a string for the name of the state
         */
        void setStateName(string currentStateName);

        /**
         * Member function that returns the name of the
         * current state.
         * @return a string for the name of the current state
         */
        string getStateName();

        /**
         * Member function that sets the initial note for 
         * a specific state.
         * @param a string that sets the initial note for states
         */
        void setInitialNote(string initNote);

        /**
         * Member function that returns the initial note for
         * a specific state.
         * @return a string that represents the first note to be
         * played when this state becomes active
         */
        string getInitialNote();
    }
}
