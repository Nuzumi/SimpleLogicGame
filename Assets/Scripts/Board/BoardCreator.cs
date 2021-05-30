using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class BoardCreator
    {
        private List<BoardElement> boardElements = new List<BoardElement>();
        
        public void CreateBoard(BoardElementState[,] board)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            var boarElement = PrefabsController.Instance.boardElement;
            var boardParent = SceneElements.Instance.boardParent;
            
            for(int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if(board[i,j] == null) continue;
                    CreateBoardElement(board[i,j], boarElement, boardParent);
                }
        }

        private void CreateBoardElement(BoardElementState state, BoardElement boarElement, Transform boardParent)
        {
            var element = Object.Instantiate(boarElement, boardParent);
            element.Setup(state);
            boardElements.Add(element);
        }

        public void DestroyBoard()
        {
            boardElements.ForEach(e => e.Destroy());
        }
    }
}
