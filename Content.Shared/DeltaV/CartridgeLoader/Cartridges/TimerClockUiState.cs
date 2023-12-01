using Content.Shared.CartridgeLoader;
using Robust.Shared.Serialization;

namespace Content.Shared.DeltaV.CartridgeLoader.Cartridges;

[Serializable, NetSerializable]
public sealed class TimerClockUiState : BoundUserInterfaceState
{
    public enum UiStates
    {
        TimerOverview,
        NewTimer
    }

    public UiStates CurrentState = UiStates.TimerOverview;

    public TimerClockUiState(UiStates uiState = UiStates.TimerOverview)
    {
        CurrentState = uiState;
    }
}

[Serializable, NetSerializable]
public sealed class TimerClockSyncMessageEvent : CartridgeMessageEvent
{
    public TimerClockSyncMessageEvent()
    { }
}
