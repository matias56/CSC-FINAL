using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] private float speed;

    public Rigidbody2D body;
    public Animator anim;
    public BoxCollider2D box;

    public GameObject pA;
    public GameObject pB;
    private Transform curP;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curP = pB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = curP.position - transform.position;
        if(curP == pB.transform)
        {
            body.velocity = new Vector2(speed,0);
        }
        else
        {
            body.velocity = new Vector2(-speed,0);
        }

        if(Vector2.Distance(transform.position, curP.position)<0.5f && curP==pB.transform)
        {
            Flip();
            curP = pA.transform;
        }

        if (Vector2.Distance(transform.position, curP.position) < 0.5f && curP == pA.transform)
        {
            Flip();
            curP = pB.transform;
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Pie"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            box.isTrigger = true;
            anim.SetBool("pied", true);
        }
    }
}
