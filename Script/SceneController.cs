using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject layer1, layer2, player;
    public AudioClip spaceChange;

    public static SceneController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // 禁用过去图层
        layer2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))  // 如果玩家按下了空格键
        {
            if (layer1.activeInHierarchy)
            {
                FadeOut.instance.Execute();
                player.GetComponent<AudioSource>().clip = spaceChange;
                player.GetComponent<AudioSource>().Play();
                layer2.SetActive(true);
                layer1.SetActive(false);
            }
            else {
                FadeOut.instance.Execute();
                player.GetComponent<AudioSource>().clip = spaceChange;
                player.GetComponent<AudioSource>().Play();
                layer1.SetActive(true);
                layer2.SetActive(false);
            }
        }
    }

    public void SpaceChange() {
        if (layer1.activeInHierarchy)
        {
            FadeOut.instance.Execute();
            player.GetComponent<AudioSource>().clip = spaceChange;
            player.GetComponent<AudioSource>().Play();
            layer2.SetActive(true);
            layer1.SetActive(false);
        }
        else
        {
            FadeOut.instance.Execute();
            player.GetComponent<AudioSource>().clip = spaceChange;
            player.GetComponent<AudioSource>().Play();
            layer1.SetActive(true);
            layer2.SetActive(false);
        }
    }
}
