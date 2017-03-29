using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTicTacToe
{
    [TestClass]
    public class UnitTestBoard
    {

        // Board
        // -------
        // |8|3|4|
        // -------
        // |1|5|9|
        // -------
        // |6|7|2|
        // -------
        
        [TestMethod]
        public void TestBoard_FirstMove()
        {
            Board board = new Board();
            board.Go(0);
            Assert.AreEqual(State.X, board.BoardPositions[0]);
        }

        [ExpectedException(typeof(Exception), "Board not empty at position")]
        [TestMethod]
        public void TestBoard_PlaceSecondPlayerMove_InvalidMoveException()
        {
            Board board = new Board();
            board.Go(0);
            board.Go(0);
        }

        [TestMethod]
        public void TestBoard_PlaceSecondPlayerOnBoard_ValidMove()
        {
            Board board = new Board();
            board.Go(0);
            board.Go(5);

            Assert.AreEqual(State.O, board.BoardPositions[5]);
        }

        [TestMethod]
        public void TestBoardWin_TestMovesWin_FirstMoveReturnEmpty()
        {
            Board board = new Board();

            Assert.AreEqual(-1, board.PossibleWin(State.X));
        }

        [TestMethod]
        public void TestBoard_TestEmptyBoard()
        {
            Board board = new Board();

            for(int i=0; i<9;i++)
            {
                Assert.AreEqual(State.Empty, board.BoardPositions[i]);
            }
        }

        [TestMethod]
        public void TestBoard_TestPossibleWinTopRow_WinForCrossAtPosition2()
        {
            Board board = new Board();

            board.Go(0);
            board.Go(4);
            board.Go(1);
            board.Go(5);
            Assert.AreEqual(2, board.PossibleWin(State.X));
        }

        [TestMethod]
        public void TestBoard_TestPossibleWinTopRow_WinForNoughtAtPosition4()
        {
            Board board = new Board();

            board.Go(0);
            board.Go(4);
            board.Go(1);
            board.Go(5);
            board.Go(6);
            Assert.AreEqual(3, board.PossibleWin(State.O));
        }
    }
}
