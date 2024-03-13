namespace Task2
{
    delegate void CarEventHandler(string message);

    class Car
    {
        public event CarEventHandler CarTurnedOff;
        public event CarEventHandler CarStarted;
        public event CarEventHandler SpeedChanged;
        public event CarEventHandler DirectionChanged;

        private int speed;
        private bool isRunning;
        private string direction;

        public Car()
        {
            speed = 0;
            isRunning = false;
            direction = "direct";
        }

        public void Start()
        {
            if(!isRunning)
            {
                Console.WriteLine("The engine is running");
                CarStarted?.Invoke("The car is started");
                isRunning = true;
            }
            else
            {
                Console.WriteLine("The car is already running");
            }
        }

        public void TurnOff()
        {
            if (isRunning)
            {
                Console.WriteLine("The engine is switched off");
                CarTurnedOff?.Invoke("The car is switched off");
                isRunning = false;
                speed = 0;
            }
            else
            {
                Console.WriteLine("The car is already switched off");
            }
        }

        public void ChangeSpeed(int change)
        {
            if (isRunning)
            {
                speed += change;
                SpeedChanged?.Invoke($"The speed is changed: {speed}");
            }
            else
            {
                Console.WriteLine("First, you need to start the car");
            }
        }

        public void TurnLeft()
        {
            if (isRunning)
            {
                direction = "left";
                DirectionChanged?.Invoke("Turn left");
            }
            else
            {
                Console.WriteLine("First, you need to start the car");
            }
        }
        
        public void TurnRight()
        {
            if (isRunning)
            {
                direction = "right";
                DirectionChanged?.Invoke("Turn right");
            }
            else
            {
                Console.WriteLine("First, you need to start the car");
            }
        }
    }

    class Program
    {
        public static void Main_Task2()
        {
            Car car = new Car();

            car.CarTurnedOff += Car_CarTurnedOff;
            car.SpeedChanged += Car_SpeedChanged;
            car.SpeedChanged += Car_SpeedChanged;
            car.DirectionChanged += Car_DirectionChanged;

            bool isRunning = false;

            while (true)
            {
                Console.WriteLine("\n1. Start the car");
                Console.WriteLine("2. Switch off the car");
                Console.WriteLine("3. Change the speed");
                Console.WriteLine("4. Turn left");
                Console.WriteLine("5. Turn right");
                Console.WriteLine("6. Exit\n");

                int choice;
                if(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Incorrect input. Please try again");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if(!isRunning)
                        {
                            car.Start();
                            isRunning = true;
                        }
                        else
                        {
                            Console.WriteLine("The car is already running");
                        }
                        break;

                    case 2:
                        if (isRunning)
                        {
                            car.TurnOff();
                            isRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("The car is already switched off");
                        }
                        break;

                    case 3:
                        if (isRunning)
                        {
                            Console.WriteLine("Enter the speed change: ");
                            int speedChange;
                            if(!int.TryParse(Console.ReadLine(), out speedChange))
                            {
                                Console.WriteLine("Incorrect input. Please try again");
                                break;
                            }
                            car.ChangeSpeed(speedChange);
                        }
                        else
                        {
                            Console.WriteLine("First, you need to start the car");
                        }
                        break;

                    case 4:
                        if (isRunning)
                        {
                            car.TurnLeft();
                        }
                        else
                        {
                            Console.WriteLine("First, you need to start the car");
                        }
                        break;

                    case 5:
                        if (isRunning)
                        {
                            car.TurnRight();
                        }
                        else
                        {
                            Console.WriteLine("First, you need to start the car");
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void Car_CarTurnedOff(string message)
        {
            Console.WriteLine(message);
        }

        private static void Car_CarStarted(string message)
        {
            Console.WriteLine(message);
        }

        private static void Car_SpeedChanged(string message)
        {
            Console.WriteLine(message);
        }

        private static void Car_DirectionChanged(string message)
        {
            Console.WriteLine(message);
        }
    }
}