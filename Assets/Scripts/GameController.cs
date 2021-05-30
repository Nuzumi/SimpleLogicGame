using Board;
using Newtonsoft.Json;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextAsset level;
    
    private void Start()
    {
        var levelState = JsonConvert.DeserializeObject<BoardControllerState>(level.text);
        MainController.Instance.StartGame(levelState);
    }
}
