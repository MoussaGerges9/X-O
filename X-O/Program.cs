using System;

namespace X_O
{
    class Program
    {
        static int _turns;


        static readonly char[,] Cells =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'},
        };


        static void Main()
        {
            
            int player = 2;
            bool loop = true;
            char playerSign = ' ';
            Design();

            int input=0;
            while (loop)
            {
                bool validInput = false;
                
                if (player == 2)
                    player = 1;

                else
                    player = 2;

                if (player == 1)
                    playerSign = 'X';

                else if (player == 2)
                    playerSign = 'O';

                Console.Write("Player {0}, choose the cell: ",player);
                while(!validInput)
                {
                    bool f = false;
                    input = 0;
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Write("You entered a wrong value! Reenter valid choice: ");
                        f = true;
                    }
                    if (input > 0 && input < 10)
                        validInput = true;

                    else if((input < 1 || input > 9) && f==false)
                        Console.Write("You entered a wrong value! Reenter valid choice: ");

                    char x = ' ';
                    switch (input)
                    {
                        case 1: x = Cells[0, 0]; break;
                        case 2: x = Cells[0, 1]; break;
                        case 3: x = Cells[0, 2]; break;
                        case 4: x = Cells[1, 0]; break;
                        case 5: x = Cells[1, 1]; break;
                        case 6: x = Cells[1, 2]; break;
                        case 7: x = Cells[2, 0]; break;
                        case 8: x = Cells[2, 1]; break;
                        case 9: x = Cells[2, 2]; break;
                    }

                    if (x == 'X' || x == 'O')
                    {
                        Console.Write("You can't play here! Please choose another place: ");
                        validInput = false;
                    }
                        
                }
                
                ChangeSymbol(playerSign, input);
                Console.Clear();
                Design();
                if (CheckWin(player) == 1)
                    loop = false;
            } 
        }
        

        static void Design()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", Cells[0, 0], Cells[0, 1], Cells[0, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", Cells[1, 0], Cells[1, 1], Cells[1, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", Cells[2, 0], Cells[2, 1], Cells[2, 2]);
            Console.WriteLine("     |     |     ");
            _turns++;
        }


        static void ChangeSymbol(char sign,int location)
        {
            switch (location)
            {
                case 1: Cells[0, 0] = sign; break;
                case 2: Cells[0, 1] = sign; break;
                case 3: Cells[0, 2] = sign; break;
                case 4: Cells[1, 0] = sign; break;
                case 5: Cells[1, 1] = sign; break;
                case 6: Cells[1, 2] = sign; break;
                case 7: Cells[2, 0] = sign; break;
                case 8: Cells[2, 1] = sign; break;
                case 9: Cells[2, 2] = sign; break;
            }
        }     


        static int CheckWin(int player)
        {
            char[] playerSigns = { 'X', 'O' };
            foreach (char sign in playerSigns)
            {
                if((Cells[0, 0] == sign && Cells[0, 1] == sign && Cells[0, 2] == sign)
                   || (Cells[0, 0] == sign && Cells[1, 0] == sign && Cells[2, 0] == sign)
                   || (Cells[2, 0] == sign && Cells[2, 1] == sign && Cells[2, 2] == sign)
                   || (Cells[1, 0] == sign && Cells[1, 1] == sign && Cells[1, 2] == sign)
                   || (Cells[0, 1] == sign && Cells[1, 1] == sign && Cells[2, 1] == sign)
                   || (Cells[0, 2] == sign && Cells[1, 2] == sign && Cells[2, 2] == sign)
                   || (Cells[0, 0] == sign && Cells[1, 1] == sign && Cells[2, 2] == sign)
                   || (Cells[0, 2] == sign && Cells[1, 1] == sign && Cells[2, 0] == sign))
                {
                    Console.WriteLine("\t\t\a##### ------> Player Number {0} win!! <------ #####", player);
                    return 1;
                }
                else if(_turns==10)
                {
                    Console.WriteLine("\t\t\a######## ------> DRAW <------ ########");
                    return 1;
                }

            }

            return 0;
        }

    }
}
