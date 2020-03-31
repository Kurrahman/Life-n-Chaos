using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI text;
    void Start()
    {
        text.text = Globals.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
