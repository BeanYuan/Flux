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
                // 生成残影
                Vector3 v = new Vector3(player.transform.position.x, player.transform.position.y - 0.75f, player.transform.position.z);
                GameObject spawnedGhost = Instantiate(ghost, v, player.transform.rotation);

                // 设置残影动作
                Sprite spriteComponent = GetComponent<SpriteRenderer>().sprite;
                spawnedGhost.GetComponent<SpriteRenderer>().sprite = spriteComponent;

                // 设置残影方向
                spawnedGhost.transform.localScale = visual.transform.localScale;

                // 重置持续时间
                ghostDelaySeconds = ghostDelay;

                // 删除残影
                Destroy(spawnedGhost, 1f);
            }
        }
    }
}
