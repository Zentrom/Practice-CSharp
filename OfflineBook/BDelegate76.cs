using System;
using System.Diagnostics.Tracing;

namespace Practice_CSharp.OfflineBook
{
    public class BDelegate76
    {
        //Delegate
        delegate void Computations(double x, double y);
        void Add(double x, double y)
        {
            Console.WriteLine(x + y);
        }
        void Subtract(double x, double y)
        {
            Console.WriteLine(x - y);
        }
        void Multiply(double x, double y)
        {
            Console.WriteLine(x * y);
        }
        void Divide(double x, double y)
        {
            Console.WriteLine(x / y);
        }
        //Event
        delegate void DangerousSpeedHandler(object sender, DangerousSpeedEventArgs eventArgs);
        delegate void SpeedChangedEventHandler(object sender, SpeedChangedEventArgs eventArgs);
        class DangerousSpeedEventArgs : EventArgs
        {
            public int Speed { get; private set; }
            public DangerousSpeedEventArgs(int speed)
            {
                Speed = speed;
            }
        }
        class SpeedChangedEventArgs : EventArgs
        {
            public int PreviousSpeed { get; private set; }
            public int NewSpeed { get; private set; }
            public SpeedChangedEventArgs(int previousSpeed, int newSpeed)
            {
                PreviousSpeed = previousSpeed;
                NewSpeed = newSpeed;
            }
        }
        class Booster
        {
            private int speed = 0;
            public int Speed
            {
                get
                {
                    return speed;
                }
                set
                {
                    OnSpeedChanged(speed, value);
                    speed = value;
                }
            }
            public event SpeedChangedEventHandler SpeedChanged;
            public event DangerousSpeedHandler DangerousSpeed;
            private void OnSpeedChanged(int previousValue, int newValue)
            {
                if(SpeedChanged != null)
                {
                    SpeedChanged(this, new SpeedChangedEventArgs(previousValue, newValue));
                }
            }
            private void OnDangerousSpeed(int speed)
            {
                if(DangerousSpeed != null)
                {
                    DangerousSpeed(this, new DangerousSpeedEventArgs(speed));
                }
            }
            public void Boost()
            {
                for(int velocity = 0; velocity < 200; velocity += 10)
                {
                    Speed = velocity;
                    if(velocity >= 150)
                    {
                        OnDangerousSpeed(velocity);
                    }
                }
                Console.WriteLine("Booster test finished.");
            }
        }
        void Booster_DangerousSpeed(object sender, DangerousSpeedEventArgs eventArgs)
        {
            Console.WriteLine($"The booster exceeded the dangerous speed limit. Speed: {eventArgs.Speed}");
        }

        public void Run()
        {
            //Delegate - Runs all functions in order(does not take result in account)
            Computations compute = Add;
            compute += Subtract;
            compute += Multiply;
            compute += Divide;
            compute(10, 20);

            //Event - Similar to Win messages
            Booster booster = new Booster();
            booster.DangerousSpeed += Booster_DangerousSpeed;
            booster.SpeedChanged += (sender, eventArgs) =>
            {
                int previous = eventArgs.PreviousSpeed;
                int current = eventArgs.NewSpeed;
                Console.WriteLine(String.Format("Speed changed from {0} to {1}", previous, current));
            };
            booster.Boost();
        }
    }
}
