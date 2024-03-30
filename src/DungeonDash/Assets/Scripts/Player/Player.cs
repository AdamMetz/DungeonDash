using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Contains("Room"))
        {
            DontDestroyOnLoad(gameObject);
            SpawnPlayer();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SpawnPlayer()
    {
        GameObject playerSpawnPoint = GameObject.Find("PlayerSpawnPoint");

        if (playerSpawnPoint != null)
        {
            transform.position = new Vector3(playerSpawnPoint.transform.position.x, playerSpawnPoint.transform.position.y, transform.position.z);
        }
        else
        {
            Debug.LogError("PlayerSpawnPoint not found in the scene.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}
