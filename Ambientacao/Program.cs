Console.Write("Digite a altura: ");
float altura = float.Parse(Console.ReadLine());

Console.Write("Digite a largura: ");
float largura = float.Parse(Console.ReadLine());

float area = altura * largura;
Console.WriteLine("A área do retângulo é: " + area);

Console.Write("Digite o valor em real: ");
float real = float.Parse(Console.ReadLine());

Console.WriteLine("O valor em Dólar é: " + real / 5.17);
Console.WriteLine("O valor em Euro é: " + real / 6.14);
Console.WriteLine("O valor em Peso argentino é: " + real / 0.05);

Console.WriteLine("Digite o primeiro número: ");
float num1 = float.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo número: ");
float num2 = float.Parse(Console.ReadLine());

if (num1 > num2)
{
    Console.WriteLine(num1 + " é maior do que: " + num2);
}
else
{
    Console.WriteLine(num2 + " é maior do que: " + num1);
}

Console.WriteLine("Digite a idade: ");
float idade = float.Parse(Console.ReadLine());

if (idade <= 13)
{
    Console.WriteLine("Criança");
}
else if (idade > 13 || idade <= 18)
{
    Console.WriteLine("Adolescente");
}
else if (idade > 13 || idade <= 60)
{
    Console.WriteLine("Adulto");
}
else
{
    Console.WriteLine("Idoso");
}

Console.Write("Digite um número inteiro positivo: ");
int limite = int.Parse(Console.ReadLine());

if (limite < 0)
{
    Console.WriteLine("O número deve ser positivo.");
    return;
}

int a = 0;
int b = 1;

Console.Write("Sequência de Fibonacci até " + limite + ": ");

while (a <= limite)
{
    Console.Write(a + " ");
    int temp = a + b;
    a = b;
    b = temp;
}

int[] vetor = new int[1000];
Random rnd = new Random();

for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = rnd.Next(0, 10000);
}

Ordenador(vetor);

Console.WriteLine("Vetor ordenado (20 primeiros valores):");
for (int i = 0; i < 20; i++)
{
    Console.Write(vetor[i] + " ");
}


static void Ordenador(int[] vetor)
{
    int n = vetor.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - 1 - i; j++)
        {
            if (vetor[j] > vetor[j + 1])
            {
                int temp = vetor[j];
                vetor[j] = vetor[j + 1];
                vetor[j + 1] = temp;
            }
        }
    }
}

