using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;

    public GameObject deathEffect;
    public Rigidbody rigidBod;
    public AudioSource Zombie_Sound;
    public AudioSource Yamete_Sound;
    void Start()
    {
        Zombie_Sound.Play();
        Zombie_Sound.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Dichuyen.isDestroy==false)
        {
            if (transform.position.x < GameObject.Find("MainChar").transform.position.x)
            {

                transform.Translate((float)0.01, 0, 0);
                transform.localScale = new Vector3(-1F, 1F, 1F);
            }
            else
            {
                transform.Translate(-(float)0.01, 0, 0);
                transform.localScale = new Vector3(1F, 1F, 1F);
            }
        }
     
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Yamete_Sound.Play();
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        /* Instantiate(deathEffect, transform.position, Quaternion.identity);*/
        start.count++;
        Destroy(gameObject);
        Debug.Log(start.count);
        Zombie_Sound.Stop();
    }
}
