using UnityEngine;
using System.Collections;

public class playerExample : MonoBehaviour {

	ICharState currentState;
	//List<ICharState> charStates = new List<ICharState>();
	int stateIndex = 0;
	
	public UISprite sprite = null;
	public float walkSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			currentState.WalkForward();
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			currentState.WalkBackward();
		
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			currentState.Jump();
		
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			stateIndex++;
			
			//currentState = charStates[stateIndex];
		}
		
		transform.localRotation = Quaternion.identity;
		velocity = rigidbody2D.velocity;
		velocity.y = Mathf.Clamp(velocity.y, -2, 2);
		rigidbody2D.velocity = velocity;
	}
}
