using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebomb : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust;
    [SerializeField] int spellTickDmg;
    [SerializeField] int amountOfTicks;
    [SerializeField] int waitBetweenTick;
    [SerializeField] float thrustDegrade;
    [SerializeField] float vectorUp;
    [SerializeField] float vectorForward;
    Vector3 fireDir;
    SphereCollider collider;
    Vector3 pos;
    private IEnumerator coroutine;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        Vector3 fireDir = transform.up * vectorUp + transform.forward * vectorForward;

        if(rb.useGravity == false)
            transform.position = pos;

        rb.AddForce(fireDir * thrust);
        if(thrust > 0)
        {
            thrust -= 0.007f * thrustDegrade;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name != "Player" && other.gameObject.name != "Firebomb")
        {
            coroutine = Explode(other);
            StartCoroutine(coroutine);
        } 
    }

    private IEnumerator Explode(Collider other)
    {
        collider.radius = 5;
        rb.useGravity = false;
        pos = transform.position;
        IDamagable damageable = other.gameObject.GetComponent<IDamagable>();
        if (damageable != null)
        {
            for (int i = 0; i < amountOfTicks; i++) 
            {
                Debug.Log("TICK");
                damageable.DealDamage(spellTickDmg);
                yield return new WaitForSeconds(waitBetweenTick);
            }
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0);
    }
}
