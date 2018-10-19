using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class ProgramUI
    {
        private Settings _set;
        private string[] _turns;

        public ProgramUI()
        {
            _set = new Settings();
        }

        public void Run()
        {
            GetTurns();
            Play();
        }

        private void Play()
        {
            foreach (string turn in _turns)
            {
                GetNewScore(turn);
                CheckNextNewLife();
                Console.WriteLine(turn);
                if (_set.lives == 0) break;
            }
        }

        private void CheckNextNewLife()
        {
            _set.checkNewLife = _set.score / 10000;

            if(_set.checkNewLife > _set.newLifeCount)
            {
                _set.newLifeCount++;
                _set.lives++;
            }
        }

        private void GetNewScore(string turn)
        {
            switch (turn.ToLower())
            {
                case "dot":
                    _set.score += 10;
                    break;
                case "cherry":
                    _set.score += 100;
                    break;
                case "strawberry":
                    _set.score += 300;
                    break;
                case "orange":
                    _set.score += 500;
                    break;
                case "apple":
                    _set.score += 700;
                    break;
                case "melon":
                    _set.score += 1000;
                    break;
                case "galaxian":
                    _set.score += 2000;
                    break;
                case "bell":
                    _set.score += 3000;
                    break;
                case "key":
                    _set.score += 5000;
                    break;
                case "invincibleghost":
                    _set.lives--;
                    break;
                case "vulnerableghost":
                    var newPoints = Convert.ToInt32(200 * Math.Pow(2, _set.successiveGhostCount));
                    _set.successiveGhostCount++;
                    _set.score += newPoints;
                    break;
            }
        }

        private void GetTurns()
        {
            var fileText = System.IO.File.ReadAllText("PacmanOrder.txt");
            var turns = fileText.Split(',');
            _turns = turns;
        }
    }
}
