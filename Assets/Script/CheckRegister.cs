using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class CheckRegister : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField txtUSN;
    public InputField txtPW;
    public InputField txtEmail;
    public InputField txtPlayerName;
    public Text txtAlert;

    void Start()
    {
        
    }

    // Update is called once per frame
    private IEnumerator CreateRequest()
    {
        string username = txtUSN.GetComponent<InputField>().text;
        string password = txtPW.GetComponent<InputField>().text;
        string email = txtEmail.GetComponent<InputField>().text;
        string playername = txtPlayerName.GetComponent<InputField>().text;
        if (string.Equals(username.Trim(), "") || string.Equals(password.Trim(), "") || string.Equals(email.Trim(), "") || string.Equals(playername.Trim(), ""))
        {
            txtAlert.GetComponent<Text>().text = "Missing input values";
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("fullname", playername);
            form.AddField("email", email);
            UnityWebRequest request = UnityWebRequest.Post(APIURL.REGISTER_URL, form);
            yield return request.SendWebRequest();
            string handlerTxt = request.downloadHandler.text;
            Debug.Log(request.responseCode+ handlerTxt);
            if (request.responseCode == 201)
            {
                txtAlert.GetComponent<Text>().text = "Username is existed";
            }
            else if (request.responseCode == 200)
            {
                txtAlert.GetComponent<Text>().text = "Register Successfull";
                Wait(3);
            }
            else if (request.responseCode == 400)
            {
                txtAlert.GetComponent<Text>().text = "Register Failed";
            }
            else
            {
                txtAlert.GetComponent<Text>().text = "Server Error";
            }
        }
    }

    public void Wait(int seconds)
    {
        StartCoroutine(Waiting(seconds));
    }
    private IEnumerator Waiting(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            txtAlert.text = "Going to Login. Please wait " + i + "s";
            yield return new WaitForSeconds(1);
        }
        (new ChangeScene()).ToLogin();
    }

    public void Register()
    {
        Debug.Log("Đã nhấn");
        StartCoroutine(CreateRequest());
    }
}
