using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.FSM;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;

namespace MarkovChains.FSM
{
    class State : IState
    {
        public static readonly int STATES = 7;
        //private class variables
        private int[,] _transMatrix; //the transition matrix
        private string[] _stateVector; //the state vector
        private LinkedList<ITransition> _stateTrans; //the transitions for this state

        //Constructor
        public State()
        {
            _transMatrix = new int[STATES, STATES];
            _stateVector = new string[STATES];
        }

        public void initializeTransMatrix()
        {
            //These probabilities are hardcoded for now since
            //we do not have the function that reads in a piece
            //of music yet. Shitty code, but it's just for testing.

            //Probabilities for the A note
            _transMatrix[0, 0] = 20;
            _transMatrix[0, 1] = 15;
            _transMatrix[0, 2] = 10;
            _transMatrix[0, 3] = 5;
            _transMatrix[0, 4] = 30;
            _transMatrix[0, 5] = 13;
            _transMatrix[0, 6] = 7;

            //Probabilities for the B note
            _transMatrix[1, 0] = 15;
            _transMatrix[1, 1] = 20;
            _transMatrix[1, 2] = 5;
            _transMatrix[1, 3] = 15;
            _transMatrix[1, 4] = 20;
            _transMatrix[1, 5] = 10;
            _transMatrix[1, 6] = 15;

            //Probabilities for the C note
            _transMatrix[2, 0] = 5;
            _transMatrix[2, 1] = 10;
            _transMatrix[2, 2] = 25;
            _transMatrix[2, 3] = 25;
            _transMatrix[2, 4] = 10;
            _transMatrix[2, 5] = 15;
            _transMatrix[2, 6] = 10;

            //Probabilities for the D note
            _transMatrix[3, 0] = 10;
            _transMatrix[3, 1] = 25;
            _transMatrix[3, 2] = 15;
            _transMatrix[3, 3] = 5;
            _transMatrix[3, 4] = 20;
            _transMatrix[3, 5] = 5;
            _transMatrix[3, 6] = 20;

            //Probabilities for the E note
            _transMatrix[4, 0] = 30;
            _transMatrix[4, 1] = 5;
            _transMatrix[4, 2] = 25;
            _transMatrix[4, 3] = 10;
            _transMatrix[4, 4] = 15;
            _transMatrix[4, 5] = 5;
            _transMatrix[4, 6] = 10;

            //Probabilities for the F note
            _transMatrix[5, 0] = 10;
            _transMatrix[5, 1] = 25;
            _transMatrix[5, 2] = 5;
            _transMatrix[5, 3] = 15;
            _transMatrix[5, 4] = 20;
            _transMatrix[5, 5] = 15;
            _transMatrix[5, 6] = 10;

            //Probabilities for the G note
            _transMatrix[6, 0] = 10;
            _transMatrix[6, 1] = 15;
            _transMatrix[6, 2] = 20;
            _transMatrix[6, 3] = 5;
            _transMatrix[6, 4] = 5;
            _transMatrix[6, 5] = 10;
            _transMatrix[6, 6] = 35;
        }

        public int[,] getTransMatrix()
        {
            return _transMatrix;
        }

        public void initializeStateVector()
        {
            _stateVector[0] = "A";
            _stateVector[1] = "B";
            _stateVector[2] = "C";
            _stateVector[3] = "D";
            _stateVector[4] = "E";
            _stateVector[5] = "F";
            _stateVector[6] = "G";
        }

        public string[] getStateVector()
        {
            return _stateVector;
        }

        //This is our action to perform
        public string findNextNote(string currentNote, Random rand)
        {
            
            int currentState = 0;       //index of currentNote
            int targetSum = 0;          //random sum based on totalProbability
            int tempSum = 0;            //sum to compare to targetSum
            int nextNote = 0;           //index of nextNote
            int totalProbability = 0;   //probabality of nextNote from currentNote
            
            //find index of stateVector we're at based on
            //currentNote being passed in
            for (int i = 0; i < STATES; i++)
            {
                if (_stateVector[i] == currentNote)
                {
                    currentState = i;
                }
            }
            currentState = currentState % STATES; //makes sure that we're always 0-6

            //get probability of nextNote from currentNote
            for (int i = 0; i < STATES; i++)
            {
                totalProbability += _transMatrix[currentState, i];
            }
            //random sum variable based on totalProbability of stateVector
            targetSum = rand.Next(totalProbability);
            Console.WriteLine("targetSum: " + targetSum);
            //keep going through stateVector until we've run out of indices
            //or when our targetSum has been surpassed
            while(nextNote < STATES && tempSum+_transMatrix[currentState, nextNote] < targetSum){
                tempSum += _transMatrix[currentState, nextNote];
                nextNote++;
            }

            //return the value of the index at nextNote
            return _stateVector[nextNote];
        }

        public LinkedList<ITransition> getTransitions()
        {
            return _stateTrans;
        }

        public void setTransitions(LinkedList<ITransition> transitions)
        {
            _stateTrans = transitions;
        }
    }
}
