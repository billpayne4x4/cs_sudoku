// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using cs_sudoku;

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

Matrix matrix = new Matrix();
Attempts attempts = new Attempts();

int row = 0;
int column = 0;

while (row < 9)
{
    while (column < 9)
    {
        var value = attempts[column, row];
        while(attempts.Count(column, row) > 0 && matrix.Check(column, row, value.Item1) == false)
        {
            attempts.Remove(column, row, value.Item2);
            if (attempts.Count(column, row) > 0)
            {
                value = attempts[column, row];
            }
        }

        if (attempts.Count(column, row) ==0)
        {
            matrix.Reset(column, row);
            attempts.Reset(column, row);
            if (column == 0)
            {
                column = 8;
                row -= 1;
            }
            else
            {
                column -= 1;
            }
        }
        else
        {
            matrix[column, row] = value.Item1;
            attempts.Remove(column, row, value.Item2);
            column += 1;
        }
    }
    row += 1;
    column = 0;
}

for (row = 0; row < 9; row++)
{
    for (column = 0; column < 9; column++)
    {
        if (column == 3 || column == 6)
        {
            Console.Write(" ");
        }
        Console.Write($"{matrix[column, row]} ");
    }
    if (row == 2 || row == 5)
    {
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.WriteLine($"{stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L))} µs");