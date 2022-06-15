using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    Vector3 velocity;
    Vector3 newpos;
    bool huongban;
    void Start()
    {
        huongban = Dichuyen.isright;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(huongban)
        {
            newpos = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, 1.0f);
        }else
        {
            newpos = new Vector3(transform.position.x - 10f, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, 1.0f);
        }
       
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Zombie enemy = hitInfo.GetComponent<Zombie>();

        if (enemy != null)
        {      
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y,-10), transform.localRotation);
        }

    }

}
