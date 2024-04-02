using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRooms : MonoBehaviour
{
    public int roomSceneIndex;
    private LayerMask enemiesLayer;
    public Animator moveRoomsAnimator;

    void Start()
    {
        enemiesLayer = LayerMask.GetMask("Enemies");
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player" && !CheckForEnemies())
        {
            moveRoomsAnimator = GameObject.Find("RoomTransition").GetComponent<Animator>();
            StartCoroutine(EnterNewRoom());
        }
    }

    public IEnumerator EnterNewRoom() 
    {
        moveRoomsAnimator.SetTrigger("LeavingRoom");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(roomSceneIndex, LoadSceneMode.Single);
        moveRoomsAnimator.SetTrigger("EnteringRoom");
    }

    private bool CheckForEnemies() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 500f, enemiesLayer);
        return colliders.Length > 0;
    }
}
