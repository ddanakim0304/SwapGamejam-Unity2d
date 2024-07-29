using System.Collections;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float deadZone = -30f;

    void Start()
    {
        StartCoroutine(StartMovementAfterDelay(2f));
    }

    IEnumerator StartMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }
}