using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.FSM;
using MarkovChains.src.Actions;
using MarkovChains.src.Conditions;
using MarkovChains.Audio;
using MarkovChains.Managers;

namespace MarkovChains.FSM
{
    class State : IState
    {
        public string prefix = "";
        //private class variables
        private MarkovMatrix<string, char> _markovMatrix; //the Markov Matrix
        private MarkovMatrix<string, char> _hatMatrix;
        private ITransition _stateTrans; //the transitions for this state
        private Random _rand; //random variable used for Markov chaining
        private string _stateName; //name for the current state
        private string _initNote;  //the initial note to be played when new state becomes active

        //Constructor
        public State(string stateName)
        {
            _rand = new Random(1337);
            //run sickshitsample.txt with timestep = to .15f and 2nd or 3rd or 6th order markov
            if (stateName == "exploration")
            {
                _markovMatrix = AudioManager.Instance.SampleAudioTab("Content\\Audio\\MarkovSamples\\sickshitsample.txt", 2);
                _stateName = "exploration";
                _initNote = "BA";
            }
            else if (stateName == "combat")
            {
                _markovMatrix = AudioManager.Instance.SampleAudioTab("Content\\Audio\\MarkovSamples\\sickershitsample.txt", 2);
                _stateName = "combat";
                _initNote = "DA";
            }
            else if (stateName == "drum")
            {
                _markovMatrix = AudioManager.Instance.SampleAudioTab("Content\\Audio\\MarkovSamples\\hatsample.txt", 2);
                _stateName = "drum";
                _initNote = "AA";
            }
        }

        //This is our action to perform
        public string findNextNote(string currentChain)
        {
            int currentState = 0;       //index of currentChain
            float targetSum = 0;        //random sum based on totalProbability
            float tempSum = 0;          //sum to compare to targetSum
            int nextNote = 0;           //index of nextNote to play
            float totalProbability = 0; //probability of nextNote from currentChain

            //for (int i = 0; i < _markovMatrix.getKeys().Count; i++)
            //{
            //    if (_markovMatrix.getKeys().ElementAt(i) == currentChain)
            //    {
            //        currentState = i;
            //    }
            //}

            currentState = _markovMatrix.getKeys().IndexOf(currentChain);

            for (int i = 0; i < _markovMatrix.getValues().Count; i++)
            {
                totalProbability += _markovMatrix.getProbValue(currentChain, _markovMatrix.getValues().ElementAt(i));
            }

            targetSum = randTargetSum(totalProbability);

            while (nextNote < _markovMatrix.getValues().Count && 
                tempSum + _markovMatrix.getProbValue(currentChain, _markovMatrix.getValues().ElementAt(nextNote)) < targetSum)
            {
                tempSum += _markovMatrix.getProbValue(currentChain, _markovMatrix.getValues().ElementAt(nextNote));
                nextNote++;
            }

            nextNote = nextNote >= _markovMatrix.getValues().Count ? _markovMatrix.getValues().Count - 1 : nextNote;

            string noteToPlay = prefix + _markovMatrix.getValues().ElementAt(nextNote);
            return noteToPlay;
        }

        public ITransition getTransitions()
        {
            return _stateTrans;
        }

        public void setTransitions(ITransition transitions)
        {
            _stateTrans = transitions;
        }

        private float randTargetSum(float totalProb)
        {
            return (float)_rand.NextDouble();
        }

        public void setStateName(string currentStateName)
        {
            _stateName = currentStateName;
        }

        public string getStateName()
        {
            return _stateName;
        }

        public void setInitialNote(string initNote)
        {
            _initNote = initNote;
        }

        public string getInitialNote()
        {
            return _initNote;
        }
    }
}
