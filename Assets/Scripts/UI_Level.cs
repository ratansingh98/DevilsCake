using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Level : MonoBehaviour
{

    public Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.text = "Level : 1";

        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
