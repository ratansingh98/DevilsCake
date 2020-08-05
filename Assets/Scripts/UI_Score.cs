using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

    //Reference to the Text component, set in the Start() function
    private Text uiText;

    //Current score of the player
    private int score;

    //Points required to the next level (set in the Inspector)


    //Reference to the game over screen GameObject (set in the Inspector)
    [SerializeField]
    public Rigidbody2D rigidBody;

    [SerializeField]
    private GameObject StartScreen;

    [SerializeField]
    private GameObject level1;
    [SerializeField]
    private GameObject level2;

    [SerializeField]
    private GameObject level3;
    [SerializeField]
    private GameObject level4;


    [SerializeField]
    private GameObject level5;

    [SerializeField]
    private GameObject level6;

    [SerializeField]
    private GameObject level7;

    [SerializeField]
    private GameObject level8;        

    [SerializeField]
    private GameObject level9;  

    [SerializeField]
    private GameObject level10;  



    [SerializeField]
    private GameObject GameOver;

    public Text timerText;
    public Text CurrentScore;

    private float startTime;
    private float stopTime;
    private float timerTime;

    bool isRunning = false;

    public Vector2 targetPos;

	// Use this for initialization
	void Start () {
        //Get a reference to the Text component
        TimerReset();
        
        uiText = GetComponent<Text>();
        if(PlayerPrefs.GetInt("HighScore")<10){
            PlayerPrefs.SetInt("HighScore", 9999);
        }
        print(rigidBody.position);
        targetPos = rigidBody.position;

        


        //Get the sum of all the cake values around the level

	}

    void TimerReset(){
        startTime = Time.time;
    }

    public void startGame()
    {
        isRunning = true;
        StartScreen.SetActive(false);
        level1.SetActive(true);
    }

    private void Update() {
        if(isRunning){
        timerTime = stopTime+(Time.time - startTime);
        timerText.text = ((int)timerTime).ToString();
        }
    }

    public void IncreaseScore(int points) {
        //Increase the points
        score += points;
        if (score==1){
            isRunning = true;
            TimerReset();
        }
        
        
        //Check if the player has collected all the points to the next level
        if(score == 69) {
            //If so, show the game over screen
            level1.SetActive(false);
            level2.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 2";
            
            



            //Disable the player controller, so the player cannot move while the Gameover screen is on
            //FindObjectOfType<PlayerController>().enabled = false;
        }


        else if(score == 138) {
            //If so, show the game over screen
            level2.SetActive(false);
            level3.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 3";

            FindObjectOfType<PlayerController>().transform.position=targetPos;
            //Disable the player controller, so the player cannot move while the Gameover screen is on
            //FindObjectOfType<PlayerController>().enabled = false;
        }


        else if(score == 178) {
            //If so, show the game over screen
            level3.SetActive(false);
            level4.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 4";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

            //Disable the player controller, so the player cannot move while the Gameover screen is on
            //FindObjectOfType<PlayerController>().enabled = false;
        }        

        else if(score == 218) {
            //If so, show the game over screen
            level4.SetActive(false);
            level5.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 5";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

            //Disable the player controller, so the player cannot move while the Gameover screen is on
            //FindObjectOfType<PlayerController>().enabled = false;
        }        



        else if(score == 273) {
            //If so, show the game over screen
            level5.SetActive(false);
            level6.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 6";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

        }


        else if(score == 344) {
            //If so, show the game over screen
            level6.SetActive(false);
            level7.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 7";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

        }

        else if(score == 392) {
            //If so, show the game over screen
            level7.SetActive(false);
            level8.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 8";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

        }

                else if(score == 437) {
            //If so, show the game over screen
            level8.SetActive(false);
            level9.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 9";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

        }

                else if(score == 491) {
            //If so, show the game over screen
            level9.SetActive(false);
            level10.SetActive(true);
            FindObjectOfType<UI_Level>().uiText.text ="Level : 10";
            FindObjectOfType<PlayerController>().transform.position=targetPos;

        }


        else if(score == 558) {
            //If so, show the game over screen
            int savedScore = PlayerPrefs.GetInt("HighScore");
		    if (timerTime < savedScore) {
			PlayerPrefs.SetInt("HighScore", (int)timerTime);
		    }
            CurrentScore.text = "Current Time: "+((int)timerTime).ToString();

            isRunning = false;
            TimerReset();
            GameOver.SetActive(true);

            //Disable the player controller, so the player cannot move while the Gameover screen is on
            FindObjectOfType<PlayerController>().enabled = false;
        }

        //Update the Score count
        uiText.text = "Score: " + score.ToString();
    }
}
