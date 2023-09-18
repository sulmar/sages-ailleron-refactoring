// Zasada segregacji interfejsów (Interface Segregation Principle) – ISP

// Kod nie powinien być zmuszany do implementowania nieużywanych metod.

// IEquatable
// ICloneable
// IDisposable


IAudioPlayer player = new AudioVideoPlayer(new Mp3AudioPlayer());

player.PlayAudio();

// Przykład łamiący zasadę segregacji interfejsów

IATM atm = new SecondATM(1000);

if (atm is IWithdraw withdraw)
{
    atm.Withdraw(100);
}

atm.Deposit(50);

var balance = atm.CheckBalance();

Console.WriteLine(balance);



public interface IATM : IWithdraw, IDeposit, IBalance
{

}

public interface IWithdraw
{
    bool Withdraw(decimal amount); // Wypłata    
}

public interface IBalance
{
    decimal CheckBalance();
}

public interface IDeposit
{
    void Deposit(decimal amount); // Wpłata
}



public class WplatomatATM : IDeposit, IBalance
{
    private decimal _balance;

    public WplatomatATM(decimal balance)
    {
        _balance = balance;
    }

    public decimal CheckBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

}

public class SecondATM : IATM
{
    private decimal balance;

    public SecondATM(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)     // <-- problem
    {
        throw new NotSupportedException();
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }
}

public class FirstATM : IATM
{
    private decimal balance;

    public FirstATM(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposit successful. New Balance: " + balance);
        }
        else
        {
            Console.WriteLine("Invalid amount for deposit.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }
}

// Przykład 2
public interface IMediaPlayer : IAudioPlayer, IVideoPlayer
{
    // void StreamContent();
}

public interface IAudioPlayer
{
    void PlayAudio();
}

public interface IVideoPlayer
{
    void PlayVideo();
}


// TODO: 1. Zaimplementuj Odtwarzacz tylko z funkcją PlayAudio
public class StandardPlayer : IAudioPlayer
{
    public void PlayAudio()
    {
        Console.WriteLine("Playing audio...");
    }    
}

public class Mp3AudioPlayer : IAudioPlayer
{
    public void PlayAudio()
    {
        Console.WriteLine("Playing audio mp3 format...");
    }
}

public class ExtendedPlayer : StandardPlayer, IAudioPlayer, IVideoPlayer
{
    public void PlayVideo()
    {
        Console.WriteLine("Playing video...");
    }
}

public class AudioVideoPlayer : IAudioPlayer, IVideoPlayer
{
    private IAudioPlayer audioPlayer;

    public AudioVideoPlayer(IAudioPlayer audioPlayer)
    {
        this.audioPlayer = audioPlayer;
    }

    public void PlayAudio()
    {
        audioPlayer.PlayAudio();
    }

    public void PlayVideo()
    {
        Console.WriteLine("Playing video...");
    }
}


// TODO: 2. Zaimplementuj Odtwarzacz z funkcją PlayAudio + PlayVideo

