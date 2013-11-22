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
         * Member function that initializes the transition
         * matrix for the current state. Each state will
         * have it's own transition matrix. The matrix is
         * represented as a 2D array of ints.
         */
        void initializeTransMatrix();

        /**
         * Member function that returns the transition
         * matrix for the current state.
         * @return a 2D array of ints that represents the
         *          transition matrix.
         */
        int[,] getTransMatrix();

        /**
         * Member function that initializes the array of 
         * strings which represents the vector of notes
         * possible to play.
         */
        void initializeStateVector();

        /**
         * Member function that returns the state vector
         * of notes.
         * @return an array of strings that represents the
         *          state vector
         */
        string[] getStateVector();

        /**
         * Member function that finds the next note in the
         * state vector to play. This performs the Markov
         * chaining needed for the AI.
         * @param a string variable that represents the
         *          current note being played.
         * @return a string variable that represents the
         *          next note to play.
         */
        string findNextNote(string currentNote, Random rand);

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
    }
}
