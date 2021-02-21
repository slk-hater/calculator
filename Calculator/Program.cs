using System;
using static System.Console;

namespace Calculator
{
    class Program
    {
        public static string language = "en-US";
        static void Main()
        {
        sbyte decision, precisionPreference=2;
        double firstOperand, secondOperand, result;
        ConsoleKey keyPressed;
        FirstPhase:
            Title=MultiLang.MessageByLang(MultiLang.MessagesEnum.CONSOLE_TITLE);
            do
            {
                Clear();
                WriteLine(MultiLang.StringByLang(@"   ______        __              __        __                        ___   ____  ___ 
  / ____/____ _ / /_____ __  __ / /____ _ / /_ ____   _____   _   __<  /  / __ \|__ \
 / /    / __ `// // ___// / / // // __ `// __// __ \ / ___/  | | / // /  / / / /__/ /
/ /___ / /_/ // // /__ / /_/ // // /_/ // /_ / /_/ // /      | |/ // /_ / /_/ // __/ 
\____/ \__,_//_/ \___/ \__,_//_/ \__,_/ \__/ \____//_/       |___//_/(_)\____//____/ 
", @"   ______        __              __            __                             ___   ____  ___ 
  / ____/____ _ / /_____ __  __ / /____ _ ____/ /____   _____ ____ _   _   __<  /  / __ \|__ \
 / /    / __ `// // ___// / / // // __ `// __  // __ \ / ___// __ `/  | | / // /  / / / /__/ /
/ /___ / /_/ // // /__ / /_/ // // /_/ // /_/ // /_/ // /   / /_/ /   | |/ // /_ / /_/ // __/ 
\____/ \__,_//_/ \___/ \__,_//_/ \__,_/ \__,_/ \____//_/    \__,_/    |___//_/(_)\____//____/ 
"));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.MAIN_MENU));
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.ADD));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.SUBTRACT));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.MULTIPLY));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.DIVIDE));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.REST_OF_DIVISION));
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.SETTINGS));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_CONSOLE));
                Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", MultiLang.StringByLang("operation", "operaçao")));
                keyPressed=ReadKey(true).Key;
                if (keyPressed==ConsoleKey.E) goto ExitConsole;
                else if (keyPressed==ConsoleKey.S) goto Settings;
            } while (!sbyte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !InRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            do Clear(); while (!double.TryParse(ReadLine(), out firstOperand)); // input can't have letters, be null or empty and must fit into a double
            do
            {
                Clear();
                Write($"{firstOperand} {GetOperation(decision)} ");
            } while (!double.TryParse(ReadLine(), out secondOperand)); // input can't have letters, be null or empty and must fit into a double
            result=Calculate(firstOperand, GetOperation(decision), secondOperand);
            goto SecondPhase;
        SecondPhase:
            do
            {
                string lastOperation=GetOperation(decision);
                do
                {
                    Clear();
                    WriteLine(MultiLang.StringByLang($"Previous calculus: ({firstOperand} {lastOperation} {secondOperand}) = {Math.Round(result, precisionPreference)}", $"Cálculo anterior: ({firstOperand} {lastOperation} {secondOperand}) = {Math.Round(result, precisionPreference)}"));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.ADD));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.SUBTRACT));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.MULTIPLY));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.DIVIDE));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.REST_OF_DIVISION));
                    WriteLine();
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.CLEAR_RESULT));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.RESTART_CONSOLE));
                    WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_CONSOLE));
                    Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", MultiLang.StringByLang("operation", "operaçao")));
                    keyPressed=ReadKey(true).Key;
                    if (keyPressed==ConsoleKey.C) result=0;
                    else if (keyPressed==ConsoleKey.R) goto FirstPhase;
                    else if (keyPressed==ConsoleKey.E) goto ExitConsole;
                } while (!sbyte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !InRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Clear();
                    Write($"{Math.Round(result, precisionPreference)} {GetOperation(decision)} ");
                } while (!double.TryParse(ReadLine(), out secondOperand)); // input can't have letters, be null or empty and must fit into a double
                firstOperand=result;
                result=Calculate(result, GetOperation(decision), secondOperand);
            } while (true);
        Settings:
            do
            {
                Clear();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.SETTINGS_MENU));
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.CHANGE_LANGUAGE));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.CHANGE_COLOR));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE));
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "L, C, D").Replace("@type", MultiLang.StringByLang("setting", "definiçao")));
                keyPressed=ReadKey(true).Key;
                if (keyPressed==ConsoleKey.L) goto ChangeLanguage;
                else if (keyPressed==ConsoleKey.C) goto ChangeColor;
                else if (keyPressed==ConsoleKey.D) goto ChangePrecisionPreference;
                else if (keyPressed==ConsoleKey.E) goto FirstPhase;
            } while (true);
        ChangeLanguage:
            do
            {
                Clear();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.LANGUAGE_MENU));
                WriteLine();
                WriteLine(MultiLang.StringByLang($"Current language: {language}", $"Linguagem atual: {language}"));
                WriteLine(MultiLang.StringByLang($" en-US (default)            (1)", $" en-US (padrão)             (1)"));
                WriteLine(" pt-PT                      (2)");
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 2").Replace("@type", MultiLang.StringByLang("language", "linguagem")));
                keyPressed=ReadKey(true).Key;
                if(keyPressed==ConsoleKey.E) goto Settings;
            } while (!sbyte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !InRange(1, 2, decision)); // keyPressed can only be between 1 and 2 ; D1 -> 1
            if (decision==1) language="en-US";
            else if (decision==2) language="pt-PT";
            goto ChangeLanguage;
        ChangeColor:
            do
            {
                Clear();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.COLORS_MENU));
                WriteLine();
                WriteLine(MultiLang.StringByLang("Background Color:", "Cor de fundo:"));
                WriteLine(MultiLang.StringByLang(" Black                      (1)", " Preto                      (1)"));
                WriteLine(MultiLang.StringByLang(" Red                        (2)", " Vermelho                   (2)"));
                WriteLine(MultiLang.StringByLang(" Blue                       (3)", " Azul                       (3)"));
                WriteLine(MultiLang.StringByLang(" Green                      (4)", " Verde                      (4)"));
                WriteLine(MultiLang.StringByLang(" Cyan                       (5)", " Ciano                      (5)"));
                WriteLine(MultiLang.StringByLang("Foreground Color:", "Cor das letras:"));
                WriteLine(MultiLang.StringByLang(" Black                      (6)", " Preto                      (6)"));
                WriteLine(MultiLang.StringByLang(" Red                        (7)", " Vermelho                   (7)"));
                WriteLine(MultiLang.StringByLang(" Blue                       (8)", " Azul                       (8)"));
                WriteLine(MultiLang.StringByLang(" Green                      (9)", " Verde                      (9)"));
                WriteLine(MultiLang.StringByLang(" Cyan                       (0)", " Ciano                      (0)"));
                WriteLine();
                WriteLine(MultiLang.StringByLang("Reset the colors            (R)", "Resetar as cores            (R)"));
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "0, 9").Replace("@type", MultiLang.StringByLang("color", "cor")));
                keyPressed=ReadKey(true).Key;
                if (keyPressed==ConsoleKey.R) ResetColor();
                else if (keyPressed==ConsoleKey.E) goto Settings;
            } while (!sbyte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !InRange(0, 9, decision)); // keyPressed can only be between 0 and 9 ; D1 -> 1
            switch (decision)
            {
                case 1: BackgroundColor=ConsoleColor.Black; break;
                case 2: BackgroundColor=ConsoleColor.DarkRed; break;
                case 3: BackgroundColor=ConsoleColor.DarkBlue; break;
                case 4: BackgroundColor=ConsoleColor.DarkGreen; break;
                case 5: BackgroundColor=ConsoleColor.DarkCyan; break;
                case 6: ForegroundColor=ConsoleColor.Black; break;
                case 7: ForegroundColor=ConsoleColor.DarkRed; break;
                case 8: ForegroundColor=ConsoleColor.DarkBlue; break;
                case 9: ForegroundColor=ConsoleColor.DarkGreen; break;
                case 0: ForegroundColor=ConsoleColor.DarkCyan; break;
            } goto ChangeColor;
        ChangePrecisionPreference:
            do
            {
                Clear();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE_MENU));
                WriteLine();
                string example="0.";
                Random random=new Random();
                for (int i=1; i<=precisionPreference; i++) example+=random.Next(9); //random numbers for var 'example'
                WriteLine(MultiLang.StringByLang($"Current decimal places preference: {precisionPreference} (ex. {example})", $"Atual preferência de casas decimais: {precisionPreference} (ex. {example})"));
                WriteLine(" 1 DP                       (1)");
                WriteLine(MultiLang.StringByLang($" 2 DP (default)             (2)", $" 2 DP (padrão)              (2)"));
                for (int i=3; i<=5; i++) WriteLine($" {i} DP                       ({i})");
                WriteLine();
                WriteLine(MultiLang.MessageByLang(MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Write(MultiLang.MessageByLang(MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", MultiLang.StringByLang("preference", "preferência")));
                keyPressed=ReadKey(true).Key;
                if (keyPressed==ConsoleKey.E) goto Settings;
            } while (!sbyte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !InRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            precisionPreference=decision;
            goto ChangePrecisionPreference;
        ExitConsole: Beep();
        }
        static bool InRange(int min, int max, int i) { return i>=min && i<=max; }
        static string GetOperation(sbyte num)
        {
            switch (num)
            {
                case 1: return "+";
                case 2: return "-";
                case 3: return "x";
                case 4: return "÷";
                case 5: return "%";
            }return null; // null path
        }
        static double Calculate(double num1, string operation, double num2)
        {
            switch (operation)
            {
                case "+": return num1+num2;
                case "-": return num1-num2;
                case "x": return num1*num2;
                case "÷":
                    if (num2!=0) return num1/num2;
                    else return 0; // impossible operation
                case "%":
                    if (num2!=0) return num1%num2;
                    else return 0; // impossible operation
            }return 0; // null path
        }
    }
}//by Gui1herme#8721
