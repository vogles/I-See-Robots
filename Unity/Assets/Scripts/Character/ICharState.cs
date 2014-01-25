using UnityEngine;
using System.Collections;

public interface ICharState
{
    void Init(Transform _trans, UISprite _sprite, float _movementSpeed);
    void Jump();
    void EndJump();
    void WalkForward();
    void WalkBackward();
}