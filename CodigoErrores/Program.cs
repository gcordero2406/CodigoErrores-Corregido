using System;

class Program
{
    static int contador = 0; //Variable global para que no se reinicie cada vez que se llama el metodo
    static void Main()
    {
        string[] catalogo = { "A", "B", "C", "D", "E" };

        double[] precios = { 10.0, 15.0, 20.0, 25.0, 30.0 };

        int[,] registros = new int[50, 3];

        int opcion = 0;

        do
        {
            Console.WriteLine("\n1. Registrar evento");
            Console.WriteLine("2. Mostrar registros");
            Console.WriteLine("3. Salir");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1: RegistrarEvento(registros, catalogo, precios); break;
                case 2: MostrarRegistros(registros, catalogo); break;
            }
        } while (opcion != 3);
    }


    static void RegistrarEvento(int[,] matriz, string[] catalogo, double[] precios)
    {
        string codigo;
        Console.Write("Ingrese código (ej: A, B, C...): ");
        codigo = Console.ReadLine();
        int pos = -1;
        for (int i = 0; i < catalogo.Length; i++) // Primer Error - El error es que el arreglo tienen una dimension de 5 (0-4) como tenia un <= el for corria 6 veces donde buscaba un catalogo[i] que no existe
        {
            if (catalogo[i] == codigo)
                pos = i;
        }


        if (pos == -1)
            Console.WriteLine("Código no encontrado");
        else
        {
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine()); //Segundo Error - Para que leer la respuesta en double si se va a meter a la matriz que es un int
            matriz[contador, 0] = pos;
            matriz[contador, 1] = cantidad; //no es necesario cambiar de nuevo
            matriz[contador, 2] = 1;
            contador++; //Tercer Error - El error es que no se incrementaba el contador, contador estaba como una variable dentro del metodo, entonces cada vez que se llamaba el metodo contador se reiniciaba a 0, entonces se agrego el contador como una variable global para que no se reinicie cada vez que se llama
        }
    }


    static void MostrarRegistros(int[,] matriz, string[] catalogo)
    {
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine("Ítem: " + catalogo[matriz[i, 0]]);
            Console.WriteLine("Cantidad: " + matriz[i, 1]);   //Cuarto Error - El error es que solo se imprimia el Item, no se imprimia la cantidad ni el estado, entonces se agregaron esas lineas
            Console.WriteLine("Estado: " + matriz[i, 2]);
        }
    }
}