using System;

namespace Orarend_osszerako.BusinessLogic
{
    public static class EventAggregator
    {
        public static void BroadCast(string message)
        {
            if (OnMessageTransmitted != null)
                OnMessageTransmitted(message);
        }

        public static Action<string> OnMessageTransmitted;
    }
}
