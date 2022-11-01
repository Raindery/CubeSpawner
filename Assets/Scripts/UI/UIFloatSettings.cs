using UnityEngine;

public class UIFloatSettings : UISettingInput<float>
{
    [SerializeField] private float _defaultValue = 0;
    [SerializeField] private float _minValue = 0.1f;
    [SerializeField] private float _maxValue = 10.0f;


    public float DefaultValue { get => _defaultValue; }


    protected override void Awake()
    {
        base.Awake();
        ChangeInputValue(_defaultValue.ToString());
    }

    public override void ChangeInputValue(string value)
    {
        value = value.Replace(".", ",");
        if (!float.TryParse(value, out _settingValue))
            return;
        
        if (_settingValue < _minValue)
            _settingValue = _minValue;

        if (_settingValue > _maxValue)
            _settingValue = _maxValue;

        _inputField.text = _settingValue.ToString();

        if (_eventInvokeOnChange != null)
            _eventInvokeOnChange.Invoke(_settingValue);
    }
}
