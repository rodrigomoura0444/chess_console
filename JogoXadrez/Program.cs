using System;

class Program
{
    static char[,] tabuleiro = new char[8, 8];

    static void Main()
    {
        InicializarTabuleiro();
        MostrarTabuleiro();

        while (true)
        {
            Console.WriteLine("Digite o movimento (ex: E2 E4) ou 'sair' para terminar.");
            string movimento = Console.ReadLine();

            if (movimento.ToLower() == "sair")
            {
                break;
            }

            if (ValidarMovimento(movimento))
            {
                FazerMovimento(movimento);
                MostrarTabuleiro();
            }
            else
            {
                Console.WriteLine("Movimento inválido. Tente novamente no formato: ColunaOrigemLinhaOrigem ColunaDestinoLinhaDestino (ex: E2 E4).");
            }
        }
    }

    // Inicializa o tabuleiro com peças de xadrez padrão
    static void InicializarTabuleiro()
    {
        string linha1 = "RNBQKBNR"; // Peças de xadrez para a linha 1 e 8
        string linha2 = "PPPPPPPP"; // Peões
        string linha3 = "        "; // Espaços vazios
        string linha4 = "        ";
        string linha5 = "        ";
        string linha6 = "        ";
        string linha7 = "pppppppp"; // Peões pretos
        string linha8 = "rnbqkbnr"; // Peças pretas

        // Preencher o tabuleiro
        for (int i = 0; i < 8; i++)
        {
            tabuleiro[0, i] = linha1[i];
            tabuleiro[1, i] = linha2[i];
            tabuleiro[6, i] = linha7[i];
            tabuleiro[7, i] = linha8[i];
        }

        // Preencher as linhas vazias
        for (int i = 2; i < 6; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tabuleiro[i, j] = ' ';
            }
        }
    }

    // Exibe o tabuleiro de xadrez
    static void MostrarTabuleiro()
    {
        Console.Clear();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(tabuleiro[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Valida o formato do movimento
    static bool ValidarMovimento(string movimento)
    {
        if (movimento.Length != 5) return false;

        char colunaOrigem = movimento[0];
        char linhaOrigem = movimento[1];
        char colunaDestino = movimento[3];
        char linhaDestino = movimento[4];

        // Verifica se as colunas estão entre 'A' e 'H' e as linhas entre '1' e '8'
        return (colunaOrigem >= 'A' && colunaOrigem <= 'H' &&
                linhaOrigem >= '1' && linhaOrigem <= '8' &&
                colunaDestino >= 'A' && colunaDestino <= 'H' &&
                linhaDestino >= '1' && linhaDestino <= '8');
    }

    // Realiza o movimento
    static void FazerMovimento(string movimento)
    {
        // Converte as colunas de A-H para 0-7
        int colunaOrigem = movimento[0] - 'A'; 
        int linhaOrigem = 8 - (movimento[1] - '0'); // Converte de linha 1-8 para 7-0
        int colunaDestino = movimento[3] - 'A';
        int linhaDestino = 8 - (movimento[4] - '0'); // Converte de linha 1-8 para 7-0

        // Verifica se a origem não está vazia
        if (tabuleiro[linhaOrigem, colunaOrigem] != ' ')
        {
            // Realiza o movimento: a peça vai para o destino e a origem é limpa
            tabuleiro[linhaDestino, colunaDestino] = tabuleiro[linhaOrigem, colunaOrigem];
            tabuleiro[linhaOrigem, colunaOrigem] = ' ';
        }
    }
}
