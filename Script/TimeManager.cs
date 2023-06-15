using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private List<TimeFrame> timeFrames = new List<TimeFrame>();
    public static bool isRewinding;
    [SerializeField] private GameObject player, sprite, visual, ghost;
    public AudioClip rewind, spaceChange;
    public float ghostDelay;
    private float ghostDelaySeconds;

    private void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRewinding = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isRewinding = false;
        }

        if (isRewinding)
        {
            if (!player.GetComponent<AudioSource>().isPlaying) {
                player.GetComponent<AudioSource>().clip = rewind;
                player.GetComponent<AudioSource>().Play();
            }
            Time.timeScale = 1;
            Rewind();
        }
        else if (Time.timeScale != 0)
        {
            if (player.GetComponent<AudioSource>().isPlaying && player.GetComponent<AudioSource>().clip != spaceChange) { 
                player.GetComponent<AudioSource>().Stop();
            }
            Record();
        }
    }

    public void RewindButton() {
        isRewinding = true;
    }

    void Record()
    {
        if (timeFrames.Count > 20000)  // �����б��С�����籣�����5���״̬
        {
            timeFrames.RemoveAt(timeFrames.Count - 1);
        }

        timeFrames.Insert(0, new TimeFrame
        {
            playerPosition = player.transform.position,
            visualScale = visual.transform.localScale,
            spriteAnimation = sprite.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0),
            spriteScale = sprite.transform.localScale
            // ��¼����״̬...
        }) ;
    }

    void Rewind()
    {
        if (timeFrames.Count > 0)
        {
            TimeFrame frame = timeFrames[0];
            player.transform.position = frame.playerPosition;
            visual.transform.localScale = frame.visualScale;
            sprite.GetComponent<Animator>().Play(frame.spriteAnimation.fullPathHash, 0, frame.spriteAnimation.normalizedTime);
            // �ָ�����״̬...
            // ���ɲ�Ӱ
            CreateGhost(frame);

            // ɾ��frame
            timeFrames.RemoveAt(0);
        }
        else
        {
            isRewinding = false;
        }
    }

    void CreateGhost(TimeFrame frame) {
        if (ghostDelaySeconds > 0)
        {
            ghostDelaySeconds -= Time.deltaTime;
        }
        else
        {
            // ���ɲ�Ӱ
            Vector3 v = new Vector3(frame.playerPosition.x, frame.playerPosition.y - 0.75f, frame.playerPosition.z);
            GameObject spawnedGhost = Instantiate(ghost, v, frame.spriteRotation);

            // ���ò�Ӱ����
            spawnedGhost.transform.Find("Visual/Sprite").transform.localScale = frame.spriteScale;

            // ���ò�Ӱ����
            spawnedGhost.transform.Find("Visual").transform.localScale = frame.visualScale;

            // ���ó���ʱ��
            ghostDelaySeconds = ghostDelay;

            // ɾ����Ӱ
            Destroy(spawnedGhost, 1f);
        }
    }
}
