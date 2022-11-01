using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    public bool _playSpawn;

    private float _spawnDuration;
    private float _speedValue;
    private float _maxDistantion;


    private Transform _cachedTransform;
    public Transform CachedTransform
    {
        get
        {
            if (_cachedTransform == null)
                _cachedTransform = transform;
            return _cachedTransform;
        }
    }


    private void Awake()
    {
        UIEvents.OnChangeSpawnDurationTime.AddListener(ChangeSpawnDurationTime);
        UIEvents.OnChangeSpeedValue.AddListener(ChangeSpeedValue);
        UIEvents.OnChangeMaxDistantionValue.AddListener(ChangeMaxDistantionValue);
        UIEvents.OnChangeGameState.AddListener(SetPlaySpawn);
    }

    private IEnumerator SpawnCubes()
    {
        while (_playSpawn)
        {
            Cube newCube = Instantiate(_cubePrefab, CachedTransform.position, Quaternion.identity);
            newCube.MoveCube(_speedValue, _maxDistantion);
            yield return new WaitForSeconds(_spawnDuration);
            yield return null;
        }

        yield break;
    }

    private void ChangeSpawnDurationTime(float value)
    {
        _spawnDuration = value;
    }

    private void ChangeSpeedValue(float value)
    {
        _speedValue = value;
    }

    private void ChangeMaxDistantionValue(float value)
    {
        _maxDistantion = value;
    }

    private void SetPlaySpawn(bool isPlay)
    {
        _playSpawn = isPlay;

        if (_playSpawn)
            StartCoroutine(SpawnCubes());
    }
}
