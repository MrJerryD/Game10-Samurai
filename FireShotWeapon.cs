using UnityEngine;

public class FireShotWeapon : MonoBehaviour
{
    public float speed = 2f;


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, 1.5f);

    }
}
