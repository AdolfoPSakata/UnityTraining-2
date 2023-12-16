using System;

public interface ISubscriber
{
    public void SubscribeToEvent(string subscriber, string target);
    public void UnsubscribeToEvent(string subscriber, string target);
    public void SendAction(string action);

 }
