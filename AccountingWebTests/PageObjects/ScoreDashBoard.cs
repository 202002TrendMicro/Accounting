using System;
using System.Collections.Generic;

namespace AccountingWebTests.PageObjects
{
    public class ScoreDashBoard
    {
        private readonly string _firstPlayerName;
        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };
        private readonly string _secondPlayerName;
        private int _firstPlayerScoreTimes;
        private int _secondPlayerScoreTimes;

        public ScoreDashBoard(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public string Score()
        {
            return IsSameScore()
                ? IsDeuce() ? Deuce() : AllScore()
                : IsReadyForGamePoint()
                    ? AdvState()
                    : LookupScore();
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private string AdvPlayer()
        {
            var advPlayer = _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayerName
                : _secondPlayerName;
            return advPlayer;
        }

        private string AdvScore()
        {
            return $"{AdvPlayer()} Adv";
        }

        private string AdvState()
        {
            return IsAdv() ? AdvScore() : WinScore();
        }

        private string AllScore()
        {
            return $"{_scoreLookup[_firstPlayerScoreTimes]} All";
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1;
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private bool IsReadyForGamePoint()
        {
            return _firstPlayerScoreTimes > 3 || _secondPlayerScoreTimes > 3;
        }

        private bool IsSameScore()
        {
            return _firstPlayerScoreTimes == _secondPlayerScoreTimes;
        }

        private string LookupScore()
        {
            return $"{_scoreLookup[_firstPlayerScoreTimes]} {_scoreLookup[_secondPlayerScoreTimes]}";
        }

        private string WinScore()
        {
            return $"{AdvPlayer()} Win";
        }
    }
}