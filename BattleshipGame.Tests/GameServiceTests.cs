using BattleshipGame.Engine.Models;
using BattleshipGame.Engine.Services;
using NUnit.Framework;
using System;

namespace BattleshipGame.Tests
{
    public class GameServiceTests
    {
        private Player _player;
        private GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _player = new Player("testUser");
            _gameService = new GameService();
        }

        [Test]
        public void Is_Correct_Gameboard_Setup()
        {
            // Given
            var gameboardArray = _player.PlayerGameBoard.GameBoardArray;

            // When
            int rows = gameboardArray.GetLength(0);
            int columns = gameboardArray.GetLength(1);

            // Then
            Assert.AreEqual(rows, 10);
            Assert.AreEqual(columns, 10);
        }

        [Test]
        public void Can_Add_Ship_To_Empty_Square_Successfully()
        {
            // Given
            int startingRow = 0;
            int startingColumn = 1;
            int shipId = 10;
            _gameService.AddShip(shipId, 3, startingRow, startingColumn, OrientationType.Horizontal, _player);

            // When
            var currentSquare = _player.PlayerGameBoard.GetItem(startingRow, startingColumn);

            // Then
            Assert.AreEqual(1, _player.Ships.Count);
            Assert.AreEqual(shipId, currentSquare.GetSquareContent());
        }

        [TestCase(7, 7, 1, 7, OrientationType.Horizontal)]
        [TestCase(7, 7, 1, 7, OrientationType.Vertical)]
        [TestCase(0, 0, 1, 15, OrientationType.Vertical)]
        [TestCase(0, 0, 1, 15, OrientationType.Horizontal)]
        public void Can_Add_Ship_To_Empty_Square_TooLarge(int startingRow, int startingColumn, int shipId, int lengthOrWidth, OrientationType orientation)
        {
            // Given When Then
            Assert.Throws<ApplicationException>(() => _gameService.AddShip(shipId, lengthOrWidth, startingRow, startingColumn, orientation, _player));
        }
    }
}