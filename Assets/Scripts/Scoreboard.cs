using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI[] username;
    public TextMeshProUGUI[] scoreBoard;
    private string baseUrl = "http://134.209.97.218:5051/scoreboards/13517074";
    private bool updated = false;
    private List<Score> scoreList;

    class GFG : IComparer<Score>
    {   
        public int Compare(Score x, Score y)
        {
            if(x == null || y == null)
            {
                return 0;
            }

            return y.score.CompareTo(x.score);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreList = new List<Score>();
        StartCoroutine(GetScoreboard(baseUrl));
    }

    // Update is called once per frame
    void Update()
    {
        if ((scoreList.Count > 0) && !updated)
        {
            scoreList.Sort(new GFG());
            int count;


            if (scoreList.Count <= 5)
            {
                count = scoreList.Count;
            }
            else
            {
                count = 5;
            }


            for (int i = 0; i < count; i++)
            {
                username[i].text = scoreList[i].username;
                scoreBoard[i].text = scoreList[i].score.ToString();
            }

            updated = true;
        }
    }

    IEnumerator GetScoreboard(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //scoreList = JsonUtility.FromJson<Score>(webRequest.downloadHandler.text);
                String[] scorelist = webRequest.downloadHandler.text.Replace("null","\"0\"").Trim('[').Trim(']').Split('}');
                for (int i = 0; i < scorelist.Length-1; i++)
                {
                    scoreList.Add(JsonUtility.FromJson<Score>(scorelist[i].Trim(',') + '}'));
                }
            }
        }
    }
}
