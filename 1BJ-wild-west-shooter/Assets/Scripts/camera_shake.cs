using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour
{
    public IEnumerable shake(float duration, float magnitue)
    {
        Vector3 orignalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitue;
            float y = Random.Range(-1, 1) * magnitue;

            transform.localPosition = new Vector3(x, y, orignalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orignalPos;
    }

}
