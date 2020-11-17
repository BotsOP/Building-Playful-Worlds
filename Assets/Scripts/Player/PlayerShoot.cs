using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject[] spells;
    [SerializeField] int wandIndex;
    [SerializeField] Camera mCamera;
    Transform firepoint;
    public RaycastHit whatIHit;
    void Start()
    {
        firepoint = GameObject.Find("Firepoint").GetComponent<Transform>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out whatIHit, Mathf.Infinity);
            CastSpell();
        }
    }

    void CastSpell()
    {
        Vector3 fireDirection = whatIHit.point - firepoint.position;
        
        if(wandIndex == 2)
        {
            Instantiate(spells[wandIndex], transform.position + new Vector3(0, 100, 0), Quaternion.LookRotation(fireDirection, Vector3.up));
        }
        else
        {
            Instantiate(spells[wandIndex], firepoint.position, Quaternion.LookRotation(fireDirection, Vector3.up));
        }
    }
}
