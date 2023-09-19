namespace AdapterPattern
{
    // Concrete Adapter B
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly MotorolaRadio radio;

        private readonly string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();
            this.pincode = pincode;
        }
        public void SendMessage(string content, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(content);
            radio.PowerOff();
        }
    }
}
