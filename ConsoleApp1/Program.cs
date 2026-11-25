class Program
{
    static void Main(string[] args)
    {
        //Variabler
        bool run = true;
        int menu = 0; 
        string? input = ""; 
        double temprature = 0;
        double windSpeed = 0;
        double windChillTemprature = 0;
        
        while (run)
        {
            //Presentera menyn för användare, while loop som kräver att menu är en int
            while (true)
            {
                Console.WriteLine("Välj ett menyalternativ:\n1. Räkna Windchill\n2. Avsluta programmet");
                
                //Checka om input är en int och 1 eller 2
                if (int.TryParse(Console.ReadLine(), out menu) && (menu == 1 || menu == 2))
                {
                    break;
                }

                Console.WriteLine("Ogiltigt menyval. Skriv 1 eller 2.");
            }
            
            //Switch för menyn
            switch (menu)
            {
                case 1:
                    Console.WriteLine("Skriv temperaturen i Celsius:");
                    while (!double.TryParse(Console.ReadLine(), out temprature))
                    {
                        Console.WriteLine("Ogiltig temperatur. Försök igen:");
                    }

                    Console.WriteLine("Skriv vindhastigheten:");
                    while (!double.TryParse(Console.ReadLine(), out windSpeed))
                    {
                        Console.WriteLine("Ogiltig vindhastighet. Försök igen:");
                    }
                    
                    while (true)
                    {
                        Console.WriteLine("Skriv km/h eller m/s");
                        input = Console.ReadLine();
                        if (input == "m/s")
                        {
                            windSpeed *= 3.6;
                        }

                        if ((input == "m/s" || input == "km/h"))
                        {
                            break;
                        }
                    }

                    windChillTemprature = 13.12 + 0.6215 * temprature - 11.37 * Math.Pow(windSpeed, 0.16) + 0.3965 * temprature * Math.Pow(windSpeed, 0.16);

                    Console.WriteLine($"Det är {temprature} grader ute men det känns som {windChillTemprature.ToString("F1")} grader.");

                    if (windChillTemprature < -60)
                    {
                        Console.WriteLine("Stor risk för frostskada");
                    }
                    else if (windChillTemprature > -35 && windChillTemprature <= -60)
                    {
                        Console.WriteLine("Risk för frostskada");
                    }
                    else if (windChillTemprature > -25 && windChillTemprature <= -35)
                    {
                        Console.WriteLine("Mycket Kallt");
                    }
                    else
                    {
                        Console.WriteLine("Kallt");
                    }
                    
                    Console.WriteLine("Tack för att du använt prorgrammet, du hamnar på menyn alldeles strax.");
                    
                    Thread.Sleep(5000);
                    
                    break;
                case 2:
                    run = false;
                    
                    Console.WriteLine("Programmet Avslutas");
                    break;
                default:
                    Console.WriteLine("Du skrev fel meny val, skriv ett giltigtval");
                    break;
            }
        }
    }
}