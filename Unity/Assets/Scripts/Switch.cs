using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    public UIToggle toggle = null;
    public UISprite defaultSprite = null;

    public delegate void onSwitchActivate();
    public onSwitchActivate OnSwitchActivate;

    public void Toggle()
    {
        if (toggle != null && !toggle.value)
        {
            toggle.value = true;
            defaultSprite.gameObject.SetActive(false);

            if (OnSwitchActivate != null)
                OnSwitchActivate();
        }
    }
}