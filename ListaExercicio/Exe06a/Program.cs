// Passos para resolver o bubble sort
// 1 - Criar um vetor para receber 100 posições
// 2 - Criar um laço de repetição para percorrer o vetor
// 3 - Preencher cada posição com um valor aleatório
// 4 - Imprimir o vetor com valores aleatórios

int[] numeros = new int[100];
Random aleatorio = new Random();

for (int i = 0; i < 100; i++)
{
    numeros[i] = aleatorio.Next(1,101);
}

for (int i = 0; i < 100; i++)
{
    Console.Write(numeros[i] + " ");
}

// 5 - Percorrer o vetor com valores aleatórios
// 6 - Comparar a posição atual com a próxima
// 7 - Se a posição atual for maior do que a próxima, inverte
// 8 - Imprimir o vetor com valores ordenados
Boolean trocou = false;
do
{
    trocou = false;
    for (int i = 0; i < numeros.Length - 1; i++)
    {
        int posicaoAtual = numeros[i];
        int proxima = numeros[i + 1];
        int trocador = 0;

        if (proxima < posicaoAtual)
        {
            trocador = posicaoAtual;
            numeros[i] = proxima;
            numeros[i + 1] = trocador;
            trocou = true;
        }
    }
} while (trocou);

Console.WriteLine("");
Console.WriteLine("");

for (int i = 0; i < 100; i++)
{   
    Console.Write(numeros[i] + " ");
}