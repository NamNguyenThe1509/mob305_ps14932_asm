using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sao : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 0;
    public static bool isEat=false;
    public GameObject Win;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(isEat)
        {
            tuHuy();
        }
       
    }
    public void tuHuy()
    {
        count++;
        transform.Rotate(0, 0.5f, 0);
        transform.localScale += new Vector3(-0.01f, -0.01f, -0.01f);
        transform.Translate(0, -0.01f, 0);
        if(count ==360)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            Win.SetActive(true);
        }    
    }
}
