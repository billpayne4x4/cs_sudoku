namespace cs_sudoku;

public class Attempts
{
    private List<byte>[,] data = new List<byte>[9, 9];

    public Attempts()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                data[x, y] = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }         
        }
    }

    public (byte, int) this[int column, int row]
    {
        get
        {
            if (data[column, row].Count == 0)
            {
                return (0, 0);
            }
            
            Random rnd = new Random();
            int index = rnd.Next(0, data[column, row].Count-1);
            
            try
            {
                var val = data[column, row][index];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return (data[column, row][index], index);
        }
    }
    
    public void Remove(int column, int row, int index)
    {
        data[column, row].RemoveAt(index);
    }
    
    public void Reset(int column, int row)
    {
        data[column, row] = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
    
    public int Count(int column, int row)
    {
        return data[column, row].Count;
    }
}