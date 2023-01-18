using System.Runtime.CompilerServices;
using static System.Console;

int[,] doska = new int[8, 8];
for (int f = 0; f < 8; f++)
{
    for (int k = 0; k < 8; k++)
    {
        doska[f, k] = 1;
    }
}
for (int f = 0; f < 8; f++)
{
    for (int k = 0; k < 8; k++)
    {
        Write($"{doska[f, k]} ");
    }
    WriteLine();
}
WriteLine();

int[] hod = new int[65];
int schetchik = 0;
int operation = 0;
int i, j,x,y;
i = j = x = y =  0;
while(schetchik!=64)
{
    for (int f = 0; f < 64; f++)
    {
        hod[f] = 0;
    }
    for (int f = 0; f < 8; f++)
    {
        for (int k = 0; k < 8; k++)
        {
            doska[f, k] = 1;
        }
    }
    i = y;
    j = x;
    schetchik = 0;
    doska[y,x] = 0;
    hod_koni();
    WriteLine($"Понадобилось столько ходов: {schetchik}");
    x++;
    if (x > 7)
    {
        y++;
        x = 0;
    }
    if (y > 7)
    {
        x=y=0;
        WriteLine("Не правильные ходы :)");
        break;
    }
}



void hod_koni()
{
    while (schetchik < 64)
    {
        bool operation_bool = true;
        int oshibka = 0;
        operation = hod[schetchik];
        while (operation_bool)
        {
            if (oshibka > 32)
            {
                WriteLine("Critical ER hod_koni");
                break;
            }
            switch (operation)
            {
                case 0: if (prav_hod(i - 2, j + 1)) { i -= 2; j += 1; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 1: if (prav_hod(i - 1, j + 2)) { i -= 1; j += 2; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 2: if (prav_hod(i + 1, j + 2)) { i += 1; j += 2; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 3: if (prav_hod(i + 2, j + 1)) { i += 2; j += 1; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 4: if (prav_hod(i + 2, j - 1)) { i += 2; j -= 1; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 5: if (prav_hod(i + 1, j - 2)) { i += 1; j -= 2; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 6: if (prav_hod(i - 1, j - 2)) { i -= 1; j -= 2; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                case 7: if (prav_hod(i - 2, j - 1)) { i -= 2; j -= 1; hod[schetchik] = operation; schetchik++; operation_bool = false; }
                    else { operation++; };
                    break;

                default: obratniy_hod_kone(); oshibka++; break;
            }
            
        }
        if (oshibka > 3)
        {
            break;
        }
        doska[i, j] = 0;
        for (int f = 0; f < 8; f++)
        {
            for (int k = 0; k < 8; k++)
            {
                Write($"{doska[f, k]} ");
            }
            WriteLine();
        }
        WriteLine($"\n Ход: {schetchik}\n\n");
        hod_koni();
    }
}


void obratniy_hod_kone()
{
    hod[schetchik] = 0;
    schetchik--;
    switch (hod[schetchik])
    {
        case 0: 
            //if (prav_hod(i + 2, j - 1)) 
            { i += 2; j -= 1;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 1: 
           // if (prav_hod(i + 1, j - 2)) 
            { i += 1; j -= 2;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 2: 
           // if (prav_hod(i - 1, j - 2)) 
            { i -= 1; j -= 2;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 3: 
            //if (prav_hod(i - 2, j - 1)) 
            { i -= 2; j -= 1;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 4: 
            //if (prav_hod(i - 2, j + 1)) 
            { i -= 2; j += 1;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 5: 
            //if (prav_hod(i - 1, j + 2)) 
            { i -= 1; j += 2;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 6: 
            //if (prav_hod(i + 1, j + 2)) 
            { i += 1; j += 2;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        case 7: 
            //if (prav_hod(i + 2, j + 1)) 
            { i += 2; j += 1;}
            //else { WriteLine("Critical ER obrat_hod"); schetchik++; };
            break;
        default: WriteLine("Critical ER obrat_hod_finel"); schetchik++; break;
    }
    hod[schetchik]+=1;
    operation = hod[schetchik];
    doska[i, j] = 1;
}

bool prav_hod(int i,int j)
    {
        bool otv = true;
        if (i < 0 || i >= 8)
        {
            otv = false;
            return otv;
        }


        else if (j < 0 || j >= 8)
        {
            otv = false;
            return otv;
        }

        else if (doska[i, j] == 0)
        {
            otv = false;
            return otv;
        }

        return otv;
    }