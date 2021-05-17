using System;
using static System.Console;
using System.Threading;
//Trabalho Jogo do Galo Feito por Miguel Rodrigues
//07/02/2021
//PRI7 IEFP Seixal
//Programador informático
namespace Jogo_do_Galo_Miguel_Rodrigues
{
    class Program
    {
        static void Main()
        {
            intro();
            Console.WriteLine("\t\t\t   Bem vindo.\n");
            Console.WriteLine("Insira o tamanho do jogo do galo:");
            int DIM = int.Parse(Console.ReadLine());      
            int[,] matriz = new int[DIM,DIM];
            ControlaJogo(matriz);
            Despedida();//credits
        }
        public static void ControlaJogo(int[,] mat)
        {

            int valor;/*jogador x=1 ou o=2 */
            int ciclo;/*ciclo para sair do matriziguais*/
            int cicloErro;/*ciclo para voltar a jogar indice*/
            int empate = 0;/*Condição de empate*/
            char jog;/*indicação de jogador*/

            do
            {
                int contador = 0;/*nr jogadas*/
                ciclo = 1;
                do
                {
                    do
                    {
                        cicloErro = 0;

                        if (contador % 2 == 0)
                        {
                            valor = 1;
                            jog = 'X';
                        }
                        else
                        {
                            valor = 2;
                            jog = 'O';
                        }

                        Console.Clear();//isto limpa cores tmb
                        ImprimeGrelha(mat);
                        Console.WriteLine("Jogador {0}.",jog);
                        Console.WriteLine("Escolha a posição que pretende jogar.");
                        int indice = int.Parse(Console.ReadLine());

                        int linha = IndiceLinha(mat, indice);
                        int coluna = IndiceColuna(mat, indice);
                        bool existes = ExistePosição(linha, coluna, mat);
                        if (existes==false)
                        {
                            Console.WriteLine("Essa posição não existe. Tente outra vez.");
                            Thread.Sleep(1000);
                            cicloErro = 1;
                        }
                        else
                        {
                            bool ocupado = EstaVazio(linha, coluna, mat);
                            if (!ocupado)
                            {
                                Console.WriteLine("Essa posição está ocupada. Tente outra vez.");
                                Thread.Sleep(1000);
                                cicloErro = 1;
                            }
                           else
                                AdicionarNaPosição(linha, coluna, valor, mat);
                        }
                        } while (cicloErro ==1);
                        bool vitoria = MatrizIguais(mat);
                        if (vitoria)
                        {
                            Console.WriteLine("Parabéns, jogador {0}. Ganhaste",jog);
                            ciclo = 0;
                            Thread.Sleep(1000);
                            empate = 1;
                            ImprimeGrelha(mat);
                        }
                        contador++;
                } while (contador != mat.GetLength(0) * mat.GetLength(1) && ciclo==1);
                if(empate==0)
                {
                    Console.WriteLine("Empataram.");
                    Thread.Sleep(1000);
                    ImprimeGrelha(mat);
                }
                
                ciclo = 0;
            } while (ciclo==1);
            Console.WriteLine("Obrigado por terem jogado.");
            Console.WriteLine("Desejam começar de novo ou sair?");
            Console.WriteLine("(1)Voltar ao início.\t(2)Sair.");
            int menu = int.Parse(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                Main();
            }
        }
        static void intro()
        {
            Console.Write("\n ");
            for (int i = 0; i < 66; i++)
                Console.Write("*");

            Console.Write("\n *\t\t\t\t*\t"); 
            Console.Write("Realizado por:");
            Console.Write("\t\t  *\n ");
            Console.Write("*\t ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|->Jogo do galo<-|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t*\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Miguel Rodrigues");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t  *\n ");
            Console.Write("*\t\t\t\t*\t\t\t\t  *\n ");
            for (int i = 0; i < 66; i++)
                Console.Write("*");
            Console.Write("\n\n");
        }
        static void Despedida()
        {
            Beep(1320, 500); Beep(990, 250);Beep(1056, 250); Beep(1188, 250);Beep(1320, 125); Beep(1188, 125);Console.Write("Jogo ");
            Beep(1056, 250); Beep(990, 250);Beep(880, 500); Beep(880, 250); Beep(1056, 250);Beep(1320, 500);Console.Write("do ");
            Beep(1188, 250); Beep(1056, 250); Beep(990, 750); Beep(1056, 250); Beep(1188, 500); Beep(1320, 500); Console.Write("galo ");
            Beep(1056, 500); Beep(880, 500); Beep(880, 500); System.Threading.Thread.Sleep(250); Beep(1188, 500); Beep(1408, 250); Beep(1760, 500);Console.Write(" Criado por: ");
            Beep(1584, 250); Beep(1408, 250); Beep(1320, 750); Beep(1056, 250); Beep(1320, 500); Beep(1188, 250);Console.Write("Miguel ");
            Beep(1056, 250); Beep(990, 500); Beep(990, 250); Beep(1056, 250); Beep(1188, 500); Beep(1320, 500);Console.Write("Rodrigues ");
            Beep(1056, 500);Console.WriteLine("IEFP Seixal-Pri7 2021"); Beep(880, 500); Beep(880, 500); System.Threading.Thread.Sleep(500);
        }
        public static void ImprimeGrelha(int[,] mat)
        {
            int indice = 1;
            char jog1 = 'X';
            char jog2 = 'O';
            Console.WriteLine("\n\n");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 0)
                    {
                        Console.Write("{0,2} ", indice);
                    }
                    else
                    if (mat[i, j] == 1)
                    {
                        Console.Write(" {0} ", jog1);
                    }
                    else
                    if (mat[i, j] == 2)
                    {
                        Console.Write(" {0} ", jog2);
                    }
                    else
                    if (mat[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" {0} ", jog1);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    if (mat[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" {0} ", jog2);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(" {0,2} ", mat[i, j]);
                    }
                    indice++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
        //Retorna o número relativo à linha de um determinado indice. 
        //O indice é o contador que aparece na grelha sempre que a posição está vazia
        public static int IndiceLinha(int[,] mat, int indice)
        {
            int x = 0;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    x++;
                    if (x == indice)
                        return i;
                }
            }
            return x;
        }
        //Retorna o número relativo à coluna de um determinado indice.
        //O indice é o contador que aparece na grelha sempre que a posição está vazia
        public static int IndiceColuna(int[,] mat, int indice)
        {
            int x = 0;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    x++;
                    if (x == indice)
                        return j;
                }
            }
            return x;
        }
        //Verifica se o indíce está vazio
        public static bool EstaVazio(int linha, int coluna, int[,] mat)
        {
            return mat[linha, coluna] == 0;
        }
        //Verifica se o indíce existe na matriz
        public static bool ExistePosição(int linha, int coluna, int[,] mat)
        {
            return linha >= 0 && coluna >= 0 && linha < mat.GetLength(0) && coluna < mat.GetLength(1);
        }
        //Adiciona o valor do jogador na matriz
        public static void AdicionarNaPosição(int linha, int coluna, int valor, int[,] mat)
        {
            mat[linha, coluna] = valor;
        }
        //Devolve uma linha da matriz num array unidimensional
        public static int[] LinhaMatriz(int linha, int[,] mat)
        {
            int[] lin = new int[mat.GetLength(0)];
            for (int k = 0; k < mat.GetLength(0); k++)
                lin[k] = mat[linha, k];
            return lin;
        }
        //Devolve uma coluna da matriz num array unidimensional
        public static int[] ColunaMatriz(int coluna, int[,] mat)
        {
            int[] col = new int[mat.GetLength(1)];
            for (int k = 0; k < mat.GetLength(1); k++)
                col[k] = mat[k, coluna];
            return col;
        }
        //Devolve a diagonal esquerda da matriz num array unidimensional
        public static int[] DiagonalEsquerdaMatriz(int[,] mat)
        {
            int[] diagonal = new int[mat.GetLength(0)];

            for (int i = 0, d = 0; i < mat.GetLength(0); i++, d++)
            {
                diagonal[i] = mat[i, d];
            }
            return diagonal;
        }
        //Devolve a diagonal direita da matriz num array unidimensional
        public static int[] DiagonalDireitaMatriz(int[,] mat)
        {
            int[] diagonale = new int[mat.GetLength(0)];

            for (int i = mat.GetLength(0) - 1, d = 0; i >= 0; i--, d++)
                diagonale[i] = mat[i, d];

            return diagonale;
        }
        //Altera uma linha da matriz somando 2 em todas as posições
        public static void GanhaLinhaMatriz(int linha, int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                mat[linha, i]++;
                mat[linha, i]++;
            }
        }
        //Altera uma coluna da matriz somando 2 a todas as posições
        public static void GanhaColunaMatriz(int coluna, int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                mat[i, coluna]++;
                mat[i, coluna]++;
            }
        }
        //Altera diagonal esquerda da matriz somando 2 a todas as posições
        public static void GanhaDiagonalEsquerda(int[,] mat)
        {
            for (int i = 0, j = 0; i < mat.GetLength(0); i++, j++)
            {
                mat[i, j]++;
                mat[i, j]++;
            }
        }
        //Altera diagonal direita da matriz somando 2 a todas as posições
        public static void GanhaDiagonalDireita(int[,] mat)
        {
            for (int i = 0, j = mat.GetLength(0) - 1; i < mat.GetLength(0); i++, j--)
            {
                mat[i, j]++;
                mat[i, j]++;
            }
        }
        //Verifica se um array unidimensional tem todos os seus valores iguais, caso sejam 0 assume que são valores diferentes
        public static bool ValoresIguais(int[] tab)
        {
            int comp = tab[0];
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == 0 || comp != tab[i])
                    return false;
            }
            return true;
        }
        public static bool MatrizIguais(int[,] mat)
        {
            bool sefor;
            int[] unimatriz = new int[mat.GetLength(0)];
            int[] colmatriz = new int[mat.GetLength(0)];
            int[] diagematriz = new int[mat.GetLength(0)];
            int[] diagdmatriz = new int[mat.GetLength(0)];

            for (int i = 0; i < mat.GetLength(0); i++)
            {

                unimatriz = LinhaMatriz(i, mat);
                sefor = ValoresIguais(unimatriz);
                if (sefor == true)
                {
                    GanhaLinhaMatriz(i, mat);
                    return true;
                }
            }
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                colmatriz = ColunaMatriz(i, mat);
                sefor = ValoresIguais(colmatriz);
                if (sefor == true)
                {
                    GanhaColunaMatriz(i, mat);
                    return true;
                }
            }
            diagematriz = DiagonalDireitaMatriz(mat);
            sefor = ValoresIguais(diagematriz);
            if (sefor == true)
            {
                GanhaDiagonalDireita(mat);
                return true;
            }
            diagdmatriz = DiagonalEsquerdaMatriz(mat);
            sefor = ValoresIguais(diagdmatriz);
            if (sefor == true)
            {
                GanhaDiagonalEsquerda(mat);
                return true;
            }
            return false;
        }
    }
}
