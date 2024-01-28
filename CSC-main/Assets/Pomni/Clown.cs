using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    public Animator anim;
    public bool sad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sad==true)
        {
            anim.SetBool("sad", sad);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Soda"))
        {
            Debug.Log("yes");
            sad = true;
            Destroy(this);
        }
    }
}
