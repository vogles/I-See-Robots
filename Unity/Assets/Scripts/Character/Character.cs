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
    public float dashSpeed = 20f;
    public float dashDuration = 1f;

    CFX_SpawnSystem spawnSystem = null;
    public GameObject shootingPrefab = null;
    public UISpriteAnimation spriteAnim = null;

    public ICharState State
    {
        get { return currentState; }
    }

    void Awake()
    {
        charStates.Add(new LandState());
        charStates.Add(new AquaticState());

        stateIndex = 0;
        currentState = charStates[stateIndex];
        sprite.spriteName = "grobo1";

        spawnSystem = GameObject.FindObjectOfType<CFX_SpawnSystem>();
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

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            SwitchState();

        if (Input.GetKeyDown(KeyCode.Space))
            currentState.UseSkill(shootingPrefab, spriteAnim, dashDuration, dashSpeed);
        
        transform.localRotation = Quaternion.identity;

        Vector2 velocity = rigidbody2D.velocity;
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
        string otherTag = other.gameObject.tag;
        if (otherTag == "Ground")
            currentState.EndJump();
        else if (otherTag == "Collapsible" && currentState is LandState && (currentState as LandState).Dashing)
            Destroy(other.gameObject);
        else if (otherTag == "Switch Trigger" && other.gameObject.name == "Switch 2")
        {
            other.gameObject.GetComponent<Switch>().Toggle();
        }
    }

    void SwitchState()
    {
        stateIndex++;
        if (stateIndex >= charStates.Count)
            stateIndex = 0;

        currentState = charStates[stateIndex];
        if (currentState is LandState)
            spriteAnim.namePrefix = "grobo";
        else
            spriteAnim.namePrefix = "romaid";
    }
}