using System;
using static System.Console;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
        string lang = "en-US", input;
        byte decision, precisionPreference=2;
        double firstOperand, secondOperand, result;
        ConsoleKey keyPressed;
        FirstPhase:
            Title = MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CONSOLE_TITLE);
            do
            {
                Clear();
                if (lang == "en-US") WriteLine(@"   ______        __              __        __                        ___   ____  ___ 
  / ____/____ _ / /_____ __  __ / /____ _ / /_ ____   _____   _   __<  /  / __ \|__ \
 / /    / __ `// // ___// / / // // __ `// __// __ \ / ___/  | | / // /  / / / /__/ /
/ /___ / /_/ // // /__ / /_/ // // /_/ // /_ / /_/ // /      | |/ // /_ / /_/ // __/ 
\____/ \__,_//_/ \___/ \__,_//_/ \__,_/ \__/ \____//_/       |___//_/(_)\____//____/ 
");
                else if (lang == "pt-PT") WriteLine(@"   ______        __              __            __                             ___   ____  ___ 
  / ____/____ _ / /_____ __  __ / /____ _ ____/ /____   _____ ____ _   _   __<  /  / __ \|__ \
 / /    / __ `// // ___// / / // // __ `// __  // __ \ / ___// __ `/  | | / // /  / / / /__/ /
/ /___ / /_/ // // /__ / /_/ // // /_/ // /_/ // /_/ // /   / /_/ /   | |/ // /_ / /_/ // __/ 
\____/ \__,_//_/ \___/ \__,_//_/ \__,_/ \__,_/ \____//_/    \__,_/    |___//_/(_)\____//____/ 
");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MAIN_MENU));
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ADD));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SUBTRACT));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MULTIPLY));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DIVIDE));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.REST_OF_DIVISION));
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SETTINGS));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_CONSOLE));
                Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "operation"));
                keyPressed = ReadKey(true).Key;
                if (keyPressed == ConsoleKey.E) goto ExitConsole;
                else if (keyPressed == ConsoleKey.S) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            do
            {
                Clear();
                input = ReadLine();
            } while (!double.TryParse(input, out firstOperand)); // input can't have letters, be null or empty and must fit into a double
            do
            {
                Clear();
                Write($"{Math.Round(firstOperand, precisionPreference)} {getOperation(decision)} ");
                input = ReadLine();
            } while (!double.TryParse(input, out secondOperand)); // input can't have letters, be null or empty and must fit into a double
            result = Calculate(getOperation(decision), firstOperand, secondOperand);
            goto SecondPhase;
        SecondPhase:
            do
            {
                string lastOperation = getOperation(decision);
                do
                {
                    Clear();
                    if (lang == "en-US") WriteLine($"Previous calculus: ({Math.Round(firstOperand, precisionPreference)} {lastOperation} {Math.Round(secondOperand, precisionPreference)}) = {Math.Round(result, precisionPreference)}");
                    else if (lang == "pt-PT") WriteLine($"Cálculo anterior: ({Math.Round(firstOperand, precisionPreference)} {lastOperation} {Math.Round(secondOperand, precisionPreference)}) = {Math.Round(result, precisionPreference)}");
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ADD));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SUBTRACT));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MULTIPLY));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DIVIDE));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.REST_OF_DIVISION));
                    WriteLine("");
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CLEAR_RESULT));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.RESTART_CONSOLE));
                    WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_CONSOLE));
                    Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "operation"));
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.C) result = 0;
                    else if (keyPressed == ConsoleKey.R) goto FirstPhase;
                    else if (keyPressed == ConsoleKey.E) goto ExitConsole;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Clear();
                    Write($"{Math.Round(result, precisionPreference)} {getOperation(decision)} ");
                    input = ReadLine();
                } while (!double.TryParse(input, out secondOperand)); // input can't have letters, be null or empty and must fit into a double
                firstOperand = result;
                result = Calculate(getOperation(decision), result, secondOperand);
            } while (true);
        Settings:
            do
            {
                Clear();
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SETTINGS_MENU));
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CHANGE_LANGUAGE));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CHANGE_COLOR));
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE));
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "L, C, D").Replace("@type", "setting"));
                keyPressed = ReadKey(true).Key;
                if (keyPressed == ConsoleKey.L) goto ChangeLanguage;
                else if (keyPressed == ConsoleKey.C) goto ChangeColor;
                else if (keyPressed == ConsoleKey.D) goto ChangePrecisionPreference;
                else if (keyPressed == ConsoleKey.E) goto FirstPhase;
            } while (true);
        ChangeLanguage:
            do
            {
                Clear();
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.LANGUAGE_MENU));
                WriteLine("");
                if (lang == "en-US")
                {
                    WriteLine($"Current language: {lang}");
                    WriteLine("en-US (default)            (1)");
                }
                else if (lang == "pt-PT")
                {
                    WriteLine($"Linguagem atual: {lang}");
                    WriteLine("en-US (padrão)             (1)");
                }
                WriteLine("pt-PT                      (2)");
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 2").Replace("@type", "language"));
                keyPressed = ReadKey(true).Key;
                if(keyPressed == ConsoleKey.E) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 2, decision)); // keyPressed can only be between 1 and 2 ; D1 -> 1
            if (decision == 1) lang = "en-US";
            else if (decision == 2) lang = "pt-PT";
            goto ChangeLanguage;
        ChangeColor:
            do
            {
                Clear();
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.COLORS_MENU));
                WriteLine("");
                WriteLine("Background Color:");
                WriteLine(" Black                     (1)");
                WriteLine(" Red                       (2)");
                WriteLine(" Blue                      (3)");
                WriteLine(" Green                     (4)");
                WriteLine(" Cyan                      (5)");
                WriteLine("Foreground Color:");
                WriteLine(" Black                     (6)");
                WriteLine(" Red                       (7)");
                WriteLine(" Blue                      (8)");
                WriteLine(" Green                     (9)");
                WriteLine(" Cyan                      (0)");
                WriteLine("");
                WriteLine("Reset both colors          (R)");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "0, 9").Replace("@type", "color"));
                keyPressed = ReadKey(true).Key;
                if(keyPressed == ConsoleKey.R)
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.Gray;
                }
                else if (keyPressed == ConsoleKey.E) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(0, 9, decision)); // keyPressed can only be between 0 and 9 ; D1 -> 1
            switch (decision)
            {
                case 1: BackgroundColor = ConsoleColor.Black; break;
                case 2: BackgroundColor = ConsoleColor.DarkRed; break;
                case 3: BackgroundColor = ConsoleColor.DarkBlue; break;
                case 4: BackgroundColor = ConsoleColor.DarkGreen; break;
                case 5: BackgroundColor = ConsoleColor.DarkCyan; break;
                case 6: ForegroundColor = ConsoleColor.Black; break;
                case 7: ForegroundColor = ConsoleColor.DarkRed; break;
                case 8: ForegroundColor = ConsoleColor.DarkBlue; break;
                case 9: ForegroundColor = ConsoleColor.DarkGreen; break;
                case 0: ForegroundColor = ConsoleColor.DarkCyan; break;
            } goto ChangeColor;
        ChangePrecisionPreference:
            do
            {
                Clear();
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE_MENU));
                WriteLine("");
                string example = "0.";
                Random random = new Random();
                for (int i = 1; i <= precisionPreference; i++) example += random.Next(9); //random numbers for var 'example'
                if (lang == "en-US")
                {
                    WriteLine($"Current decimal places preference: {precisionPreference} (ex. {example})");
                    WriteLine("1 DP                       (1)");
                    WriteLine("2 DP (default)             (2)");
                }
                else if (lang == "pt-PT")
                {
                    WriteLine($"Atual preferência de casas decimais: {precisionPreference} (ex. {example})");
                    WriteLine("1 DP                       (1)");
                    WriteLine("2 DP (padrão)              (2)");
                }
                WriteLine("3 DP                       (3)");
                WriteLine("4 DP                       (4)");
                WriteLine("5 DP                       (5)");
                WriteLine("");
                WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "preference"));
                keyPressed = ReadKey(true).Key;
                if (keyPressed == ConsoleKey.E) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            precisionPreference = decision;
            goto ChangePrecisionPreference;
        ExitConsole:
            Beep();
        }
        static bool inRange(int min, int max, int i) { return i >= min && i <= max; }
        static String getOperation(byte num)
        {
            switch (num)
            {
                case 1: return "+";
                case 2: return "-";
                case 3: return "*";
                case 4: return "/";
                case 5: return "%";
            }return null; // null path
        }
        static double Calculate(String operation, double num1, double num2)
        {
            switch (operation)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/":
                    if (num2 != 0) return num1 / num2;
                    else return 0; // impossible operation
                case "%":
                    if (num2 != 0) return num1 % num2;
                    else return 0; // impossible operation
            }return 0; // null path
        }
    }
}//by Gui1herme#8721
