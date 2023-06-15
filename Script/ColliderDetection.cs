using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderDetection : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private bool hasKey;
    [SerializeField] private TextMeshProUGUI tip;
    [SerializeField] private AudioSource doorAudio, keyAudio;

    private void Start()
    {
        tip.alpha = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !TimeManager.isRewinding)
        {
            Vector3 v = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z);
            transform.position = v;
        }
        else if (collision.gameObject.CompareTag("Door") && hasKey)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
            doorAudio.Play();
            Destroy(collision.gameObject, 1f);
            hasKey = false;
        }
        else if (collision.gameObject.CompareTag("DeadZone"))
        {
            Vector3 v = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z);
            transform.position = v;
            /*Time.timeScale = 0;*/
        }
        else if (collision.gameObject.layer == 3) {
            Vector3 v = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z);
            transform.position = v;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KeyBox"))
        {
            hasKey = true;
            keyAudio.Play();
            Destroy(collision.gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("SpawnPoint"))
        {
            tip.text = "Respawn Point Set!";
            tip.color = new Color32(255, 25, 53, 255);
            StartCoroutine(DisplayAndFadeOut(3f, 1f));
            spawnPoint = collision.gameObject.transform.transform;
        }
        else if (collision.gameObject.name.Contains("Space Change Tip")) {
            tip.text = "No place to Jump in this space,<br>but what about another space?";
            tip.color = new Color32(93, 221, 80, 255);
            StartCoroutine(DisplayAndFadeOut(3f, 1f));
        }
        else if (collision.gameObject.name.Contains("Rewind Tip"))
        {
            tip.text = "No way to climb back there,<br>or just Time Travel Back?";
            tip.color = new Color32(93, 221, 80, 255);
            StartCoroutine(DisplayAndFadeOut(3f, 1f));
        }

    }

    private IEnumerator DisplayAndFadeOut(float displayTime, float fadeTime)
    {
        tip.alpha = 1f;  // 开始时，文本应该是完全不透明的

        // 等待指定的显示时间
        yield return new WaitForSeconds(displayTime);

        // 在指定的淡出时间内，逐渐将文本的透明度降低到0
        float startFadeTime = Time.time;
        while (Time.time < startFadeTime + fadeTime)
        {
            float elapsed = Time.time - startFadeTime;
            tip.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeTime);
            yield return null;
        }

        tip.alpha = 0f;  // 确保淡出结束时，文本完全透明
    }
}
