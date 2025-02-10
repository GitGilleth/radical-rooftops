using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtPlayer : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float shootRange = 10f;
    public GameObject Bullet;
    public Transform bulletSpot;
    [SerializeField] float bulletSpeed = 100f;
    [SerializeField] float timeBetweenShots = 0.5f;
    bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        if(Vector3.Distance(transform.position, Target.position) <= shootRange)
        {
            if(!isShooting)
            {
                Shoot();
                isShooting=true;
                Invoke(nameof(Cooldown), timeBetweenShots);
            }
            
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    void Cooldown()
    {
        isShooting = false;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, bulletSpot.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
