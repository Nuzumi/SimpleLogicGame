using System;
using UnityEngine;

namespace Board
{
    public class BoardController
    {
        public event Action OnBoardWon;
        public event Action OnNoMoreMoves;

        private BoardState state;
        private BoardCreator creator;

        public BoardController()
        {
            creator = new BoardCreator();
        }

        public void SetState(BoardState state) => this.state = state;

        public void CreateBoard()
        {
            creator.DestroyBoard();
            creator.CreateBoard(state.board);
        }

        public void Move()
        {
            PerformMoveAction();

            if (state.GetMovesLeft() == 0)
            {
                OnBoardWon?.Invoke();
                return;
            }

            if (!state.HasMoveToMake())
                OnNoMoreMoves?.Invoke();
                
        }

        private void PerformMoveAction()
        {
            BoardElementState targetState = state.board[state.playerPosition.x, state.playerPosition.y];
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
            if (!state.board.FitInBounds(newPosition))
                return true;

            return state.board[newPosition.x, newPosition.y] == null;
        }
    }
}