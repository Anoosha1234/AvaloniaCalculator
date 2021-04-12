using System;
using System.Reactive;
using SDTCalc.Models;
using ReactiveUI;

namespace SDTCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {   
        /// <summary>
        //creating variables for user input
        /// </summary>
        private double UserInput1;
        private double UserInput2;

        /// <summary>
        // Instantiating new MathOp instance
        /// </summary>
        private MathOp MathematicalOp = MathOp.Add;


        /// <summary>
        //https://avaloniaui.net/docs/binding/change-notifications
        /// </summary>
        public double ValueOnScreen
        {
            get => UserInput2;
            set => this.RaiseAndSetIfChanged(ref UserInput2, value);
        }

        /// <summary>
        //Using Reactive Command feature of Avalonia
        /// </summary>
        public ReactiveCommand<int, Unit> AddNumberCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; }
        public ReactiveCommand<MathOp, Unit> ExecuteMathOpCommand { get; }


        /// <summary>
        //Calling all functions
        /// </summary>
        public MainWindowViewModel()
        {
            AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);
            ExecuteMathOpCommand = ReactiveCommand.Create<MathOp>(ExecuteMathOp);
            RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
                    ex => Console.Write("Error"));
          
        }


        /// <summary>
        //Add number to the screen
        /// </summary>
        private void AddNumber(int value)
        {
            ValueOnScreen = ValueOnScreen * 10 + value;
        }


        /// <summary>
        //Clear screen for new operation
        /// </summary>
        public void ClearScreen()
        {
            ValueOnScreen = 0;
            MathematicalOp = MathOp.Add;
            UserInput1 = 0;
        }


        /// <summary>
        //Method to exit the app
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }


        /// <summary>
        //Removing the last number from the screen
        /// </summary>
        public void RemoveLastNumber()
        {
            ValueOnScreen = (int)ValueOnScreen / 10;
        }


        /// <summary>
        //Main function for the app. Switches between the mathematical operations
        /// </summary>
        private void ExecuteMathOp(MathOp MathOp)
        {
            switch (MathematicalOp)
            {
                case MathOp.Add:
                {
                    UserInput1 += UserInput2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Subtract:
                {
                    UserInput1 -= UserInput2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Multiply:
                {
                    UserInput1 *= UserInput2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Divide:
                {
                    UserInput1 /= UserInput2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Square:
                {
                    UserInput1 *= UserInput1;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Modulus:
                {
                    UserInput1 %= UserInput2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.SquareRoot:
                {
                    UserInput1 = Math.Sqrt(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Average:
                {
                    UserInput1 = (UserInput1 + UserInput2)/2;
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Sin:
                {
                    UserInput1 = Math.Sin(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Cos:
                {
                    UserInput1 = Math.Cos(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Tan:
                {
                    UserInput1 = Math.Tan(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Power:
                {
                    UserInput1 = Math.Pow(UserInput1,UserInput2);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Log10:
                {
                    UserInput1 = Math.Log10(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Logn:
                {
                    UserInput1 = Math.Log(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                case MathOp.Round:
                {
                    UserInput1 = Math.Round(UserInput1);
                    ValueOnScreen = 0;
                    break;
                }
                
            }

            if (MathOp == MathOp.Result)
            {
                ValueOnScreen = UserInput1;
                MathematicalOp = MathOp.Add;
                UserInput1 = 0;
            }
            else
            {
                MathematicalOp = MathOp;
            }

        }
    }
}
