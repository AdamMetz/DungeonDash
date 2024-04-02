using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Contains("Room")) Destroy(gameObject);
    }
}
