using UnityEngine;

public class HealthMinus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HeartSystem.health -= 1;
        }
        if (HeartSystem.health <= 0)
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
}
