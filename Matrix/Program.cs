using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Matrix
{
   public class GetRandomNumber
   {
        static Random random = new Random();
        public int Get()
        {
            int number = random.Next(1, 10);
            return number;
        }
   }   
   public class EnterTheMatrixParameters: GetRandomNumber
   {        
        public int  Input()
        {
            Console.WriteLine("Enter the number of rows in matrix: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns in matrix: ");
            int column = Convert.ToInt32(Console.ReadLine());          
            int size = row;
            return size;            
        }        
   }  
   public class Matrix: EnterTheMatrixParameters
   {      
        public int[,] GetMatrix(int size)          
        {
            GetRandomNumber number = new GetRandomNumber();                              
            int[,] matrix = new int[size, size];        
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = number.Get();                    
                }                
            }
            return matrix;
        }
   }
   public class MatrixOutput
   {

        public void Output(int size, int[,] matrix,string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {                    
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
   }
   public class Sum: EnterTheMatrixParameters
   {
        public int[,] SumM(int size, int[,] matrix1,int[,] matrix2)
        {                     
            int[,] matrix3 = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];                    
                }                
            }
            return matrix3;
        }
   }  
   public class Multiplaction: EnterTheMatrixParameters
   {
        public int[,] MultM(int size, int[,] matrix1, int[,] matrix2)
        {
            
            int[,] matrix4 = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix4[i, j] = 0;                  
                    for (int k = 0; k < size; k++)
                    {
                        matrix4[i, j] += matrix1[i, k] * matrix2[k, j];
                    }                   
                }
            }
            return matrix4;
        }
   }
    public class DecisionOutput
    {
        public void Output()
        {
            EnterTheMatrixParameters num = new EnterTheMatrixParameters();
            int size = num.Input();
            Matrix matrix = new Matrix();
            int[,] matrix1 = matrix.GetMatrix(size);
            int[,] matrix2 = matrix.GetMatrix(size);
            Sum s = new Sum();
            int[,] matrix3 = s.SumM(size, matrix1, matrix2);
            Multiplaction m = new Multiplaction();
            int[,] matrix4 = m.MultM(size, matrix1, matrix2); ;
            MatrixOutput data = new MatrixOutput();
            data.Output(size, matrix1, "A=");
            data.Output(size, matrix2, "B=");
            data.Output(size, matrix3, "A+B=");
            data.Output(size, matrix4, "A*B=");
        }
    }
   class Program
   { 
        static void Main(string[] args)
        {
            DecisionOutput output = new DecisionOutput();
            output.Output();
            Console.ReadKey();
        }
   }
}
