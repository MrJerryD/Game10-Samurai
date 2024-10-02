using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject pauseGameMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (HeartSystem.health <= 0)
            {
                StopGame();
            }
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            if (HeartSystem.health <= 0)
            {
                StopGame();
            }
        }
    }

    void StopGame()
    {
        pauseGameMenu.SetActive(true);
        //Time.timeScale = 0f; // Время заморожено
    }

}
