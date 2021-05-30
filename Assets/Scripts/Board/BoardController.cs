using System;
using UnityEngine;

namespace Board
{
    public class BoardController : IDisposable
    {
        private BoardControllerState state;
        private BoardCreator creator;

        public BoardController()
        {
            creator = new BoardCreator();
        }

        public void SetState(BoardControllerState state) => this.state = state;

        public void CreateBoard()
        {
            creator.DestroyBoard();
            creator.CreateBoard(state.board);
        }

        public void Move(Vector2Int vector)
        {
            Vector2Int newPosition = state.playerPosition + vector;
            BoardElementState targetState = state.board[newPosition.x, newPosition.y];
            targetState.Number--;
        }

        public bool CanMovePlayer(Vector2Int vector)
        {
            if (WouldMoveOutOfBoard(vector))
                return false;

            if (IsTargetedPositionEmpty(vector))
                return false;

            return true;
        }

        private bool IsTargetedPositionEmpty(Vector2Int vector)
        {
            Vector2Int newPosition = state.playerPosition + vector;
            return state.board[newPosition.x, newPosition.y].Number == 0;
        }

        private bool WouldMoveOutOfBoard(Vector2Int vector)
        {
            Vector2Int newPosition = state.playerPosition + vector;
            if (newPosition.x < 0 || newPosition.y < 0)
                return true;

            if (newPosition.x >= state.board.GetLength(0) || newPosition.y >= state.board.GetLength(1))
                return true;

            return state.board[newPosition.x, newPosition.y] == null;
        }

        public void Dispose()
        {
        }
    }
}