using System;
using System.Collections.Generic;
using System.Text;

namespace Tema2
{
    class Program
    {
        private static readonly ProgramBeforeDRY NonDry = new ProgramBeforeDRY();
        private static readonly ProgramDRY Dry = new ProgramDRY();
        public static void Main() {
            Console.WriteLine("Program before applying the DRY principle: ");
            NonDry.Run();
            Console.WriteLine("Program after applying the DRY principle: ");
            Dry.Run();
            Console.WriteLine("To what extent did the design decisions you made when writing the original programs make it easier or harder to factor out common code?");
            Console.WriteLine("Since we tried not to read ahead when solving the first two parts, we made some sort of 'spaghetti' code. Fortunately, we made a class for the data objects Weather and FootballTeam. That made it easier for us to refactor the code, to some extent");
            Console.WriteLine("Was the way you wrote the second program influenced by writing the first?");
            Console.WriteLine("Since we figured out the parsing function as well as the necessity to hold the information extracted from the dat file in a class, after figuring out the parsing logic for the weather dat file, we just needed to figure out the logic behind parsing the football file. But the steps we needed to take remained the same, only the column information changed.");
            Console.WriteLine("Is factoring out as much common code as possible always a good thing? Did the readability of the programs suffer because of this requirement? How about the maintainability?");
            Console.WriteLine("In the best case scenario, we start writing the code in a DRY principle from the get-go. Good code writing habits save you a lot of time and effort in writing code. Besides, as we figured out the hard way, after refactoring the code, readability and mantainability improved significantly. Refactored code is easier to grasp, and can be understood by anyone who reads it, without being given the context behind it.");
            Console.WriteLine("Ce ati invatat din acest kata?");
            Console.WriteLine("Acest kata ne-a facut sa ne regandim obisnuintele de a scrie cod. De multe ori pe parcursul facultatii, nu ne gandeam inainte cum am putea sa optimizam procesul de scriere de cod, ne apucam de scris si ce iesea era bun atata timp cat mergea si facea ce trebuie. On the long run, mentalitatea aceasta nu e cea mai eficienta.");
        }
    }
}
