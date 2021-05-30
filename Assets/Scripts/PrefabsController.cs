using Board;
using UnityEngine;

public class PrefabsController : MonoBehaviour
{
    public BoardElement boardElement;
    
    public static PrefabsController Instance { get; private set; }
    
    private void Awake()
    {
        if(Instance != null)
            return;

        Instance = this;
    }

}