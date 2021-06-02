using Board;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance { get; private set; }

    public BoardController boardController;
    public PlayerController.PlayerController playerController;
    
    private void Awake()
    {
        if(Instance != null)
            return;
        Instance = this;
        
        boardController = new BoardController();
        playerController = new PlayerController.PlayerController();
    }

    public void StartGame(BoardState controllerState)
    {
        boardController.SetState(controllerState);
        boardController.CreateBoard();
        
        playerController.Setup(controllerState);
    }
}
