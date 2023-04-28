public class Program
{
    const int length = 5;
    const int width = 5;
    public static string[,] options = new string[length, width] { { "a ", "b ", "c ", "d ", "e " }, { "f ", "g ", "h ", "i ", "j " }, { "k ", "l ", "m ", "n ", "o " }, { "p ", "q ", "r ", "s ", "t " }, { "u ", "v ", "w ", "x ", "y " } };
    static void Main(string[] args)
    {
        // Create options that you want your menu to have
        //options = new Option[][]

        // Set the default index of the selected item to be the first
        int indexX = 2;
        int indexY = 2;
        // Write the menu out
        WriteMenu(options, options[indexX, indexY]);
        List<string> list = new List<string>();
        // Store key info in here
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            // Handle each key input (down arrow will write the menu again with a different selected item)

            switch (keyinfo.Key)
            {
                case ConsoleKey.DownArrow:
                    if (indexX + 1 < width)
                    {
                        indexX++;
                        WriteMenu(options, options[indexX, indexY]);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (indexX - 1 >= 0)
                    {
                        indexX--;
                        WriteMenu(options, options[indexX, indexY]);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (indexY + 1 < length)
                    {
                        indexY++;
                        WriteMenu(options, options[indexX, indexY]);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (indexY - 1 >= 0)
                    {
                        indexY--;
                        WriteMenu(options, options[indexX, indexY]);
                    }
                    break;
                case ConsoleKey.S:
                    //Console.WriteLine("You selected " + options[indexX, indexY]);
                    // indexX = 2;
                    // indexY = 2;
                    list.Add(options[indexX, indexY]);
                    break;
                case ConsoleKey.Enter:
                    Console.WriteLine($"You selected {string.Join(" ", list)}");
                    // indexX = 2;
                    // indexY = 2;
                    //list.Add(options[indexX, indexY]);
                    break;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();
        Credit(
    }
    // Default action of all the options. You can create more methods
    static void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(3000);
        WriteMenu(options, options[0, 0]);
    }


    ///<summary>
    ///Writes the menu to the console
    ///</summary>
    ///<remarks>
    ///<param name="options">The options to write</param>
    ///<param name="selected">The selected option</param>
    ///<example>
    ///This shows how to call the <see cref="WriteMenu"/> method from your code.
    /// <code>
    ///     string[,] options = new string[2, 2] { { "a ", "b " }, { "c ", "d " } };
    ///     WriteMenu(options, options[0, 0]);
    ///     Console.ReadKey();
    ///</code>
    ///</example>
    ///</remarks>
    static void WriteMenu(string[,] options, string selected)
    {
        Console.Clear();
        for (int i = 0; i < options.GetLength(0); i++)
        {
            for (int j = 0; j < options.GetLength(1); j++)
            {
                if (options[i, j] == selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(options[i, j]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(options[i, j]);
                }
            }
            Console.WriteLine();
        }
        Console.Write("> ");
    }
    /// <summary>
    /// This method changes the point's location by the given x- and y-offsets.
    /// </summary>
    /// <remarks>
    /// <example>
    /// For example:
    /// <code>
    ///     Point p = new Point(3,5);
    ///     p.Translate(-1,3);
    /// </code>
    /// results in <c>p</c>'s having the value (2,8).
    /// </example>
    /// </remarks>
    public void Credit(int amount)
    {

        int Balance = amount;

    }

}