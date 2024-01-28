using UnityEngine;

public class Pomni : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    

 

    public Rigidbody2D body;
    public Animator anim;
    public BoxCollider2D boxCollider;
    private float horizontalInput;

    public bool flip;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            flip = false;
            transform.localScale = Vector3.one;
        }
          
        else if (horizontalInput < -0.01f)
        {
            flip = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
            

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

      
    }

    private void Jump()
    {
      
        //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything

       

        
            if (isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            

            
    }

   

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
  
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }
}