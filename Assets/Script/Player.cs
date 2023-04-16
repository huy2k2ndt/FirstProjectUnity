using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeedX, moveSpeedY, xDir;
    public bool isFlipX = false;
    public SpriteRenderer sr;
    public Animator ant;
    public enum MovementState { idle, jump, fall, run };
    public BoxCollider2D boxCol;
    public LayerMask layerGround;
    public Text textFruit;
    public int fruits = 0;
    public AudioClip jumpSound, collectSound, dieSound;
    public AudioSource ads;
    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        ant = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void updateFlip()
    {
        if (xDir == 0) return;
        isFlipX = xDir > 0 ? false : true;
        sr.flipX = isFlipX;
    }
    public void playAudio(AudioClip name)
    {
        if (!ads || !name) return;
        ads.PlayOneShot(name);
    }
    void updateAnimation()
    {
        MovementState state = MovementState.idle;
        if (xDir > 0 || xDir < 0) state = MovementState.run;
        if (rb.velocity.y > 0.1f) state = MovementState.jump;
        else if (rb.velocity.y < -0.1f) state = MovementState.fall;
        ant.SetInteger("state", (int)state);
    }
    // Update is called once per frame
    public void move()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        float velocityX = xDir * moveSpeedX, velocityY = rb.velocity.y;
        int[] keys = { 32, 119, 273 };
        bool isJump = false;
        foreach (int key in keys)
        {
            isJump = Input.GetKeyDown((KeyCode)key) || isJump;
        }
        if (isJump && isOnGround())
        {
            velocityY = moveSpeedY;
            playAudio(jumpSound);
        }
        rb.velocity = new Vector2(velocityX, velocityY);
    }
    void Update()
    {
        move();
        updateAnimation();
        updateFlip();
    }
    public bool isOnGround()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.size, 0f, Vector2.down, .1f, layerGround);
    }
    public void checkCollectFruit(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Fruit")) return;
        playAudio(collectSound);
        ++fruits;
        updateText();
        Destroy(col.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkCollectFruit(collision);

    }
    public void checkDie(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Trap")) return;
        playAudio(dieSound);
        die();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkDie(collision);
    }
    public void die()
    {
        Debug.Log("Die");
        rb.bodyType = RigidbodyType2D.Static;
        ant.SetTrigger("Die");
    }
    public void updateText()
    {
        if (!textFruit) return;
        textFruit.text = "Fruit: " + fruits.ToString();
    }
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
