using System;
using System.Reactive;
using SDTCalc.Models;
using ReactiveUI;

namespace SDTCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double UserInput1;
        private double UserInput2;

        private MathOp MathematicalOp = MathOp.Add;

        //https://avaloniaui.net/docs/binding/change-notifications
        public double ValueOnScreen
        {
            get => UserInput2;
            set => this.RaiseAndSetIfChanged(ref UserInput2, value);
        }


        public ReactiveCommand<int, Unit> AddNumberCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; }
        public ReactiveCommand<MathOp, Unit> ExecuteMathOpCommand { get; }

        public MainWindowViewModel()
        {
            AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);
            ExecuteMathOpCommand = ReactiveCommand.Create<MathOp>(ExecuteMathOp);
            RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
                    ex => Console.Write("Error"));
          
        }

        private void AddNumber(int value)
        {
            ValueOnScreen = ValueOnScreen * 10 + value;
        }

        public void ClearScreen()
        {
            ValueOnScreen = 0;
            MathematicalOp = MathOp.Add;
            UserInput1 = 0;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
        public void RemoveLastNumber()
        {
            ValueOnScreen = (int)ValueOnScreen / 10;
        }
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
