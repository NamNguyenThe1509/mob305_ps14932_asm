using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
     void Start()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplet");
        Vector2 newpos = entryTemplate.transform.position;
        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 0.5f;
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("có chạy");
            Transform entryTranform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTranform = entryTranform.GetComponent<RectTransform>();
            entryRectTranform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTranform.gameObject.SetActive(true);
          entryTranform.Find("posText").GetComponent<Text>().text=""+i;
        } 
    }
}
