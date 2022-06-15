using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public static int count=0;
    public GameObject zombie;
    public GameObject textDiem;
    public GameObject Replay;
    public static bool lose;
    int i = 2;
    System.Random r = new System.Random();
    void Start()
    {
        lose = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        textDiem.GetComponent<Text>().text = "Score:" + count.ToString();
        if (Time.time>i)
        {
            i += 2;
            GameObject clonezombie= (GameObject) Instantiate(zombie,new Vector2(r.Next(-10,10),5), Quaternion.identity);
        }
        if(lose)
        {
            GameOver();
        }
    }
    public void batDau()
    {
        SceneManager.LoadScene("ManChoi");
    }
    public void batDaulv1()
    {
        SceneManager.LoadScene("Man1");
    }
    public void batDaulv2()
    {
        SceneManager.LoadScene("Man2");
        Time.timeScale = 1;
    }
    public void backManChoi()
    {
        SceneManager.LoadScene("ManChoi");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        Replay.SetActive(true);
    }

}
