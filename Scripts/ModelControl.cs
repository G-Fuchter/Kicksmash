using UnityEngine;
using System.Collections;

public class ModelControl : MonoBehaviour {

	public Animator anim;

	//variables
	float AttackTimer;
	bool isAttacking;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();

		AttackTimer = 0.0f;
		isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartAnim(string s)
	{
		anim.SetBool (s, true);
	}

	public void StopAnim(string s)
	{
		anim.SetBool (s, false);
	}
}
