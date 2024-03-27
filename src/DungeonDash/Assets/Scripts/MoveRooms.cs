using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRooms : MonoBehaviour
{
    public int roomSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision) {
        print(collision.name);
        if (collision.name != "Player") return;
        SceneManager.LoadScene(roomSceneIndex, LoadSceneMode.Single);
    }
}
