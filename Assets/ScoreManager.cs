using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;

	private int score = 0;

	// Use this for initialization
	void Start () {
		score = 0;
		SetScore();
	}

	// Update is called once per frame
	void Update()
	{
	}
		void OnCollisionEnter(Collision collision)
		{
			string yourTag = collision.gameObject.tag;

			if (yourTag == "SmallStarTag")
			{
				score += 10;
			}
			else if (yourTag == "LargeStarTag")
			{
				score += 20;
			}
			else if(yourTag == "LargeCloudTag")
			{
				score += 50;
			}
			else if(yourTag == "SmallCloudTag")
			{
				score += 15;
			}

        SetScore();

		}

		void SetScore()
		{
			ScoreText.text = string.Format("Score : {0}", score);
		}

}
