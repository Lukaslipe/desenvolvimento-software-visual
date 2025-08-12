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

Array.Sort(numeros);

Console.WriteLine("");
Console.WriteLine("");

for (int i = 0; i < 100; i++)
{   
    Console.Write(numeros[i] + " ");
}