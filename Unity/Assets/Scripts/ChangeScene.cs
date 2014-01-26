using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex = 0;

    public void OnButtonClick()
    {
        Application.LoadLevel(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}