using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class SendNewResults : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject input;
    public Button retry;
    private Score score;
    private string baseurl = "http://134.209.97.218:5051/scoreboards/13517074";

    public void sendNewScore(String username)
    {
        score = new Score();
        score.username = username;
        score.score = Globals.score;
        StartCoroutine(Upload());
        Globals.score = 0;
        retry.Select();
        Destroy(gameObject);
    }

    IEnumerator Upload()
    {
        string form = JsonUtility.ToJson(score);
        Debug.Log(form);
        UnityWebRequest req = new UnityWebRequest(baseurl, "POST");
        req.SetRequestHeader("Content-Type", "application/json");
        req.uploadHandler = new UploadHandlerRaw(new System.Text.UTF8Encoding().GetBytes(form));
        using (UnityWebRequest www = req)
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
