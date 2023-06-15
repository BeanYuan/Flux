using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost, player, visual;

    private void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    private void Update()
    {
        if (TimeManager.isRewinding) { 
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else {
                // ���ɲ�Ӱ
                Vector3 v = new Vector3(player.transform.position.x, player.transform.position.y - 0.75f, player.transform.position.z);
                GameObject spawnedGhost = Instantiate(ghost, v, player.transform.rotation);

                // ���ò�Ӱ����
                Sprite spriteComponent = GetComponent<SpriteRenderer>().sprite;
                spawnedGhost.GetComponent<SpriteRenderer>().sprite = spriteComponent;

                // ���ò�Ӱ����
                spawnedGhost.transform.localScale = visual.transform.localScale;

                // ���ó���ʱ��
                ghostDelaySeconds = ghostDelay;

                // ɾ����Ӱ
                Destroy(spawnedGhost, 1f);
            }
        }
    }
}
