using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Unit_9._6
{
    internal class Program
    {
        public class MyException : Exception
        {
            public MyException ()
            { }
            public MyException(string message): base(message)
            {

            }
        }
       public class NumReader
        {
            public delegate void NumEnteredDelegate(int num);
            public event NumEnteredDelegate NumEnteredEvent;
            public void KeyRead()
            {
                Console.WriteLine("\n \nPlease press key 1 or 2 \n Key 1 - sort A-Z \n Key 2 - sort Z-A ");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num != 1 && num != 2) throw new MyException("Wrong key has been pressed. Please try again.");
                NumEntered(num);
            }
            protected virtual void NumEntered(int num)
            {
                NumEnteredEvent?.Invoke(num);
            }
        }
        static void Main(string[] args)
        {
            MyException ex1 = new MyException("Wrong key has been pressed. Please try again.");
            

            Exception ex2 =new ArgumentException();
            Exception ex3 = new IndexOutOfRangeException();
            Exception ex4 = new KeyNotFoundException();
            Exception ex5 = new DriveNotFoundException();
            Exception[] exArray = new Exception[5];
            exArray[0] = ex1;
            exArray[1] = ex2;
            exArray[2] = ex3;
            exArray[3] = ex4;
            exArray[4] = ex5;
            Console.WriteLine("--->>> Task 1 <<<---");
            exIteration(exArray, 0);
            Console.WriteLine("--->>> ------ <<<---");
            List<string> sName = new List<string>();
            sName.Add("Ivanov");
            sName.Add("Petrov");
            sName.Add("Boshirov");
            sName.Add("Sidorov");
            sName.Add("Kuznetsov");
            Console.WriteLine(" \n \n--->>> Task 2 <<<---");
            Console.WriteLine("Source lis is:");
            foreach (string st in sName) Console.WriteLine(st);
            NumReader numReader = new NumReader();
            numReader.NumEnteredEvent += SortType;
            try
            {
                numReader.KeyRead();
            }
            catch(MyException myEx)
            {
                Console.WriteLine(myEx.Message);
            }




        }
        static void SortType(int num)
        {
            switch (num)
            {
                case 1: break;
                case 2: break;
            }
        }
        
        static void exIteration(Exception[] exArr, int i)
        {

            try
            {
                throw exArr[i];

            }
            catch
            {

                Console.WriteLine(exArr[i].Message);
                if (i < exArr.Length - 1)
                {
                    i++;
                    exIteration(exArr, i);


                }



            }
            
        }
        
    }
}
