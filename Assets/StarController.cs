using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	private float rotSpeed = 1.0f;	//回転速度

	// Use this for initialization
	void Start () {
		this.transform.Rotate(0, Random.Range(0, 360), 0);	//回転を開始する角度を設定
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0, this.rotSpeed, 0);
	}
}
