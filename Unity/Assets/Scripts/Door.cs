using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public TweenPosition positionTween = null;
    public Switch activatedSwitch = null;

    void Start()
    {
        if (activatedSwitch != null)
            activatedSwitch.OnSwitchActivate += OnDoorActivate;
    }

    void OnDoorActivate()
    {
        if (positionTween != null)
            positionTween.PlayForward();
    }
}