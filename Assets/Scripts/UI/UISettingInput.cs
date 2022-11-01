using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public abstract class UISettingInput<T> : MonoBehaviour
    where T : struct
{
    [SerializeField] protected Text _label;
    [SerializeField] protected InputField _inputField;


    protected T _settingValue;
    protected UnityEvent<T> _eventInvokeOnChange;


    public Text Lable { get => _label; }
    public InputField InputField { get => _inputField; }
    public T SettingValue { get => _settingValue; }


    protected virtual void Awake()
    {
        if (_label == null)
            throw new ArgumentNullException(nameof(_label));
        if (_inputField == null)
            throw new ArgumentNullException(nameof(_inputField));

        _inputField.onEndEdit.AddListener(ChangeInputValue);
    }

    protected virtual void OnDestroy()
    {
        _inputField.onEndEdit.RemoveListener(ChangeInputValue);
    }


    public void SetEventInvokeOnChange(UnityEvent<T> _event)
    {
        _eventInvokeOnChange = _event;
    }

    public abstract void ChangeInputValue(string value);
}
