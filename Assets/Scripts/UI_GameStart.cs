using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameStart: MonoBehaviour {


    [SerializeField]
    private GameObject StartScreen;

    [SerializeField]
    private GameObject level1;

    private void Start() {
        
    }

    public void startGame()
    {

        StartScreen.SetActive(false);
        level1.SetActive(true);
        }
    
    private void Update() {
        
    }


}
