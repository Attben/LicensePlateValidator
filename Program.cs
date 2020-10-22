using System;

namespace LicensePlateValidator
{
    class LicensePlateValidator
    {
        public const int ALLOWED_PLATE_LENGTH = 6;
        public static readonly char[] DISALLOWED_LETTERS = { 'I', 'Q', 'V' };

        static bool IsValidLicensePlate(string plate)
        {
            if (plate.Length != ALLOWED_PLATE_LENGTH)
            {
                Console.WriteLine("Invalid plate format: Length is not equal to " +
                    ALLOWED_PLATE_LENGTH);
                return false;
            }
            else if (!(char.IsNumber(plate[3]) && char.IsNumber(plate[4])))
            {
                Console.WriteLine("Invalid plate format: Character at index " +
                    "3 or 4 is not a number.");
                return false;

            }
            foreach (var c in DISALLOWED_LETTERS)
            {
                for (int n = 0; n < 3; ++n)
                {
                    if (!char.IsLetter(plate[n]))
                    {
                        Console.WriteLine("Invalid plate format: Character at index " +
                            n + "is not a letter.");
                        return false;
                    }
                    else if (plate[n] == c)
                    {
                        Console.WriteLine("Invalid plate format: Character at index " +
                            n + "is disallowed letter " + c + ".");
                        return false;
                    }
                }
                if (plate[5] == c)
                {
                    Console.WriteLine("Invalid plate format: Character at index 5" +
                        " is disallowed letter " + c + ".");
                    return false;
                }
            }
            if (plate[5] == 'o')
            {
                Console.WriteLine("Invalid plate format: Character at index 5 " +
                    " is disallowed letter O");
                return false;
            }

            return true;

        }
        static void Main(string[] args)
        {
            string inputPlate;
            do
            {
                Console.Write("Enter a license plate (or \"quit\" to quit): ");
                inputPlate = Console.ReadLine().ToUpper();

                if (inputPlate == "QUIT")
                {
                    Console.WriteLine("Bye.");
                }
                else if (IsValidLicensePlate(inputPlate))
                {
                    Console.WriteLine(inputPlate + " is a valid Swedish license plate.");
                }
                else
                {
                    Console.WriteLine(inputPlate + " is not a valid Swedish license plate.");
                }
            } while (inputPlate != "QUIT");
        }
    }
}
