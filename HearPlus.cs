using UnityEngine;

public class HearPlus : MonoBehaviour
{
    //private AudioSource heartAudio;

    private void Start()
    {
        //heartAudio = transform.Find("HeartSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HeartSystem.health < 3)
            {   
                HeartSystem.health += 1;
                Destroy(gameObject);
                //heartAudio.Play();
            }
        }
    }
}
