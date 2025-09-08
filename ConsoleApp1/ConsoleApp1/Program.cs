// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("Hello World!");

Console.WriteLine("Hello World!");
Console.WriteLine("I am Learning C#");
Console.WriteLine("It is awesome!");
Console.WriteLine(3 + 3);
int myvar = 1;
int myVar = 2;

Console.WriteLine(myvar);
Console.WriteLine(myVar);
*/
/*
int myInt = 9;
double myDouble = myInt;       // Automatic casting: int to double

Console.WriteLine(myInt);      // Outputs 9
Console.WriteLine(myDouble);   // Outputs 9
*/
/*
double myDouble = 9.78;
int myInt = (int)myDouble;    // Manual casting: double to int

Console.WriteLine(myDouble);   // Outputs 9.78
Console.WriteLine(myInt);      // Outputs 9

int myInt = 10;
double myDouble = 5.25;
bool myBool = true;
int bolleano = 10;
Console.WriteLine(Convert.ToString(myInt));    // convert int to string
Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
Console.WriteLine(Convert.ToUInt32(myBool));
Console.WriteLine(Convert.ToBoolean(bolleano));
// convert bool to string// convert bool to string
*/
/*
// Type your username and press enter
Console.WriteLine("Enter username:");

// Create a string variable and get user input from the keyboard and store it in the variable
string userName = Console.ReadLine();

// Print the value of the variable (userName), which will display the input value
Console.WriteLine("Username is: " + userName);

Console.WriteLine("Enter your age:");
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Your age is: " + age);
*/
/*int sum1 = 100 + 50;        // 150 (100 + 50)
int sum2 = sum1 + 250;      // 400 (150 + 250)
int sum3 = sum2 + sum2;     // 800 (400 + 400)
*/

// Programa de introduccion a C#

Console.WriteLine("Hola, Ingresa los siguientes datos");
Console.WriteLine("Tu nombre: ");
string nombre = Console.ReadLine();

Console.WriteLine("Tu edad: ");
int edad = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Tu estatura: ");
float estatura = float.Parse(Console.ReadLine());

Console.WriteLine("Tu nombre es: "+nombre + ", tienes "+edad+
    " años y mides "+estatura);

Console.WriteLine("Ingresa un primer numero para sumar");
int numA = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ingresa un segundo numero para sumar");
int numB = Convert.ToInt32(Console.ReadLine());

int resultado = numA + numB;
Console.WriteLine(resultado);
Console.WriteLine(numA += 9);
Console.WriteLine(numB -= 2);
Console.WriteLine(numA *=2);    
Console.WriteLine(numB /=2);


bool valorA = true;
bool valorB = false;
// Al menos 1 debe ser true
bool booleanoA = valorA || valorB;

Console.WriteLine(booleanoA);


// Ambos deben ser true
bool booleanoB = valorA && valorB;

Console.WriteLine(booleanoB);
// -----------------


