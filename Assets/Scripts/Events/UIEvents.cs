using UnityEngine.Events;

public static class UIEvents
{
    private static readonly UnityEvent<float> _onChangeSpawnDurationTime = new UnityEvent<float>();
    private static readonly UnityEvent<float> _onChangeSpeedValue = new UnityEvent<float>();
    private static readonly UnityEvent<float> _onChangeMaxDistantionValue = new UnityEvent<float>();
    private static readonly UnityEvent<bool> _onChangeGameState = new UnityEvent<bool>();


    public static UnityEvent<float> OnChangeSpawnDurationTime { get => _onChangeSpawnDurationTime; }
    public static UnityEvent<float> OnChangeSpeedValue { get => _onChangeSpeedValue; }
    public static UnityEvent<float> OnChangeMaxDistantionValue { get => _onChangeMaxDistantionValue; }
    public static UnityEvent<bool> OnChangeGameState { get => _onChangeGameState; }
}
