using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HeartSystem.health -= 3;
        }
        if (HeartSystem.health <= 0)
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
}
