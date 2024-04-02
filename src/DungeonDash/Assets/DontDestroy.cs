using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
