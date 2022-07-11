using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    //movment
    public float movmentSpeed = 1;
    public float jumpSpeed = 1;

    public bool doubleJump;

    //direction
    public float playerDirection =1;


    //dash
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 15f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    private TrailRenderer tr;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    
    void Update()
    {
        if (!isDashing)
        {
            LookDirection();
            Movement();
        }



        if (!Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        { 
            doubleJump = false;

        }


        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y)<0.001f || doubleJump))
        {
            
            rb.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
            doubleJump = !doubleJump;
        }



        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            tr.emitting = true;
            StartCoroutine(Dash());

        }



    }


    private void Movement()
    {
        var movmentRotation = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movmentSpeed*movmentRotation,rb.velocity.y);
        //transform.position += new Vector3(movmentRotation, 0, 0) * Time.deltaTime * movmentSpeed;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float normalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(playerDirection*dashPower*1 , 0f);
        tr.emitting = true;

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = normalGravity;
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


    private void LookDirection()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerDirection = 1;
        }
        else if(Input.GetAxis("Horizontal") < 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerDirection = -1;
        }
    }
}



