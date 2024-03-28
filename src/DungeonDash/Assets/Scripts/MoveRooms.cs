using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRooms : MonoBehaviour
{
    public int roomSceneIndex;
    private LayerMask enemiesLayer;

    void Start()
    {
        enemiesLayer = LayerMask.GetMask("Enemies");
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.name == "Player" && !CheckForEnemies())
        {
            SceneManager.LoadScene(roomSceneIndex, LoadSceneMode.Single);
        }
    }

    private bool CheckForEnemies() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 500f, enemiesLayer);
        return colliders.Length > 0;
    }
}
