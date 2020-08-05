using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float y1;
    public float x1;
    public float speed = 10.0f;

    public Rigidbody2D rigidBody;
    bool currentPlatformAndroid = true;
    
    public Animator anim;



    void Awake(){
    /**
    #if UNITY_ANDROID
        currentPlatformAndroid = true;
    #else
        currentPlatformAndroid = false;
    #endif
    **/
    x1=transform.position.x;
    y1= transform.position.y;
    rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    anim = gameObject.GetComponent<Animator>();
    //PlayerPrefs.DeleteAll();
    }
    void TouchMove(){
        if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

            float middleHL = Screen.width / 4;
            float middleHR = Screen.width / 2 + Screen.width / 4;;

            float middleVT = Screen.height / 4;
            float middleVB = Screen.height / 2+Screen.height / 4;

			if (touch.position.x < middleHL && touch.position.y> middleVT && touch.position.y< middleVB) {
				MoveLeft ();
			} 
			else if (touch.position.x > middleHR && touch.position.y> middleVT && touch.position.y< middleVB) {
				MoveRight ();
			} 
            else if (touch.position.y < middleVT ) {
				MoveUp();
			} 
			else if (touch.position.y > middleVB) {
				MoveDown ();
			} 

		}

    }

    void MoveLeft (){
    var x = transform.position.x - 1 * Time.deltaTime * speed;
    var y = transform.position.y;
    rigidBody.MovePosition(new Vector2(x, y));
    }

    void MoveRight (){
    var x = transform.position.x + 1 * Time.deltaTime * speed;
    var y = transform.position.y;
    rigidBody.MovePosition(new Vector2(x, y));
    }

    void MoveUp(){
    
    var x = transform.position.x;
    var y = transform.position.y - 1 * Time.deltaTime * speed;
    rigidBody.MovePosition(new Vector2(x, y));
    }

    void MoveDown(){
    var x = transform.position.x;
    var y = transform.position.y +1 * Time.deltaTime * speed;
    rigidBody.MovePosition(new Vector2(x, y));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        anim.Play("fly");
        if (currentPlatformAndroid==true){
        TouchMove();
        }
        else{
        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        x1= x;
        y1 = y;
        //Set the position of our character throught the RigidBody2D component (since we are using physics)

        rigidBody.MovePosition(new Vector2(x, y));
    }

    }

}
