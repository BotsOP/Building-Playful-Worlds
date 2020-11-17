using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int spellDmg;
    [SerializeField] float decayTime;
    [SerializeField] int AmountPiercing;
    int piercing;
    void Start()
    {
        Debug.Log("spawned lightning");
        Destroy(gameObject, decayTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            IDamagable damageable = other.gameObject.GetComponent<IDamagable>();
            if (damageable != null)
            {
                Piercing();
                damageable.DealDamage(spellDmg);
            }
            transform.LookAt(other.transform);
        }
    }

    private void Piercing()
    {
        piercing++;
        
        if(piercing >= AmountPiercing && AmountPiercing != 0)
            Destroy(gameObject);
    }
}
