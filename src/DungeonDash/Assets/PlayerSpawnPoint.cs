using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    protected Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
