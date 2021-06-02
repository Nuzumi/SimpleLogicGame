using Board;
using Newtonsoft.Json;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextAsset level;
    
    private void Start()
    {
        Subscribe();
        StartLevel();
    }

    private void Subscribe()
    {
        var board = MainController.Instance.boardController;
        board.OnBoardWon += OnBoardWon;
        board.OnNoMoreMoves += OnNoMoreMoves;
    }

    private void OnNoMoreMoves()
    {
        Debug.Log("no more moves");
    }

    private void OnBoardWon()
    {
        Debug.Log("Booard won");
    }

    private void StartLevel()
    {
        var levelState = JsonConvert.DeserializeObject<BoardState>(level.text);
        MainController.Instance.StartGame(levelState);
    }
}
