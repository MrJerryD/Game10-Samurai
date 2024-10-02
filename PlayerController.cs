using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 5f;
    private bool facingRight = true;

    [SerializeField] float jumpForce = 5f;
    private bool isJumping = false;

    public Transform shotPosition; // пустой обьект висит на Player, позициия полета
    public GameObject Surucan; // префаб сюрикена

    private AudioSource jumpSound;
    private AudioSource trowSurican;
    private AudioSource run;

    public Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        run = GetComponent<AudioSource>(); // Звук бега
        jumpSound = transform.Find("JumpSound").GetComponent<AudioSource>(); // Звук прыжка
        trowSurican = transform.Find("ThrowSound").GetComponent<AudioSource>(); // Звук прыжка

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // при нажатии на Х кидаем сюрикен 
        {
            Instantiate(Surucan, shotPosition.transform.position, transform.rotation);
            animator.SetBool("IsAttaking", true);
            trowSurican.Play();
        }
        else
        {
            animator.SetBool("IsAttaking", false);
        }

    }

    void FixedUpdate()
    {
        MovementPerson();

        if (Input.GetButton("Jump") && !isJumping) // прыжок и проверка если прыгаем 
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

    }

    void MovementPerson() // управление персонажа и проверка на повороты + анимация
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);

        if (horizontal != 0 && !run.isPlaying && !isJumping) // Включаем звук бега только если игрок движется, звук не воспроизводится и персонаж не в состоянии прыжка
        {
            animator.SetBool("IsRun", true);
            run.Play();
        }
        else if ((horizontal == 0 || isJumping) && run.isPlaying) // Выключаем звук бега если игрок не движется или находится в состоянии прыжка и звук воспроизводится
        {
            animator.SetBool("IsRun", false);
            run.Pause();
        }


        if (!facingRight && horizontal > 0)
        {
            FlipCharacterAndSuricanFire();
        }
        else if (facingRight && horizontal < 0)
        {
            FlipCharacterAndSuricanFire();
        }

    }

    void FlipCharacterAndSuricanFire()//  убрал localScale и поставил Rotate чтобы не просто мог поворачиваться, но и кидать сюрикены в то направление куда повернут
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        isJumping = true;
        jumpSound.Play();

    }

    // для прыжка, проверка на Ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
}