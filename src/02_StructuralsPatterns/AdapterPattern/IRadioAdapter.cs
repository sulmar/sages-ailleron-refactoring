namespace AdapterPattern
{
    // Abstract Adapter
    public interface IRadioAdapter
    {
        void SendMessage(string content, byte channel);
    }
}
