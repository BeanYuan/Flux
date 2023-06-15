using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    public bool isPlaying;
    public static FadeOut instance;

    private void Awake()
    {
        instance = this;
        isPlaying = false;
    }

    public void Execute() {
        canvasGroup.alpha = 1f;
        isPlaying = true;
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = 1f - (elapsedTime / fadeDuration);
            yield return null;
        }

        
        canvasGroup.alpha = 0f;
        isPlaying = false;
    }
}
