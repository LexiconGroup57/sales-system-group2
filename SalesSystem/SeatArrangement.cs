namespace SalesSystem;

using System;

// TO DO: IMPLEMENT "TRY", "CATCH" AND "FINALLY"

public class SeatArrangement
{
     // Declares and instances array that cannot be replaced from outside (only the values can)
     public int[] Seats { get; private set; } = new int[54];
     
     // 1 Array below is for displaying seat matrix
     // 2 Define the dimensions for seat display
     public int[] DisplaySeats = new int[2];    // 1
     
     // Constants for the array, private to make sure they're not altered somehow.
     private const int DisplayColumns = 9; // 2
     private const int DisplayRows = 6; // 2

     // Makes a readonly val called TotalSeats based on the total number of slots in the Seats array.
     public int TotalSeats => Seats.Length;
     

     
     // BASIC CONSTRUCTOR FOR ARRAY. USEFUL FOR MOVIE CLASS?
     public SeatArrangement()
     {
          // TO MEMBERS: Do you guys need anything else here?

          //Initialize all seats as available (0)
          for (int i = 0; i < Seats.Length; i++)
          {
               Seats[i] = 0;
               // How do I print the index number instead of the value?
          }
     }

     // +-----------------------------------+
     // |        SEAT RESERVATION           |
     // | [GREEN] = Avail. [RED] = Reserved |
     // |                                   |
     // |  Returns selected seat number     |
     // |  for ticket assignment            |
     // +-----------------------------------+
     public int checkAndFillSeat()
     {
          Console.WriteLine("See available seats below (marked with 0)");
          Console.WriteLine(); // create space
          PrintSeatArrayColored(); // PRINTS CURRENT STATE OF MOVIE'S SEAT ARRAY
          Console.WriteLine(); // create space

          Console.Write("Enter the requested seat: ");
          int checkSeat;
          //Checks if input is valid, otherwise restarts method
          if(int.TryParse(Console.ReadLine(), out checkSeat))
          {
               // Continue with the valid input
               bool seatAvailability = isSeatAvailable(checkSeat);

               
               if(seatAvailability == true)
               {
                    // Mark the seat as taken (1)
                    Seats[checkSeat-1] = 1;
                    Console.WriteLine($"Seat {checkSeat} has now been reserved.");
                    return checkSeat;
               }
               else // restarts sequence after confirming if it's false
               {
                    Console.WriteLine("Click any button to check another seat.");
                    Console.ReadLine();
                    return checkAndFillSeat();
               }
          }
          else 
          {
               Console.WriteLine("Invalid input. Please enter a number.");
               return checkAndFillSeat();
          }
     }

     // IS THE SEAT AVAILABLE? 0 = available, 1 = filled.
     // The fallback is handled inside of the checkAndFillSeat method
     public bool isSeatAvailable(int seatNumber)
     {
          // Check if seat number is valid (within array bounds)
          if(seatNumber < 0 || seatNumber >= Seats.Length)
          {
               Console.WriteLine("Invalid seat number. Please choose between 0 and " + (Seats.Length - 1));
               return false;
          }
          
          // Check if seat is available (value is 0)
          if(Seats[seatNumber - 1] == 0)
          {
               Console.WriteLine("This seat is available.");
               return true;
          }
          else if(Seats[seatNumber] == 1)
          {
               Console.WriteLine("This seat is not available.");
               return false;
          }
          else
          {
               return false;
          }
     }


     public void PrintSeatArrayColored()
     {
          // Runs the loop until we've run through the number of rows the cinema room has.
          for (int row = 0; row < DisplayRows; row++)
          {
               Console.WriteLine();
               // Runs through the loop for the number of columns we have.
               for (int col = 0; col < DisplayColumns; col++)
               {
                    // Correctly assigns the value we want to print to the seating.
                    // If row=1 and the column=2, then 1*9+2=11 (the second column on the second row)
                    int index = row * DisplayColumns + col;
                    int value = Seats[index]; // 0 empty, 1 occupied, etc.

                    // Choose colors. This will globally enforce these color values to the printout this loop.
                    // At the end of this for-run we clear it with Console.ResetColor(); and run the loop again.
                    if (value == 0)
                    {
                         Console.BackgroundColor = ConsoleColor.DarkGreen;  // empty
                         Console.ForegroundColor = ConsoleColor.Black; // Text counts as foreground
                    }
                    else
                    {
                         Console.BackgroundColor = ConsoleColor.DarkRed;    // occupied
                         Console.ForegroundColor = ConsoleColor.White; // Text counts as foreground
                    }

                    // Write a fixed-width “cell”. The fixed width comes from the "alignment" value 2 within {}.
                    // Basically. ($" expression, alignment} ")
                    Console.Write($" {index + 1,2} ");

                    // Reset for safety so next writes (like newlines) aren’t colored
                    Console.ResetColor();
               }
          }
     }
}