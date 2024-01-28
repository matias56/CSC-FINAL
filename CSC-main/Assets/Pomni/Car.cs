using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject[] clowns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Honk"))
        {
            Instantiate(clowns[Random.Range(0,3)], this.transform.position, Quaternion.identity);
            Instantiate(clowns[Random.Range(0, 3)], this.transform.position, Quaternion.identity);
            Instantiate(clowns[Random.Range(0, 3)], this.transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
