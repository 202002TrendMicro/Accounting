using NUnit.Framework;

namespace AccountingWebTests.PageObjects
{
    [TestFixture]
    public class ScoreDashBoardTests
    {
        private ScoreDashBoard _scoreDashBoard;

        [SetUp]
        public void SetUp()
        {
            _scoreDashBoard = new ScoreDashBoard("Allen", "Bob");
        }

        [Test]
        public void love_all()
        {
            ScoreShouldBe("Love All");
        }

        [Test]
        public void Fifteen_Love()
        {
            GivenFirstPlayerScore(1);
            ScoreShouldBe("Fifteen Love");
        }

        [Test]
        public void Thirty_Love()
        {
            GivenFirstPlayerScore(2);
            ScoreShouldBe("Thirty Love");
        }

        [Test]
        public void Forty_Love()
        {
            GivenFirstPlayerScore(3);
            ScoreShouldBe("Forty Love");
        }

        [Test]
        public void Love_Fifteen()
        {
            GivenSecondPlayerScore(1);
            ScoreShouldBe("Love Fifteen");
        }

        [Test]
        public void Love_Thirty()
        {
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Love Thirty");
        }

        [Test]
        public void Fifteen_All()
        {
            GivenFirstPlayerScore(1);
            GivenSecondPlayerScore(1);
            ScoreShouldBe("Fifteen All");
        }

        [Test]
        public void Thirty_All()
        {
            GivenFirstPlayerScore(2);
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Thirty All");
        }

        [Test]
        public void Deuce()
        {
            GivenDeuce();
            ScoreShouldBe("Deuce");
        }

        [Test]
        public void FirstPlayer_Adv()
        {
            GivenDeuce();
            GivenFirstPlayerScore(1);
            ScoreShouldBe("Allen Adv");
        }

        [Test]
        public void SecondPlayer_Adv()
        {
            GivenDeuce();
            GivenSecondPlayerScore(1);
            ScoreShouldBe("Bob Adv");
        }

        [Test]
        public void SecondPlayer_Win()
        {
            GivenDeuce();
            GivenSecondPlayerScore(2);
            ScoreShouldBe("Bob Win");
        }

        private void GivenDeuce()
        {
            GivenFirstPlayerScore(3);
            GivenSecondPlayerScore(3);
        }

        private void GivenSecondPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _scoreDashBoard.SecondPlayerScore();
            }
        }

        private void GivenFirstPlayerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _scoreDashBoard.FirstPlayerScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _scoreDashBoard.Score());
        }
    }
}