using System.Collections.Generic;

using _4kTiles_Backend.Context;
using _4kTiles_Backend.DataObjects.DTO.LeaderboardDTO;
using _4kTiles_Backend.Services.Repositories;
using _4kTiles_Backend.Tests.Helpers;
using _4kTiles_Backend.Tests.Tests.Base;

using NUnit.Framework;

namespace _4kTiles_Backend.Tests.Tests.Units.ULeaderboard
{
    [TestFixture]
    public class LeaderboardTests
    {
        ApplicationDbContext _context;
        ILeaderboardRepository _leaderboardRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _context = BaseTest.Context;
            
            _leaderboardRepository = new LeaderboardRepository(_context);
        }

        [Test]
        public void Leaderboard_ReturnListTopBestScoreOfSong_WhenSongIdIsProvided()
        {
            // Arrange
            var expected = new List<LeaderboardAccountDTO>()
            {
                new LeaderboardAccountDTO()
                {
                    AccountId = 1,
                    UserName = "TestUser1",
                    BestScore = 100
                },
                new LeaderboardAccountDTO()
                {
                    AccountId = 2,
                    UserName = "TestUser2",
                    BestScore = 100
                }
            };

            // Action
            var actual = _leaderboardRepository.GetTopNLeaderboardBySongId(1, 10);

            // Assert
            Assert.AreEqual(expected.Serialize(), actual.Serialize());
        }

        [Test]
        public void Leaderboard_ReturnEmptyList_WhenProvidedSongIdHaveNoPlayer()
        {
            // Arrange
            var expected = new List<LeaderboardAccountDTO>();

            // Action
            var actual = _leaderboardRepository.GetTopNLeaderboardBySongId(111, 10);

            // Assert
            Assert.AreEqual(expected.Serialize(), actual.Serialize());
        }

        [Test]
        public void Leaderboard_ReturnListTop1BestScoreOfAccount_WhenAccountIdIsProvided()
        {
            // Arrange
            var expected = new List<LeaderboardUserDTO>()
            {
                new LeaderboardUserDTO()
                {
                    AccountId = 1,
                    UserName = "TestUser1",
                    SongId = 1,
                    SongName = "Song1",
                    BestScore = 100
                },
            };

            // Action
            var actual = _leaderboardRepository.GetTopOneByUserId(1);

            // Assert
            Assert.AreEqual(expected.Serialize(), actual.Serialize());
        }

        [Test]
        public void Leaderboard_ReturnEmptyList_WhenProvidedAccountIdHaveNoTopOne()
        {
            // Arrange
            var expected = new List<LeaderboardUserDTO>();

            // Action
            var actual = _leaderboardRepository.GetTopOneByUserId(111);

            // Assert
            Assert.AreEqual(expected.Serialize(), actual.Serialize());
        }
    }
}