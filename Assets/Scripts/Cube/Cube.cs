using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Transform _cachedCubeTransform;
    public Transform CachedTransform
    {
        get
        {
            if (_cachedCubeTransform == null)
                _cachedCubeTransform = transform;
            return _cachedCubeTransform;
        }
    }

    public Coroutine MoveCube(float moveSpeedValue, float maxMoveDistance)
    {
        return StartCoroutine(MoveCubeCoroutine(moveSpeedValue, maxMoveDistance));
    }
    private IEnumerator MoveCubeCoroutine(float moveSpeedValue, float maxMoveDistance)
    {
        Vector3 newPosition;
        while (CachedTransform.position.z != maxMoveDistance)
        {
            newPosition = Vector3.forward * Mathf.Clamp(CachedTransform.position.z + moveSpeedValue * Time.deltaTime, 0, maxMoveDistance);
            CachedTransform.position = newPosition;

            yield return null;
        }

        Destroy(gameObject);
    }
}
