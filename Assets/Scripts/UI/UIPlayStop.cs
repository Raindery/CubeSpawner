using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIPlayStop : MonoBehaviour
{
    [SerializeField] private bool _isPlay;
    [SerializeField] private Text _buttonText;


    private Button _cachedButton;
    public Button CachedButton
    {
        get
        {
            if (_cachedButton == null)
                _cachedButton = GetComponent<Button>();
            return _cachedButton;
        }
    }


    private void Awake()
    {
        if(_buttonText != null)
        {
            if (_isPlay)
                _buttonText.text = "Stop";
            else
                _buttonText.text = "Play";
        }

        CachedButton.onClick.AddListener(SwitchGameState);
        UIEvents.OnChangeGameState.Invoke(_isPlay);
    }

    private void OnDestroy()
    {
        CachedButton.onClick.RemoveListener(SwitchGameState);
    }

    private void SwitchGameState()
    {
        string buttonTextString = string.Empty;

        if (_isPlay)
        {
            _isPlay = false;
            buttonTextString = "Play";
        }
        else
        {
            _isPlay = true;
            buttonTextString = "Stop";
        }

        if (_buttonText != null)
            _buttonText.text = buttonTextString;

        UIEvents.OnChangeGameState.Invoke(_isPlay);
    }
}
