using UnityEngine;

public class WeaponSurucanNotUse : MonoBehaviour
{
    public Transform shotPosition; // пустой обьект висит на Player, позициия полета
    public GameObject Surucan; // префаб сюрикена

    private void Update() // на префабе surican скрипт со скоростью и напрвление полета
    {
        if (Input.GetKeyDown(KeyCode.X)) // при нажатии на Х кидаем сюрикен 
        {
            Instantiate(Surucan, shotPosition.transform.position, transform.rotation);
        }
    }
}
