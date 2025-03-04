using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public LookAtPlayer turretScript;
    public PlayerHealth HPscript;
    [SerializeField] int bulletDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        // turretScript = GameObject.Find("Head").GetComponent<LookAtPlayer>();

        turretScript = FindObjectOfType<LookAtPlayer>();

        HPscript = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamagePlayer();
    }

    void DamagePlayer()
    {
        HPscript.playerHealth = HPscript.playerHealth - bulletDamage;
        Debug.Log(HPscript.playerHealth);
    }
}
