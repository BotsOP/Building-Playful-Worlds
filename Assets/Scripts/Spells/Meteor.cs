using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 startPos;
    PlayerShoot playerShoot;
    float lerpValue;
    SphereCollider collider;
    [SerializeField] float speed;
    [SerializeField] int spellDmg;
    [SerializeField] float explodeRadius;
    void Start()
    {
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
        collider = GetComponent<SphereCollider>();
        targetPos = playerShoot.whatIHit.point;
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, targetPos, lerpValue);
        lerpValue += speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            collider.radius = explodeRadius;
            IDamagable damageable = other.gameObject.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.DealDamage(spellDmg);
            }
            Destroy(gameObject, 0.1f);
        }
        
    }
}
