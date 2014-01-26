using UnityEngine;
using System.Collections;

public class LandState : ICharState
{
    Transform trans = null;
    UISprite sprite = null;
    float movementSpeed = 0f;
    float jumpHeight = 0f;

    bool jumping = false;

    public void Init(Transform _trans, UISprite _sprite, float _movementSpeed, float _jumpHeight)
    {
        trans = _trans;
        sprite = _sprite;
        movementSpeed = _movementSpeed;
        jumpHeight = _jumpHeight;
    }

    public void Jump()
    {
        if (jumping)
            return;

        Rigidbody2D rb = trans.rigidbody2D;

        if (!jumping)
        {
            rb.AddForce((Vector2.up * jumpHeight));
            jumping = true;
        }
    }

    public void EndJump()
    {
        jumping = false;
    }

    public void WalkForward()
    {
        Rigidbody2D rb = trans.rigidbody2D;
        Vector2 velocity = rb.velocity;
        velocity.x = Mathf.Clamp(velocity.x + movementSpeed * Time.deltaTime, -1.5f, 1.5f);
        rb.velocity = velocity;

        Transform _trans = sprite.transform;
        if (_trans.localScale.x < 0)
        {
            Vector3 scale = _trans.localScale;
            scale.x *= -1;
            _trans.localScale = scale;
        }
    }

    public void WalkBackward()
    {
        Rigidbody2D rb = trans.rigidbody2D;
        Vector2 velocity = rb.velocity;
        velocity.x = Mathf.Clamp(velocity.x - movementSpeed * Time.deltaTime, -1.5f, 1.5f);
        rb.velocity = velocity;

        Transform _trans = sprite.transform;
        if (_trans.localScale.x > 0)
        {
            Vector3 scale = _trans.localScale;
            scale.x *= -1;
            _trans.localScale = scale;
        }
    }

    public void UseSkillOne(params object[] args)
    {
        throw new System.NotImplementedException();
    }

    public void UseSkillTwo(params object[] args)
    {
        throw new System.NotImplementedException();
    }
}