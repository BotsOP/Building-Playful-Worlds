using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int spellDmg;

    void start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damageable = other.gameObject.GetComponent<IDamagable>();
        if (damageable != null)
        {
            damageable.DealDamage(spellDmg);
            Destroy(gameObject);
        }
        if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
