using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour
{
    public AudioClip gameplay = null;
    public AudioClip win = null;
    public AudioSource source = null;
    void Start()
    {
        PlayGameplay();
    }

    public void PlayGameplay()
    {
        source.clip = gameplay;
        source.Play();
    }

    public void PlayWin()
    {
        source.clip = win;
        source.Play();
    }
}