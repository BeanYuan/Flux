using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject layer1, layer2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // 如果玩家按下了空格键
        {
            if (layer1.activeInHierarchy)
            {
                layer2.SetActive(true);
                layer1.SetActive(false);
            }
            else {
                layer1.SetActive(true);
                layer2.SetActive(false);
            }
        }
    }
}
