using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_2022_Demo
{
    class Player
    {
        // attributes
        
        private string _name;
        private int _playerNumber;
        private int _gamesPlayed;
        private int[] _scores;

        // static variable belong to class, no individual object has this
        public static int lastPlayerNumber = 0;
        // Name property used to get and set the name attribute of an object

        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
            set
            {
                _gamesPlayed= value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
       

 public int PlayerNumber
        {
            get
            {
                return this._playerNumber;
            }
            set
            {
                this._playerNumber = value;
            }

        }
        // Default construct
        public Player()
        {
            lastPlayerNumber++; // increment the static variable by 1
            PlayerNumber = lastPlayerNumber; // assign to the employee number
            _scores = new int[10];
            
        }

        //parameterised constructor
        public Player(string n) // we know a players name at construction time
        {
            Name = n;
           
            lastPlayerNumber++; // increment the static variable by 1
            PlayerNumber = lastPlayerNumber; // assign to the employee number
            _scores = new int[10];
        }
        // Method tp print the attributes of an object
        public override string ToString()
        {
            return "Name: " + Name +  " Player # : " + PlayerNumber;
        }
       
        public double avg()
        {
            //loop through scores array,
            //accumulating score and then divivide total by gamespplayed
            int total = 0;
            double result;
            for (int i = 0; i < GamesPlayed; i++)
            {
                total = total + _scores[i];
            }
            if (_gamesPlayed > 0)

                result = total / _gamesPlayed;

            else
                result = 0;
                return result;
        }

        public double PercentageWin()
        {
            // count all scores less than 7, divide games played
            int winCount = 0;
            for (int i = 0; i < GamesPlayed; i++)
            {
                if (_scores[i] < 7)
                    winCount++;
            }

            double result;
            if (GamesPlayed > 0)
                result = winCount / GamesPlayed * 100;
            else
                result = 0;
            return result;
        }
        public int GetScores(int i)
        {
            return _scores[i];
        }
        public void AddTurnsTaken(int t)
        {
            // records a score for a particular game
            _scores[GamesPlayed] = t;
            GamesPlayed++;
        }
    }

}
