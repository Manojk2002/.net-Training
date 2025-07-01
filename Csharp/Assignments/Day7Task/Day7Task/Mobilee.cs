using System;

namespace MobilePhoneRingSystem
{
 
    public delegate void RingEventHandler();

    public class MobilePhone
    {
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            Console.ReadLine();
            OnRing?.Invoke(); 
        }
    }
    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
            Console.ReadLine();
        }
    }
    public class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
            Console.ReadLine();
        }
    }
    public class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
            Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            // Subscribing to the OnRing event
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            // Simulate incoming call
            phone.ReceiveCall();

            Console.ReadLine();
        }
    }
}
