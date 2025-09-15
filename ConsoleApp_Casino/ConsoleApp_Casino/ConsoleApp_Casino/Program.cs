// See https://aka.ms/new-console-template for more information
//--------------------------------------------------
// Codigo de PRÁCTICA, VIDEOS DE PLATZI DEL 14 AL 16
// -------------------------------------------------
// Blackjack, juntar 21 pidiendo cartas 

//Utilizaremos return para romper el ciclo while
//Utilizaremos la variable switchControl para manejar el swicth
string switchControl = "menu";
System.Random random = new System.Random();


while (true)
{
    
    string message = "";
    string cartaControl = "";
    int coins = 0;
    Console.WriteLine("Cuantos coins deseas ?");
    coins = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < coins; i++) {
        Console.WriteLine("Valor de i : " + i);
        int totalJugador = 0;
        int totalDealer = 0;
        int num = 0;
        switch (switchControl)
    {
        case "menu":
            Console.WriteLine("BIENVENIDO AL CASINO");
            Console.WriteLine("Juegos disponibles: ");
            Console.WriteLine("Escriba 21 para jugar Blackjack\nEscriba 0 para salir ");
            switchControl = Console.ReadLine(); // Variable que controla el switch
            break;

        case "21":

            // En este bucle, la primera iteracion siempre se realiza 
            do
            {
               
                totalDealer = random.Next(1, 12);
                num = random.Next(1, 12);
                totalJugador = totalJugador + num;
                Console.WriteLine($"Toma tu carta.  \n te salio el numero: {num}  ");
                Console.WriteLine("Deseas otra carta?");
                cartaControl = Console.ReadLine();

            } while (cartaControl == "Si" || cartaControl == "si" || cartaControl == "s");
            // Aqui termina el bloque do while
            //Se obtiene la carta del dealer
            totalDealer = random.Next(1, 12);
            Console.WriteLine("Carta del dealer: " + totalDealer);
            if (totalJugador > totalDealer && totalJugador < 22)
            {
                message = "Venciste al dealer";
                switchControl = "menu";
            }
            else if (totalJugador >= 22)
            {
               
                message = "Te pasaste de 21, perdiste!";
                switchControl = "menu";
            }
            else if (totalJugador <= totalDealer)
            {
                message = "Perdiste vs el dealer, lo siento";

                switchControl = "menu";
            }
            Console.WriteLine(message);
            break;

        case "0":
            Console.WriteLine("Saliendo...");
            return;
        default:
            // Al caer en este bloque, se genera un bucle infinito, ya que no hay un return o no se utiliza una variable que cambie el valor booleano del while
            Console.WriteLine("Valor ingresado no valido en el C A S I N O");

            break;
    }// Cerramos switch
}// cerramos ciclo for
}// cerramos ciclo while

