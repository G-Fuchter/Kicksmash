using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {
	// Notes: Horizontal 1 = right Vertical 1 = up
	public uint PlayerID; //1,2,3,4
	public string characterTag;
	public bool Bot;
	//Variables
	public float speed;
	public float jumpSpeed; 
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	private int jumps;
	private float jumpTime;
	public float jumpLimitTime;
	public float airSpeed;
	public float dashSpeed;
	public float dashAirSpeed;
	public bool sprint = false;
	public bool death = false;
	//attack vars
	public BasicAttack currentAttack = null;
	public BasicAttack Attack1;
	public BasicAttack Attack2;
	public BasicAttack Attack3;
	public BasicAttack Attack4;
	public GameObject modelo;
	public GameObject modeloLoco;
	public GameObject modeloLoco2;
	public ModelControl model;
	public ModelControl model2;
	public Character_Stats stats;
	bool attackVariant = false;
	//knockback
	public float weight;
	public float aegis = 0;//when > 0, cannot get hit
	public Vector3 velocity=Vector3.zero;
	public float knockbackRate; public float knockbackPercentage = 1;
	//Controller
	public string AxisVertical;
	public string AxisHorizontal;
	public string ButtonDash;
	public string ButtonJump;
	public string ButtonAttack1;
	public string ButtonAttack2;
	public string ButtonAttack3;

	//test rotate
	public float lookSpeed = 10;
	private Vector3 prevLoc;

	//Animation variables
	public bool AttackPrim;
	// Use this for initialization
	void Start () 
	{
		int playerxxx = (int)PlayerID - 1;
		Debug.Log ("JUGADOR1: " + CharSelect.Jugadores [0]);
		Debug.Log ("PlayerID: " + playerxxx);
		//attacks
		stats = new Character_Stats ();
		SetStats(characterTag);

		//death
		death = false;

		if (CharSelect.Jugadores [0] == playerxxx){
			Debug.Log("halp");
			AxisVertical = "Vertical";
			AxisHorizontal = "Horizontal";
			ButtonDash = "Dash";
			ButtonJump = "Jump";
			ButtonAttack1 = "Fire1";
			ButtonAttack2 = "Fire2";
			ButtonAttack3 = "Fire3";
			Destroy(modeloLoco2);
		} else if (CharSelect.Jugadores [1] == playerxxx) {
			AxisVertical = "Vertical2";
			AxisHorizontal = "Horizontal2";
			ButtonDash = "Dash2";
			ButtonJump = "Jump2";
			ButtonAttack1 = "Fire1_2";
			ButtonAttack2 = "Fire2_2";
			ButtonAttack3 = "Fire3_2";
			Destroy(modeloLoco2);
		} else if (CharSelect.Jugadores [0] == playerxxx + 2) {
			AxisVertical = "Vertical";
			AxisHorizontal = "Horizontal";
			ButtonDash = "Dash";
			ButtonJump = "Jump";
			ButtonAttack1 = "Fire1";
			ButtonAttack2 = "Fire2";
			ButtonAttack3 = "Fire3";
			Destroy(modeloLoco);
			model = model2;
			Debug.Log("CACA");
		} else if (CharSelect.Jugadores [1] == playerxxx + 2) {
			AxisVertical = "Vertical2";
			AxisHorizontal = "Horizontal2";
			ButtonDash = "Dash2";
			ButtonJump = "Jump2";
			ButtonAttack1 = "Fire1_2";
			ButtonAttack2 = "Fire2_2";
			ButtonAttack3 = "Fire3_2";
			Destroy(model.gameObject);
			Destroy(modeloLoco);
			model = model2;
			Debug.Log("CACA");
		}

	}

	void Update() {
		if (death == false) {
			CharacterController controller = GetComponent<CharacterController> ();
			prevLoc = transform.position;
			// is the controller on the ground?
			if (controller.isGrounded) {
				//Feed moveDirection with input.
				move (0.0f, speed, dashSpeed);
				jumps = 0;//resetea el doble salto y el timer del salto
				jumpTime = 0.0f;
				model.StartAnim("isGrounded");
			} else {model.StopAnim("isGrounded");
				move (moveDirection.y, airSpeed, dashAirSpeed);
				jumpTime += Time.deltaTime;
			}

			if (Input.GetButton (ButtonJump) && jumps < 2) {
				jump ();
			}

			//Applying gravity to the controller
			moveDirection.y -= gravity * Time.deltaTime;
			//Making the character move
			controller.Move ((moveDirection + velocity * knockbackRate) * Time.deltaTime);

			//Knockback
			if (knockbackRate > 0)
				knockbackRate -= Time.deltaTime;
			else
				knockbackRate = 0;

			//rotacion del modelo
			if (moveDirection.x != 0 || moveDirection.z != 0) {
				modelo.transform.rotation = Quaternion.LookRotation (transform.position - prevLoc);
				modelo.transform.localEulerAngles = new Vector3 (0, modelo.transform.localEulerAngles.y, modelo.transform.localEulerAngles.z);
				//modelo.transform.rotation = Quaternion.Lerp (modelo.transform.rotation, Quaternion.LookRotation (transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);
			}
			//Ataque
			Attack ();

			//Aegis
			aegis-=Time.deltaTime;
			if(aegis<0)model.StopAnim("aegis");
			if(transform.position.y < -5.0f){ //muerte
				death = true;
			//jump animations
			}
			if(controller.isGrounded)
			{
				model.StartAnim("isGrounded"); model.StopAnim("isJumping");
				model.StopAnim ("isDoubleJump");
			}
			else
			{
				model.StopAnim("isGrounded");
			}
		}
	}
	
	void jump()
	{CharacterController controller = GetComponent<CharacterController> ();
		if (jumps == 0 || (jumps == 1 && jumpTime > jumpLimitTime)){ //Si no salto o salto 1 vez lo deja saltar
			moveDirection.y = jumpSpeed; //salta
			jumps++; //suma al contador de saltos
			if(!controller.isGrounded)
				model.StartAnim("isDoubleJump");
			else
			model.StartAnim("isJumping");
		}
	}

	void move(float mDirectionY, float speedNormal, float speedDash) //movimiento y sprint
	{
		model.anim.SetBool("isIdle", false);
		moveDirection = new Vector3 (Input.GetAxis (AxisHorizontal), mDirectionY, Input.GetAxis (AxisVertical));
		//moveDirection = transform.TransformDirection (moveDirection);
		
		if(Input.GetButton (ButtonDash)){ // if the character sprints
			sprint = true; 
			moveDirection.x = moveDirection.x * speedDash; // Multiplica por la velocidad sprint 
			moveDirection.z = moveDirection.z * speedDash;
			if(moveDirection.x != 0 || moveDirection.z != 0){
				model.anim.SetBool("isSprinting", true); // Si se esta moviendo ejecutar animacion
			}else {
				model.anim.SetBool("isSprinting", false); //si no ir a idle.
				model.anim.SetBool("isIdle", true);
			}
		}else{
			sprint = false; //si no sprintea
			model.anim.SetBool("isSprinting", false); 
			moveDirection.x = moveDirection.x * speedNormal; //Multiplica por velocidadd normal 
			moveDirection.z = moveDirection.z * speedNormal;
			if(moveDirection.x != 0 || moveDirection.z != 0){ //si se mueve
				model.anim.SetBool("isWalking", true); //animacion de caminar
				Debug.Log("isWalking = true");
				model.anim.SetBool("isIdle", false);
			}else {
				Debug.Log("isWalking = false");
				model.anim.SetBool("isWalking", false); //si no, idle.
				model.anim.SetBool("isIdle", true);
			}
		}


	}

	/// <summary>
	/// Aca esta perdido, forastero. Tierra de Lukas
	/// </summary>


	
	void Attack()
	{	
		if (currentAttack == null&&aegis<0) {
			if (Input.GetButton (ButtonAttack1)) 
			{	

				if(!attackVariant){
					model.StartAnim ("isAttacking1");
					attackVariant=true;
					currentAttack = Attack1.Copy ();
				}
				else
				{model.StartAnim("isAttacking4");
					attackVariant=false;
					currentAttack = Attack4.Copy ();}
			} 
			if (Input.GetButton (ButtonAttack2)) 
			{	
				currentAttack = Attack2.Copy ();
				model.StartAnim ("isAttacking2");
			} 
			if (Input.GetButton (ButtonAttack3)) 
			{	
				currentAttack = Attack3.Copy ();
				model.StartAnim ("isAttacking3");
			}
		}
		else if (currentAttack != null) 
		{
			if (currentAttack.Delay > 0)
				currentAttack.Delay -= Time.deltaTime;
			else if (currentAttack.Duration > 0)
				currentAttack.Duration -= Time.deltaTime;
			else 
			{	
				model.StopAnim ("isAttacking"+currentAttack.ID);
				currentAttack = null;
			}
		}
	}


	public void ReceiveHit(Vector3 knockback,float ky,float damage)
	{	
		knockbackPercentage += damage;
		knockbackRate = weight * knockbackPercentage;
		velocity = knockback; velocity.y = ky;
		aegis = 1; model.StartAnim("aegis");
	}

	public void SetStats(string tag)
	{	
		Character c = stats.FetchCharacter(characterTag);
		Attack1 = c.Attack1;
		Attack2 = c.Attack2;
		Attack3 = c.Attack3;
		Attack4 = c.Attack4;
		speed = c.speed; weight = c.weight;
		jumpSpeed = c.jumpSpeed;
		airSpeed = c.airSpeed; dashAirSpeed = c.dashAirSpeed;
		speed = c.speed;
		
	}

	public void LoadModel(string chartag){

	}
}

public class BasicAttack
{
	public float Delay; public float Duration; public float Damage; public float Knockback;
	public float KnockbackY;
	public uint ID;
	public BasicAttack Copy()
	{return (BasicAttack)this.MemberwiseClone ();}
}
/*public class Attack1 : BasicAttack
{
	public Attack1 Main()
	{
		Delay = 0.2f; Duration = 0.2f; Damage = 0.2f; Knockback = 3;
		KnockbackY = 5;
		ID = 1;
		return this;
	}
}*/
