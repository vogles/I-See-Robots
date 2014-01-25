using UnityEngine;
using System.Collections;

public class LandState : ICharState
{
    Transform trans = null;
    UISprite sprite = null;
    float movementSpeed = 0f;

    bool jumping = false;
    bool dblJumping = false;

    public void Init(Transform _trans, UISprite _sprite, float _movementSpeed)
    {
        trans = _trans;
        sprite = _sprite;
        movementSpeed = _movementSpeed;
    }

    public void Jump()
    {
        if (jumping && dblJumping)
            return;

        Rigidbody2D rb = trans.rigidbody2D;

        if (!jumping)
        {
            rb.AddForce((Vector2.up * movementSpeed * 50));
            jumping = true;
            dblJumping = false;
        }
        else
        {
            rb.AddForce((Vector2.up * movementSpeed * 120));
            dblJumping = true;
        }
    }

    public void EndJump()
    {
        jumping = false;
        dblJumping = false;
    }

    public void WalkForward()
    {
        trans.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        Transform _trans = sprite.transform;
        if (_trans.localScale.x > 0)
        {
            Vector3 scale = _trans.localScale;
            scale.x *= -1;
            _trans.localScale = scale;
        }
    }

    public void WalkBackward()
    {
        trans.Translate(Vector3.right * movementSpeed * Time.deltaTime * -1);

        Transform _trans = sprite.transform;
        if (_trans.localScale.x < 0)
        {
            Vector3 scale = _trans.localScale;
            scale.x *= -1;
            _trans.localScale = scale;
        }
    }



}