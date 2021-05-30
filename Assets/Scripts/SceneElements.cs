using UnityEngine;

public class SceneElements : MonoBehaviour
{
    public Transform boardParent;
    public Transform player;
    
    public static SceneElements Instance { get; private set; }
    
    private void Awake()
    {
        if(Instance != null)
            return;

        Instance = this;
    }
}