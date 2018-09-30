using UnityEngine;
using System.Collections;

public class Attack_Check : MonoBehaviour {
	public GameObject controller;
	public Player_Movement father;
	public Player_Movement otherScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider other)
	{
		if (father.currentAttack != null)
			if (father.currentAttack.Delay < 1 && other.tag == "Player")Debug.Log ("Player hit");
		{	
			otherScript = other.gameObject.GetComponent<Player_Movement>();
			if(otherScript.PlayerID!=father.PlayerID)
			{otherScript.ReceiveHit((other.transform.position-father.transform.position)*father.currentAttack.Knockback,father.currentAttack.KnockbackY, father.currentAttack.Damage);
				Debug.Log ("other Player hit");
			}
		}
	}
}
