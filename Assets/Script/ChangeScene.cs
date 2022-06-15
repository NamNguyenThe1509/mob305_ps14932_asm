using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ToLogin()
    {
        SceneManager.LoadScene("DangNhap");
    }
    public void ToRegister()
    {
        SceneManager.LoadScene("DangKy");
    }
    public void ToLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoardScene");
    }
    public void ToPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Man1()
    {
        SceneManager.LoadScene("Man1");
    }
    public void Man2()
    {
        SceneManager.LoadScene("Man2");
    }
    public void ManChoi()
    {
        SceneManager.LoadScene("ManChoi");
    }
}
