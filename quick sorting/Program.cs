using System.Runtime.CompilerServices;
using static System.Console;


int[] a = { 7, -2, 3, 12, 2, 6, 5};

QuickSort(a);

for(int i = 0; i < a.Length - 1; i++)
{
    WriteLine(a[i]);
    WriteLine();
}

void QuickSort(int[] a)
{
    QuickSortIn(a, 0, a.Length - 1);
}
void QuickSortIn(int[] a, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    int i = start;
    int j = end;
    int num = a[start];

    while (i < j)
    {
        while (i < j && a[j] > num)
        {
            j--;
        }

        a[i] = a[j];

        while (i < j && a[i] < num)
        {
            i++;
        }

        a[j] = a[i];
    }

    a[i] = num;
    QuickSortIn(a, start, i - 1);
    QuickSortIn(a, i + 1, end);
}
