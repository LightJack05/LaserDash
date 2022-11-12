using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public IEnumerator ShakeObject(float duration, float magnitude)
    {
        GameObject target = this.gameObject;
        Vector3 orignalPosition = target.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude + orignalPosition.x;
            float y = Random.Range(-1f, 1f) * magnitude + orignalPosition.y;


            target.transform.position = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            if (Time.timeScale == 0)
            {
                break;
            }
            yield return 0;


        }
        target.transform.position = orignalPosition;
    }
}
