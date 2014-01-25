using UnityEngine;
using System.Collections;

public class AquaticState : ICharState
{
    Transform trans = null;
    UISprite sprite = null;
    float movementSpeed = 0f;

    public void Init(Transform _trans, UISprite _sprite, float _movementSpeed)
    {
        trans = _trans;
        sprite = _sprite;
        movementSpeed = _movementSpeed;
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void EndJump()
    {
        throw new System.NotImplementedException();
    }

    public void WalkForward()
    {
        trans.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    public void WalkBackward()
    {
        trans.Translate(Vector3.right * movementSpeed * Time.deltaTime * -1);
    }
}