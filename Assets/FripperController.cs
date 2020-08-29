using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

	private HingeJoint myHingeJoint;    //HingeJointコンポーネントを入れる
	private float defaultAngle = 20;    //初期の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start()
	{
		this.myHingeJoint = GetComponent<HingeJoint>();   //HingeJointコンポーネント取得
		SetAngle(this.defaultAngle);    //傾きの設定
	}

	// Update is called once per frame
	void Update()
	{
		//左矢印キーを押した時フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		//矢印キーが離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		for (int i = 0; i < Input.touchCount ; i++)
		{
			Touch touch = Input.GetTouch(i);
			//左フリッパー動作
			if (touch.phase == TouchPhase.Began && (Input.touches[i].position.x < Screen.width / 2.0f) && tag == "LeftFripperTag")
			{
				SetAngle(this.flickAngle);
			}
			//右フリッパー動作
			if (touch.phase == TouchPhase.Began && (Input.touches[i].position.x > Screen.width / 2.0f) && tag == "RightFripperTag")
			{
				SetAngle(this.flickAngle);
			}
			//左フリッパー動作止め
			if (touch.phase == TouchPhase.Ended && (Input.touches[i].position.x < Screen.width / 2.0f) && tag == "LeftFripperTag")
			{
				SetAngle(this.defaultAngle);
			}
			//右フリッパー動作止め
			if (touch.phase == TouchPhase.Ended && (Input.touches[i].position.x > Screen.width / 2.0f) && tag == "RightFripperTag")
			{
				SetAngle(this.defaultAngle);
			}
		}

		

	}
	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}

