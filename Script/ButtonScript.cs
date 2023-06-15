using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Sprite disableMusicButton, enableMusicButton;

    public void ToggleBackgroundMusic() {
        if (backgroundMusic.isPlaying)
        {
            musicButton.GetComponent<Image>().sprite = disableMusicButton;
            backgroundMusic.Stop();
        }
        else {
            musicButton.GetComponent<Image>().sprite = enableMusicButton;
            backgroundMusic.Play();
        }
    }
}
