using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform[] av = new Transform[4];
	public Vector3 target = new Vector3();
	public float targetX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		targetX = Mathf.Lerp (av [0].position.x, av [1].position.x,0.5f);
		transform.position =
			new Vector3 (targetX, transform.position.y, transform.position.z);
		gameObject.GetComponent<Camera> ().fieldOfView 
			= 50 * Mathf.Abs (av[0].transform.position.x - av[1].transform.position.x)/8;
		if (gameObject.GetComponent<Camera> ().fieldOfView < 70)
			gameObject.GetComponent<Camera> ().fieldOfView = 70;
	}
}
