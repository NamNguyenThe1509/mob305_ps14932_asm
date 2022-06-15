using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dichuyen : MonoBehaviour
{
    public Animator ani;
    public static bool isright=true;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static bool isDestroy = false;
    public AudioSource MainSoud;
   
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        MainSoud.Play();
        MainSoud.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            isright = true;
            ani.SetBool("isRunning", true);
            //ani.Play("mainstart");
            transform.Translate(Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(1F, 1F,1F);
        }
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            isright = false;
            ani.SetBool("isRunning", true);
            ani.Play("mainstart");
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(-1F, 1F, 1F);
        }
       if((Input.GetKey(KeyCode.DownArrow)))
         {
            if (isright)
            {
                transform.Translate(Time.deltaTime * 10, 0, 0);
            }
            else
            {
                transform.Translate(-Time.deltaTime * 10, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(isright)
            {
                ani.SetBool("isRunning", false);
                ani.Play("mainbegin");
                transform.Translate(0, (float)0.1, 0);
                transform.localScale = new Vector3(1F, 1F, 1F);
            }
            else
            {
                ani.SetBool("isRunning", false);
                ani.Play("mainbegin");
                transform.Translate(0, (float)0.1, 0);
                transform.localScale = new Vector3(-1F, 1F, 1F);
            }
        }
        if (!Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow))
        {
            ani.SetBool("isRunning", false);
            ani.Play("mainbegin");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(isright)
        {
            Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, transform.position.y + 0.7f, transform.position.z), transform.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, new Vector3(transform.position.x - 1f, transform.position.y + 0.7f, transform.position.z), transform.rotation);
        }
      
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "KillPlayer")
        {
            isDestroy = true;
            Destroy(GameObject.Find("MainChar"));
            start.lose = true;
        }
        if (hitInfo.gameObject.tag == "ngoi_sao")
        {
            if(start.count>=1)
            {
                Debug.Log("có chạm");
                Sao.isEat = true;
            }
        }
    }
}
