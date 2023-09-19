namespace AdapterPattern
{
    // Concrete Adapter A
    // wariant klasowy
    public class HyteraRadioClassAdapter : HyteraRadio, IRadioAdapter
    {
        public void SendMessage(string content, byte channel)
        {
            this.Init();
            this.SendMessage(channel, content);
            this.Release();
        }
    }
}
