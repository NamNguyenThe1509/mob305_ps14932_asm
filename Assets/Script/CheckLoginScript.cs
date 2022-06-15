using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class CheckLoginScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField txtUSN;
    public InputField txtPW;
    public Text txtAlert;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CreateRequest()
    {
        string username = txtUSN.GetComponent<InputField>().text;
        string password = txtPW.GetComponent<InputField>().text;
        JsonHelper jsHelper = new JsonHelper();
        if (string.Equals(username.Trim(), "") || string.Equals(password.Trim(), ""))
        {
            txtAlert.GetComponent<Text>().text = "Missing input values";
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            UnityWebRequest request = UnityWebRequest.Post(APIURL.LOGIN_URL, form);
            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {
                WWWForm form1 = new WWWForm();
                form1.AddField("username", username);
                UnityWebRequest request1 = UnityWebRequest.Post(APIURL.GETPLAYER_URL, form1);
                yield return request1.SendWebRequest();
                if(request1.responseCode == 200)
                {
                    (new ChangeScene()).ToPlayScene();
                }
                else
                {
                    txtAlert.GetComponent<Text>().text = "Player not exist";
                }
            }
            else
            {
                txtAlert.GetComponent<Text>().text = "LOGIN FAILED";
            }
        }
    }

    public void CheckLogin()
    {
        StartCoroutine(CreateRequest());
    }
}
