using UnityEngine;
using System.Collections;

public class Character_Stats : MonoBehaviour {
	public Player_Movement baseScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Character FetchCharacter(string tag)//called by Player_Movement on Start to assign character values
	{
		switch (tag)//tag given on game start
		{
		case "Spartan":
			return new Spartan(); break;
		case "Knight":
			return new Knight(); break;
		case "Viking":
			return new Viking(); break;
		case "Tiki":
			return new Tiki(); break;
		default:
			return new Spartan();
			break;
		}
	}
}
public class Character//all character classes derive from here
{
	public float speed;
	public float jumpSpeed; 
	public float weight;//knockback rate
	public float airSpeed;
	public float dashSpeed;
	public float dashAirSpeed;
	//declarame stats, Guille
	public BasicAttack Attack1;public BasicAttack Attack2;public BasicAttack Attack3;public BasicAttack Attack4;
}
public class Spartan : Character
{
	public Spartan()//assign values
	{	//vars
		speed = 4.0f; jumpSpeed = 6.0f; weight = 1;
		airSpeed = 3.00f; dashSpeed = 6.0f; dashAirSpeed = 5.0f;
		//attacks
		Attack1 = new BasicAttack ();
		Attack1.Delay = 0.2f;Attack1.Duration = 0.2f;
		Attack1.Damage = 0.2f; Attack1.Knockback = 3; Attack1.KnockbackY = 2;
		Attack1.ID = 1;
		Attack2 = new BasicAttack ();
		Attack2.Delay = 0.2f;Attack2.Duration = 0.2f;
		Attack2.Damage = 0.2f; Attack2.Knockback = 3; Attack2.KnockbackY = 2;
		Attack2.ID = 2;
		Attack3 = new BasicAttack ();
		Attack3.Delay = 0.2f;Attack3.Duration = 0.2f;
		Attack3.Damage = 0.2f; Attack3.Knockback = 3; Attack3.KnockbackY = 2;
		Attack3.ID = 3;
		Attack4 = new BasicAttack ();
		Attack4.Delay = 0.2f;Attack4.Duration = 0.2f;
		Attack4.Damage = 0.2f; Attack4.Knockback = 3; Attack4.KnockbackY = 2;
		Attack4.ID = 4;
	}
}
public class Knight : Character
{
	public Knight()//assign values
	{	//vars
		speed = 4.0f; jumpSpeed = 6.0f; weight = 1;
		airSpeed = 3.00f; dashSpeed = 6.0f; dashAirSpeed = 5.0f;
		//attacks
		Attack1 = new BasicAttack ();
		Attack1.Delay = 0.2f;Attack1.Duration = 0.2f;
		Attack1.Damage = 0.2f; Attack1.Knockback = 3; Attack1.KnockbackY = 2;
		Attack1.ID = 1;
		Attack2 = new BasicAttack ();
		Attack2.Delay = 0.2f;Attack2.Duration = 0.2f;
		Attack2.Damage = 0.2f; Attack2.Knockback = 3; Attack2.KnockbackY = 2;
		Attack2.ID = 2;
		Attack3 = new BasicAttack ();
		Attack3.Delay = 0.2f;Attack3.Duration = 0.2f;
		Attack3.Damage = 0.2f; Attack3.Knockback = 3; Attack3.KnockbackY = 2;
		Attack3.ID = 3;
		Attack4 = new BasicAttack ();
		Attack4.Delay = 0.2f;Attack4.Duration = 0.2f;
		Attack4.Damage = 0.2f; Attack4.Knockback = 3; Attack4.KnockbackY = 2;
		Attack4.ID = 4;
	}
}public class Viking : Character
{
	public Viking()//assign values
	{	//vars
		speed = 4.0f; jumpSpeed = 6.0f; weight = 1;
		airSpeed = 1.75f; dashSpeed = 7.0f; dashAirSpeed = 3.0f;
		//attacks
		Attack1 = new BasicAttack ();
		Attack1.Delay = 0.2f;Attack1.Duration = 0.2f;
		Attack1.Damage = 0.2f; Attack1.Knockback = 3; Attack1.KnockbackY = 2;
		Attack1.ID = 1;
		Attack2 = new BasicAttack ();
		Attack2.Delay = 0.2f;Attack2.Duration = 0.2f;
		Attack2.Damage = 0.2f; Attack2.Knockback = 3; Attack2.KnockbackY = 2;
		Attack2.ID = 2;
		Attack3 = new BasicAttack ();
		Attack3.Delay = 0.2f;Attack3.Duration = 0.2f;
		Attack3.Damage = 0.2f; Attack3.Knockback = 3; Attack3.KnockbackY = 2;
		Attack3.ID = 3;
		Attack4 = new BasicAttack ();
		Attack4.Delay = 0.2f;Attack4.Duration = 0.2f;
		Attack4.Damage = 0.2f; Attack4.Knockback = 3; Attack4.KnockbackY = 2;
		Attack4.ID = 4;
	}
}
public class Tiki : Character
{
	public Tiki()//assign values
	{	//vars
		speed = 4.0f; jumpSpeed = 6.0f; weight = 1;
		airSpeed = 1.75f; dashSpeed = 7.0f; dashAirSpeed = 3.0f;
		//attacks
		Attack1 = new BasicAttack ();
		Attack1.Delay = 0.2f;Attack1.Duration = 0.2f;
		Attack1.Damage = 0.2f; Attack1.Knockback = 3; Attack1.KnockbackY = 2;
		Attack1.ID = 1;
		Attack2 = new BasicAttack ();
		Attack2.Delay = 0.2f;Attack2.Duration = 0.2f;
		Attack2.Damage = 0.2f; Attack2.Knockback = 3; Attack2.KnockbackY = 2;
		Attack2.ID = 2;
		Attack3 = new BasicAttack ();
		Attack3.Delay = 0.2f;Attack3.Duration = 0.2f;
		Attack3.Damage = 0.2f; Attack3.Knockback = 3; Attack3.KnockbackY = 2;
		Attack3.ID = 3;
		Attack4 = new BasicAttack ();
		Attack4.Delay = 0.2f;Attack4.Duration = 0.2f;
		Attack4.Damage = 0.2f; Attack4.Knockback = 3; Attack4.KnockbackY = 2;
		Attack4.ID = 4;
	}
}
