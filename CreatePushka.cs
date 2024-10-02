using System.Collections;
using UnityEngine;

public class CreatePushka : MonoBehaviour
{
    public GameObject pushka;
    public GameObject pushka2;
    public GameObject pushka3;
    public GameObject surican4;
    public GameObject surican5;

    private bool isSpawn;

    private void Update()
    {

        if (!isSpawn)
        {
            StartCoroutine(spawnPushka());
            isSpawn = true;
        }

    }

    IEnumerator spawnPushka()
    {
        while (true)
        {
            Instantiate(pushka, new Vector2(-3.3f, 3.1f), Quaternion.identity); // -3.3 это по x, 3 это по y
            yield return new WaitForSeconds(1.5f);
            Instantiate(pushka2, new Vector2(1.731f, 3.579f), Quaternion.identity); // -3.3 это по x, 3 это по y
            Instantiate(pushka3, new Vector2(7.453f, 1.17f), Quaternion.identity); // -3.3 это по x, 3 это по y
            yield return new WaitForSeconds(1f);
            Instantiate(surican4, new Vector2(-2.316f, -4.099f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(surican5, new Vector2(1.48f, -2.73f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

}
