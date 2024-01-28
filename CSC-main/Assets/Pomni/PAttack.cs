using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    

    private Animator anim;
    private Pomni playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    public bool att;

    public bool soda;

    public GameObject sodaT;

    public bool honk;

    public GameObject honkT;

    public float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Pomni>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)
        {
            StartCoroutine(PieThrow());
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)
        {
            StartCoroutine(HonkT());
        }

        if (Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)
        {
            StartCoroutine(SodaT());
            
        }

        if (att == true)
        {
            anim.SetBool("attack", att = true);

            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            att = false;

            timer = 0.5f;

        }


        if (att == false)
        {
            anim.SetBool("attack", false);
        }

        cooldownTimer += Time.deltaTime;

        if (honk == true)
        {
            anim.SetBool("honk", honk = true);

            honkT.SetActive(true);

            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            honk = false;

            timer = 0.5f;

        }


        if (honk == false)
        {
            honkT.SetActive(false);
            anim.SetBool("honk", false);
        }

        cooldownTimer += Time.deltaTime;

        if (soda == true)
        {
            anim.SetBool("soda", soda = true);

            sodaT.SetActive(true);

            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            soda = false;

            timer = 0.5f;

        }


        if (soda == false)
        {
            sodaT.SetActive(false);
            anim.SetBool("soda", false);
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        
        
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Pie>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }


    public IEnumerator PieThrow()
    {
            att = true;


        yield return null;




    }

    public IEnumerator SodaT()
    {
        soda = true;


        yield return null;




    }

    public IEnumerator HonkT()
    {
        honk = true;


        yield return null;




    }
}
