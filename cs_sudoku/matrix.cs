namespace cs_sudoku;

public class Matrix
{
    private byte[,] data = new byte[9, 9];
    
    public Matrix()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                data[x, y] = 0;
            }         
        }
    }
    
    public byte this[int column, int row]
    {
        get => data[column, row];
        set => data[column, row] = value;
    }

    public void Reset(int column, int row)
    {
        data[column, row] = 0;
    }
    
    public bool Check(int column, int row, byte value)
    {
        for (int x = 0; x < 9; x++)
        {
            if (data[x, row] == value)
            {
                return false;
            }
        }
        for (int y = 0; y < 9; y++)
        {
            if (data[column, y] == value)
            {
                return false;
            }
        }
        int x0 = (column / 3) * 3;
        int y0 = (row / 3) * 3;
        for (int y = y0; y < y0 + 3; y++)
        {
            for (int x = x0; x < x0 + 3; x++)
            {
                if (data[x, y] == value)
                {
                    return false;
                }
            }
        }
        return true;
    }
}