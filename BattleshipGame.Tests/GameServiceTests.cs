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

        [Test]
        public void Can_Add_Ship_To_Empty_Square_Unsuccessfully()
        {
            // Given
            int startingRow = 0;
            int startingColumn = 1;
            int shipId = 10;

            // When
            _gameService.AddShip(shipId, 3, startingRow, startingColumn, OrientationType.Horizontal, _player);

            // Then
            Assert.Throws<ApplicationException>(() => _gameService.AddShip(shipId, 3, startingRow, startingColumn, OrientationType.Horizontal, _player));
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

        [Test]
        public void Can_Attack_Empty_Space()
        {
            // Given When
            var result = _gameService.AttackSquare(1, 1, _player);

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void Can_Attack_Ship()
        {
            // Given
            int row = 1;
            int columm = 1;
            _gameService.AddShip(1, 3, row, columm, OrientationType.Horizontal, _player);

            // When
            var result = _gameService.AttackSquare(1, 1, _player);

            // Then
            Assert.IsTrue(result);
            Assert.IsFalse(_player.HasPlayerLost());
        }

        [Test]
        public void Can_Attack_Ship_And_Win_SingleShip()
        {
            // Given
            int row = 1;
            int columm = 1;
            _gameService.AddShip(1, 3, row, columm, OrientationType.Horizontal, _player);

            // When
            var result1 = _gameService.AttackSquare(1, 1, _player);
            var result2 = _gameService.AttackSquare(1, 2, _player);
            var result3 = _gameService.AttackSquare(1, 3, _player);

            // Then
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(_player.HasPlayerLost());
        }

        public void Can_Attack_Ship_And_Win_MultipleShips()
        {
            // Given
            _gameService.AddShip(1, 1, 1, 1, OrientationType.Horizontal, _player);
            _gameService.AddShip(2, 1, 2, 2, OrientationType.Horizontal, _player);


            // When
            var result1 = _gameService.AttackSquare(1, 1, _player);
            var result2 = _gameService.AttackSquare(2, 2, _player);


            // Then
            Assert.IsTrue(result1);
            Assert.IsFalse(_player.HasPlayerLost());

            Assert.IsTrue(result2);
            Assert.IsTrue(_player.HasPlayerLost());
        }

    }
}