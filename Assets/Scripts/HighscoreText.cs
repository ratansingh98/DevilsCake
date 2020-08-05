using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {

	Text score;

	void OnEnable() {
		score = GetComponent<Text>();
		if (PlayerPrefs.GetInt("HighScore")>10)
			score.text = "Best Time: " +PlayerPrefs.GetInt("HighScore").ToString();
		else
			score.text = "Best Time: 999";
	}
}
