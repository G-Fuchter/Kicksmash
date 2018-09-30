using UnityEngine;
using System.Collections;

//agent.destination=player[1].transform.position;

public class AI : MonoBehaviour {
	public GameObject[] player = new GameObject[5];//0 is null!
	Player_Movement baseScript; NavMeshAgent agent;
	public GameObject bubble;
	void Start () 
	{
		baseScript = GetComponent<Player_Movement> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () 
	{	
		if (baseScript.Bot) 
		{	print (isClose(player[1]));
			#region evasion
			//is there a player attacking close?
			for(int i=4;i>0;i--)
			{
				if(baseScript.PlayerID!=i&&isClose(player[i]))
					print("true"+i);
			}
			#endregion
		}
	}

	int playersAlive(GameObject[] p)
	{	int count=0;
		for (int i=4; i>0; i--) 
			if(baseScript.PlayerID!=i && p[i]!=null)
				count++;
		return count;
	}

	bool isAttacking(GameObject p)
	{
		Player_Movement pm = p.GetComponent<Player_Movement>();
		if(pm.currentAttack.Delay>0 || pm.currentAttack.Duration>0)
			return true;
		else 
			return false;
	}

	bool isClose(GameObject p)
	{	//this doesn't work :(
		if(Vector3.Distance(transform.position,p.transform.position)<1)
			return true;
		else 
			return false;
	}
}





