using Robust.Client.GameObjects;
using Robust.Client.UserInterface;
using Content.Client.UserInterface.Fragments;
using Content.Shared.DeltaV.CartridgeLoader.Cartridges;
using Content.Shared.CartridgeLoader;

namespace Content.Client.DeltaV.CartridgeLoader.Cartridges;

public sealed partial class TimerClockUi : UIFragment
{
    private TimerClockUiFragment? _fragment;

    public override Control GetUIFragmentRoot()
    {
        return _fragment!;
    }

    public override void Setup(BoundUserInterface userInterface, EntityUid? fragmentOwner)
    {
        _fragment = new TimerClockUiFragment();

        _fragment.OnSync += _ => SendSyncMessage(userInterface);
    }

    private void SendSyncMessage(BoundUserInterface userInterface)
    {
        var syncMessage = new TimerClockSyncMessageEvent();
        var message = new CartridgeUiMessage(syncMessage);
        userInterface.SendMessage(message);
    }

    public override void UpdateState(BoundUserInterfaceState state)
    {
        if (state is TimerClockUiState timerClockState)
        {
            _fragment?.UpdateState(timerClockState);
            _fragment?.UpdateUI(timerClockState.CurrentState);
        }
    }
}
