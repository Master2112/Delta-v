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

    public List<UserTimer> UserTimers = new List<UserTimer>();

    private uint NextUnusedId
    {
        get
        {
            uint result = 0;
            bool found = false;

            while (!found)
            {
                found = true;

                foreach (UserTimer timer in UserTimers)
                {
                    if(timer.Id == result)
                    {
                        found = false;
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }

    public TimerClockUiState(UiStates uiState = UiStates.TimerOverview)
    {
        CurrentState = uiState;
    }

    public void CreateNewTimer(string label, int hours, int minutes, int seconds)
    {
        UserTimer newTimer = new UserTimer(NextUnusedId, label, DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds));

        UserTimers.Add(newTimer);
    }

    [Serializable, NetSerializable]
    public struct UserTimer
    {
        public readonly uint Id;
        public DateTime EndTime;
        public string Label;

        public UserTimer(uint id, string label, DateTime endTime)
        {
            Id = id;
            EndTime = endTime;
            Label = label;
        }
    }
}

[Serializable, NetSerializable]
public sealed class TimerClockSyncMessageEvent : CartridgeMessageEvent
{
    public TimerClockSyncMessageEvent()
    { }
}
