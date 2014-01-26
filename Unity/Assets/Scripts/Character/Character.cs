using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    ICharState currentState;
    List<ICharState> charStates = new List<ICharState>();
    int stateIndex = 0;

    public UISprite sprite = null;
    public float moveSpeed = 10f;
    public float jumpHeight = 5;

    public Vector2 velocity = Vector2.zero;
    void Awake()
    {
        charStates.Add(new LandState());
        charStates.Add(new AquaticState());

        stateIndex = 0;
        currentState = charStates[stateIndex];

        OnValidate();
    }

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
            if (stateIndex >= charStates.Count)
                stateIndex = 0;

            currentState = charStates[stateIndex];
        }

        transform.localRotation = Quaternion.identity;
        velocity = rigidbody2D.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -2, 2);
        rigidbody2D.velocity = velocity;
    }

    void OnValidate()
    {
        foreach (ICharState state in charStates)
            state.Init(transform, sprite, moveSpeed, jumpHeight);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        currentState.EndJump();
    }
}