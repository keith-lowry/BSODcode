using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumperPlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpVelocity;
    public Transform copiesTransform;

    private static int EXTRA_JUMPS = 1;
    private int index;
    private int children;
    private int jumpsLeft;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        jumpsLeft = EXTRA_JUMPS;

        children = copiesTransform.childCount;
        index = 0;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);

            if (inputX < 0)
            {
                sr.flipX = true;
            }
            else if (inputX > 0)
            {
                sr.flipX = false;
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && (IsGrounded() || jumpsLeft > 0))
            {
                Jump();

                if (index < children)
                {
                    copiesTransform.GetChild(index).gameObject.SetActive(true);
                    index++;
                }

                jumpsLeft--;
            }

            if (IsGrounded())
            {
                jumpsLeft = EXTRA_JUMPS;
            }

        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private bool IsGrounded()
    {
        Vector2 origin1 = new Vector2(transform.position.x - 0.2f, transform.position.y);
        Vector2 origin2 = new Vector2(transform.position.x + 0.2f, transform.position.y);

        RaycastHit2D hit1 = Physics2D.Raycast(origin1, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit2 = Physics2D.Raycast(origin2, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));

        return hit1 || hit2;
    }
}
