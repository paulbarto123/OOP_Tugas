using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Tugas
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram mulai = new StartProgram();
            mulai.ShowChoice();
            mulai.Choice();
            BackAfterRestart startAgain = new BackAfterRestart();
            startAgain.ReturnStart();
        }
    }
    public class StartProgram
    {
        private int pilihan;

        public void ShowChoice()
        {
            Console.WriteLine("Input Number From 1-4\n" +
                "1. Body Mass Index\n" +
                "2. Reprint Name\n" +
                "3. Print Even's Character\n" +
                "4. Sum Inputted Array ");
        }
        public void Choice()
        {
            try
            {
                this.pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        AllMethod number1 = new AllMethod();
                        number1.Number1BMI();
                        break;
                    case 2:
                        AllMethod number2 = new AllMethod();
                        number2.Number2ReprintName();
                        break;
                    case 3:
                        AllMethod number3 = new AllMethod();
                        number3.Number3EvenCharacter();
                        break;
                    case 4:
                        AllMethod number4 = new AllMethod();
                        number4.Number4SumArray();
                        break;
                    default:
                        Console.WriteLine("Please Input Number From 1-4");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Input Number Only");
            }
        }
    }
    public class Restart
    {
        private string yes;
        public string GetYes()
        {
            return yes;
        }
        public void SetYes(string yes)
        {
            this.yes = yes;
        }
    }

    public class BackAfterRestart
    {
        public void ReturnStart()
        {
            Restart restart = new Restart();
            restart.SetYes("Yes");
            string yesDefault = restart.GetYes();
            bool i = true;
            while (i)
            {
                Console.WriteLine("Type Yes To Restart The Programm\n ");
                string YesConfirm = Console.ReadLine();
                if (yesDefault.Equals(YesConfirm, StringComparison.CurrentCultureIgnoreCase))
                {
                    StartProgram mulai2 = new StartProgram();
                    mulai2.ShowChoice();
                    mulai2.Choice();
                }
                else
                {
                    i = false;
                }
            }
        }
    }

    public class Input
    {
        private string inputString;
        private float inputFloat;
        private int inputInteger;

        public string ReqInputString()
        {
            this.inputString = Console.ReadLine();
            return inputString;
        }

        public float ReqInputFloat()
        {
            try
            {
                this.inputFloat = float.Parse((Console.ReadLine()));

            }
            catch (FormatException)
            {
                Console.WriteLine("Please Input Number Only");
            }
            return inputFloat;
        }
        public int ReqInputInt()
        {
            try
            {
                this.inputInteger = int.Parse((Console.ReadLine()));
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Input Number Only");
            }
            return inputInteger;
        }
    }

    public abstract class AskingInput : Input
    {
        public abstract void AskWeight();
        public abstract void AskHeight();

    }
    public class BMI : AskingInput
    {
        //public float weight;
        //public float height;
        public override void AskWeight()
        {
            Console.Write("Input Your Weight (kg) \n");
        }

        public override void AskHeight()
        {
            Console.WriteLine("Input Your Height (cm)");
        }
        public float Bmi(float weight, float height)
        {
            if (height == 0)
            {
                throw new Exception("Something Bad happend");
            }
            float weightcalculation = weight / ((height * height) / 10000);
            return weightcalculation;
        }
        public void BMIInfo(float bmi)
        {

            if (bmi < 18.1)
            {
                Console.WriteLine("Your BMI's {0} You're Underweight", bmi);
            }
            else if (bmi >= 18.1 && bmi < 23.1)
            {
                Console.WriteLine("Your BMI's {0} You're Normal", bmi);
            }
            else if (bmi >= 23.1 && bmi <= 28.1)
            {
                Console.WriteLine("Your BMI's {0} You're Overweight", bmi);
            }
            else
            {
                Console.WriteLine("Your BMI's {0} You're Obese", bmi);
            }
        }
        public void BMIInfo(int bmi)
        {
            if (bmi < 18.1)
            {
                Console.WriteLine("Your BMI's {0} You're Underweight", bmi);
            }
            else if (bmi >= 18.1 && bmi < 23.1)
            {
                Console.WriteLine("Your BMI's {0} You're Normal", bmi);
            }
            else if (bmi >= 23.1 && bmi <= 28.1)
            {
                Console.WriteLine("Your BMI's {0} You're Overweight", bmi);
            }
            else
            {
                Console.WriteLine("Your BMI's {0} You're Obese", bmi);
            }
        }
        public void BMIInfo()
        {
            Console.WriteLine("You should count BMI for your health");
        }
    }
    public class EvenCharacter : Input
    {
        public void AskName()
        {
            Console.WriteLine("Please Input Your Name");

        }
        public virtual void PrintEvenCharacter(string inputString)
        {


            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsDigit(inputString[i]))
                {
                    throw new Exception("Don't Input Number ");
                }
                if (i % 2 != 0)
                {
                    Console.WriteLine(inputString[i]);
                }
            }
        }
    }

    public class ReprintName : EvenCharacter
    {
        public override void PrintEvenCharacter(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsDigit(inputString[i]))
                {
                    throw new Exception("Don't Input Number ");
                }
                Console.WriteLine("Huruf Ke {0} adalah {1}", i + 1, inputString[i]);
            }
        }
    }

    public class SumInputtedArray : Input
    {
        protected int[] number;
        protected int sum;
        public SumInputtedArray(int[] number, int sum)
        {
            this.number = number;
            this.sum = sum;

        }
        public void AskNumber()
        {
            Console.WriteLine("Please Input Array Size");
        }

        public void SumArray(int inputInteger)
        {

            for (int i = 0; i < inputInteger; i++)
            {

                number[i] = Convert.ToInt32(Console.ReadLine());
                sum += number[i];
            }
            Console.WriteLine(sum);
        }
    }
    public interface IAllMethod
    {
        void Number1BMI();

        void Number2ReprintName();
        void Number3EvenCharacter();
        void Number4SumArray();

    }
    public class AllMethod : IAllMethod
    {
        public void Number1BMI()
        {
            try
            {
                BMI bmi = new BMI();
                bmi.AskWeight();
                float w = bmi.ReqInputFloat();
                bmi.AskHeight();
                float h = bmi.ReqInputFloat();
                float bmiSum = bmi.Bmi(w, h);
                bmi.BMIInfo(bmiSum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Number2ReprintName()
        {
            try
            {
                ReprintName reprint = new ReprintName();
                reprint.AskName();
                string b = reprint.ReqInputString();
                reprint.PrintEvenCharacter(b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Number3EvenCharacter()
        {
            try
            {
                EvenCharacter even = new EvenCharacter();
                even.AskName();
                string a = even.ReqInputString();
                even.PrintEvenCharacter(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Number4SumArray()
        {
            try
            {
                int[] number = new int[10000];
                SumInputtedArray sum = new SumInputtedArray(number, 0);
                sum.AskNumber();
                int arraySize = sum.ReqInputInt();
                sum.SumArray(arraySize);
            }
            catch
            {
                Console.WriteLine("Index Size Not Valid");
            }
        }
    }
}
