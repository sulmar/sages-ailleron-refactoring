namespace AdapterPattern
{
    // Concrete Adapter A
    // wariant obiektowy
    public class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void SendMessage(string content, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, content);
            radio.Release();
        }
    }
}
