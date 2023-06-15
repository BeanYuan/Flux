using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private List<TimeFrame> timeFrames = new List<TimeFrame>();
    private bool isRewinding;

    public virtual void Update()
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
            NormalRewind();
        }
        else
        {
            NormalRecord();
        }
    }

    void NormalRecord()
    {
        if (timeFrames.Count > 20000)  // �����б��С�����籣�����5���״̬
        {
            timeFrames.RemoveAt(timeFrames.Count - 1);
        }

        timeFrames.Insert(0, new TimeFrame
        {
            playerPosition = transform.position
            // ��¼����״̬...
        });
    }

    void NormalRewind()
    {
        if (timeFrames.Count > 0)
        {
            TimeFrame frame = timeFrames[0];
            transform.position = frame.playerPosition;

            // ɾ��frame
            timeFrames.RemoveAt(0);
        }
        else
        {
            isRewinding = false;
        }
    }
}
