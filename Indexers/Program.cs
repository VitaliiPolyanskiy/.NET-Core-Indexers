using System;

class Myarray
{
    private readonly int[] ar;

    public Myarray()
    {
        ar = new int[10];
    }

    public Myarray(params int[] b)
    {
        ar = new int[b.Length];
        for (int i = 0; i < b.Length; i++)
            ar[i] = b[i];
    }

    public Myarray(int size)
    {
        ar = new int[size];
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < ar.Length)
            {
                return ar[index];
            }
            else
            {
                throw new Exception("\nНекорректный индекс! " + index);
            }
        }
        set
        {
            if (index >= 0 && index < ar.Length)
            {
                ar[index] = value;
            }
            else
            {
                throw new Exception("\nНекорректный индекс! " + index);
            }
        }
    }

    public int this[string index]
    {
        get
        {
            if (!int.TryParse(index, out int i))
                throw new Exception("\nНекорректный индекс! " + index);
            if (i >= 0 && i < ar.Length)
            {
                return ar[i];
            }
            else
            {
                throw new Exception("\nНекорректный индекс! " + index);
            }
        }
        set
        {
            if (!int.TryParse(index, out int i))
                throw new Exception("\nНекорректный индекс! " + index);
            if (i >= 0 && i < ar.Length)
            {
                ar[i] = value;
            }
            else
            {
                throw new Exception("\nНекорректный индекс! " + index);
            }
        }
    }
}

public class MultArray
{
    private readonly int[,] array;
    public int Rows
    {
        get;
    }
    public int Cols
    {
        get;
    }
    public MultArray(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        array = new int[rows, cols];
    }
    public int this[int r, int c]
    {
        get
        {
            if (r < 0 || r >= array.GetLength(0))
            {
                throw new Exception("\nНекорректный индекс! " + r);
            }
            else if (c < 0 || c >= array.GetLength(1))
            {
                throw new Exception("\nНекорректный индекс! " + c);
            }
            else
                return array[r, c];
        }
        set
        {
            if (r < 0 || r >= array.GetLength(0))
            {
                throw new Exception("\nНекорректный индекс! " + r);
            }
            else if (c < 0 || c >= array.GetLength(1))
            {
                throw new Exception("\nНекорректный индекс! " + c);
            }
            else
                array[r, c] = value;
        }
    }
}

class UseArray
{
    public static void Main()
    {
        Myarray ar = new(5);
        Random rnd = new();
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ar[i] = rnd.Next(1, 30);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Console.Write(ar[i] + "\t");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Myarray ar2 = new(10, 20, 30, 40);
        Console.WriteLine("_________________________\n\n");
        string[] indices = ["0", "1", "2", "3", "4", "abc"];
        for (int i = 0; i < 6; i++)
        {
            try
            {
                Console.WriteLine(ar2[indices[i]]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        MultArray multArray = new(2, 3);
        for (int i = 0; i < multArray.Rows; i++)
        {
            for (int j = 0; j < multArray.Cols; j++)
            {
                try
                {
                    multArray[i, j] = i + j;
                    Console.WriteLine(multArray[i, j] + " ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine();
        }

    }
}