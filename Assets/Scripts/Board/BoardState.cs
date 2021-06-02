using System.Linq;
using UnityEngine;

namespace Board
{
    public class BoardState
    {
        public BoardElementState[,] board;
        public Vector2Int playerPosition;

        public int GetMovesLeft()
        {
            int result = 0;
            foreach (var item in board)
            {
                if (item == null) continue;

                result += item.Number;
            }

            return result;
        }

        public bool HasMoveToMake()
        {
            Vector2Int[] directions = new Vector2Int[] { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };
            return directions.Any(CanMoveInDirection);
        }

        private bool CanMoveInDirection(Vector2Int direction)
        {
            Vector2Int position = playerPosition + direction;
            if (!board.FitInBounds(position))
                return false;

            if (board[position.x, position.y] == null)
                return false;

            return board[position.x, position.y].Number != 0;
        }
    }
}