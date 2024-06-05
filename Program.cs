namespace HANGMAN2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_LIVES = 10;
            const char UNDERSCORE = '_';
            Random rnd = new Random();
            List<string> veggieList = new List<string> { "pumpkin", "cucumber", "potatoes", "courgette", "spinach" };
            int index = rnd.Next(veggieList.Count);
            string randomWord = veggieList[index];
            char[] randomWordAsArray = randomWord.ToCharArray();
            Console.WriteLine(" HANGMAN GAME ");
            Console.WriteLine("  Choose a letter to guess the word.");
            Console.WriteLine(" You have 10 lives.");
            foreach (char letter in randomWord)
            {
                string letterAsString = letter.ToString();
                Console.Write(letterAsString.Replace(letter, UNDERSCORE));
            }
            for (int letter = 0; letter < randomWord.Length; letter++)
            {
                randomWordAsArray[letter] = UNDERSCORE;
            }
            int livesLeft = MAX_LIVES;
            while (livesLeft != 0) 
            {
                Console.WriteLine();
                char answer = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (!randomWord.Contains(answer))
                {
                    livesLeft--;
                    Console.WriteLine($"Wrong guess, life left {livesLeft}");
                    continue;
                }
                for (int wordIndex = 0; wordIndex < randomWord.Length; ++wordIndex)
                    {
                    if (answer == randomWord[wordIndex])
                    { 
                       randomWordAsArray[wordIndex] = answer;
                    }
                }
                string lettersFound = new string(randomWordAsArray);
                Console.WriteLine();
                Console.WriteLine("The letters you found : {0}", lettersFound);
                if (lettersFound == randomWord)
                {
                   Console.WriteLine("YOU WIN!!!");
                   break;
                }
               
            }
        }
    }
}