using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    [SerializeField] string[] loadingString;
    [SerializeField] float durationEachText;
    Text loadingText;
    
    float currentTime;
    int currentTextID;

    void Start()
    {
        loadingText = GetComponent<Text>();  
        currentTextID = 0;
        loadingText.text = loadingString[currentTextID];

        currentTime = durationEachText;  
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime<=0){
            currentTextID = (currentTextID + 1) % loadingString.Length;
            loadingText.text = loadingString[currentTextID];
            currentTime = durationEachText;
        }
    }
}
