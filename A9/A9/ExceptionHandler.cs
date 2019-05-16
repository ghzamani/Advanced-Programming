using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if (_Input == null)
                        return _Input.ToLower();

                    return _Input; 
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }

            set
            {
                try
                {
                    if (value == null)
                        _Input = value.ToLower();
                    _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            { 
                if (causeExceptionInConstructor)
                {
                    string str = null;
                    int i = str.Length; 
                } 
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public static void ThrowIfOdd(int num)
        {
            if (num % 2 != 0)
                throw new InvalidDataException();
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
                checked
                {
                    i++;
                }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
			try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                if (Input == "10")
                {
                    Input = @"..\..\10.txt";
                    StreamWriter writer = new StreamWriter(Input);
                    using (writer)
                    {
                        writer.Write("File Found");
                    }
                }
                var reader = File.ReadAllText(Input);
            }
            catch (FileNotFoundException fileNotFound)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {fileNotFound.GetType()}";
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                int[] array = new int[1];
                array[int.Parse(Input)] = 0;
            }

            catch (IndexOutOfRangeException ior)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ior.GetType()}";
            }
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int[] a = new int[int.Parse(Input)];
            }

            catch(OutOfMemoryException outOfMemory)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {outOfMemory.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                if (int.Parse(Input) != int.MaxValue)
                {
                    int[] myArray = new int[1];
                    checked { myArray[int.Parse(Input)] = int.Parse(Input) + 1; }
                }
                else
                {
                    int[] myArray = new int[int.MaxValue];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public string FinallyBlockStringOut = null;

        public void FinallyBlockMethod(string input)
        {
            try
            {
                FinallyBlockStringOut += "InTryBlock:";
                int i = input.Length; 

                if (input == "beautiful")
                    FinallyBlockStringOut += $"{input}:9:DoneWriting";
            }

            catch(NullReferenceException nre)
            {
                FinallyBlockStringOut += $":{nre.Message}";
                if (!DoNotThrow)
                    throw;
            }

            finally
            {
                FinallyBlockStringOut += ":InFinallyBlock";
            }

            if (input != "ugly")
                FinallyBlockStringOut += ":EndOfMethod";
        }

        public void MethodA()
        {
            MethodB();
        }

        public void MethodB()
        {
            MethodC();
        }

        public void MethodC()
        {
            MethodD();
        }

        public void MethodD()
        {
            throw new NotImplementedException();
        }

        public void NestedMethods()
        {
            try
            {
                throw new NotImplementedException();
            }

            catch(NotImplementedException)
            {
                MethodA();
            }
        }
    }
}
