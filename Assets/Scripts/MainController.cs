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

    public void StartGame(BoardControllerState controllerState)
    {
        boardController.Dispose();
        boardController.SetState(controllerState);
        boardController.CreateBoard();
        
        playerController.Setup(controllerState);
    }
}
