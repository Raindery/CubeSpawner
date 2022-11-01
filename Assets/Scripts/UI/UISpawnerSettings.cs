using UnityEngine;
using System;

public class UISpawnerSettings : MonoBehaviour
{
    [SerializeField] private UIFloatSettings _spawnDurationTimeInput;
    [SerializeField] private UIFloatSettings _speedValueInput;
    [SerializeField] private UIFloatSettings _maxDistantionInput;

    private void Awake()
    {
        if (_spawnDurationTimeInput == null)
            throw new ArgumentNullException(nameof(_spawnDurationTimeInput));
        if (_speedValueInput == null)
            throw new ArgumentNullException(nameof(_speedValueInput));
        if (_maxDistantionInput == null)
            throw new ArgumentNullException(nameof(_maxDistantionInput));

        _spawnDurationTimeInput.SetEventInvokeOnChange(UIEvents.OnChangeSpawnDurationTime);
        _speedValueInput.SetEventInvokeOnChange(UIEvents.OnChangeSpeedValue);
        _maxDistantionInput.SetEventInvokeOnChange(UIEvents.OnChangeMaxDistantionValue);
    }

    private void Start()
    {
        _spawnDurationTimeInput.ChangeInputValue(_spawnDurationTimeInput.DefaultValue.ToString());
        _speedValueInput.ChangeInputValue(_speedValueInput.DefaultValue.ToString());
        _maxDistantionInput.ChangeInputValue(_maxDistantionInput.DefaultValue.ToString());
    }
}
