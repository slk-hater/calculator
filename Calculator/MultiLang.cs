namespace Calculator
{
    public class MultiLang
    {
        public static string StringByLang(string en, string pt)
        {
            if (Program.language == "en-US") return en;
            else if (Program.language == "pt-PT") return pt;
            return null;
        }
        public static string MessageByLang(MessagesEnum msg)
        {
            if (Program.language == "en-US") //case Language is English
            {
                switch (msg)
                {
                    case MessagesEnum.CONSOLE_TITLE: return "Standard calculator - Guilherme Fadário";
                    case MessagesEnum.MAIN_MENU: return "Calculator - Main menu";
                    case MessagesEnum.ADD: return " Add                   +    (1)";
                    case MessagesEnum.SUBTRACT: return " Subtract              -    (2)";
                    case MessagesEnum.MULTIPLY: return " Multiply              x    (3)";
                    case MessagesEnum.DIVIDE: return " Divide                ÷    (4)";
                    case MessagesEnum.REST_OF_DIVISION: return " Remainder             %    (5)";
                    case MessagesEnum.SETTINGS: return "Settings                    (S)";
                    case MessagesEnum.SETTINGS_MENU: return "Calculator - Settings menu";
                    case MessagesEnum.CHANGE_LANGUAGE: return " Language                   (L)";
                    case MessagesEnum.LANGUAGE_MENU: return "Calculator - Languages menu";
                    case MessagesEnum.CHANGE_COLOR: return " Console color              (C)";
                    case MessagesEnum.COLORS_MENU: return "Calculator - Colors menu";
                    case MessagesEnum.DECIMAL_PLACES_PREFERENCE: return " Decimal places preference  (D)";
                    case MessagesEnum.DECIMAL_PLACES_PREFERENCE_MENU: return "Calculator - Decimal places menu";
                    case MessagesEnum.CLEAR_RESULT: return "Clear the result            (C)";
                    case MessagesEnum.RESTART_CONSOLE: return "Restart the console         (R)";
                    case MessagesEnum.EXIT_CONSOLE: return "Exit the console            (E)";
                    case MessagesEnum.EXIT_THIS_MENU: return "Exit this menu              (E)";
                    case MessagesEnum.ASK_FOR_KEY: return "Press a key[@keys] to choose a @type: ";
                }
            }
            else if (Program.language == "pt-PT") //case Language is Portuguese
            {
                switch (msg)
                {
                    case MessagesEnum.CONSOLE_TITLE: return "Calculadora padrão - Guilherme Fadário";
                    case MessagesEnum.MAIN_MENU: return "Calculadora - Menu principal";
                    case MessagesEnum.ADD: return " Adicionar             +    (1)";
                    case MessagesEnum.SUBTRACT: return " Subtrair              -    (2)";
                    case MessagesEnum.MULTIPLY: return " Multiplicar           x    (3)";
                    case MessagesEnum.DIVIDE: return " Dividir               ÷    (4)";
                    case MessagesEnum.REST_OF_DIVISION: return " Resto de divisão      %    (5)";
                    case MessagesEnum.SETTINGS: return "Definições                  (S)";
                    case MessagesEnum.SETTINGS_MENU: return "Calculadora - Menu de definições";
                    case MessagesEnum.CHANGE_LANGUAGE: return " Linguagem                  (L)";
                    case MessagesEnum.LANGUAGE_MENU: return "Calculadora - Menu de linguagens";
                    case MessagesEnum.CHANGE_COLOR: return " Cor da consola             (C)";
                    case MessagesEnum.COLORS_MENU: return "Calculadora - Menu de cores";
                    case MessagesEnum.DECIMAL_PLACES_PREFERENCE: return " Preferência casas decimais (D)";
                    case MessagesEnum.DECIMAL_PLACES_PREFERENCE_MENU: return "Calculadora - Menu de casas decimais";
                    case MessagesEnum.CLEAR_RESULT: return "Limpar o resultado          (C)";
                    case MessagesEnum.RESTART_CONSOLE: return "Reiniciar a consola         (R)";
                    case MessagesEnum.EXIT_CONSOLE: return "Sair da consola             (E)";
                    case MessagesEnum.EXIT_THIS_MENU: return "Sair deste menu             (E)";
                    case MessagesEnum.ASK_FOR_KEY: return "Pressione uma tecla[@keys] para escolher uma @type: ";
                }
            }
            return null;
        }
        public enum MessagesEnum //list of message types available
        {
            CONSOLE_TITLE,
            MAIN_MENU,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE,
            REST_OF_DIVISION,
            SETTINGS,
            SETTINGS_MENU,
            CHANGE_LANGUAGE,
            LANGUAGE_MENU,
            CHANGE_COLOR,
            COLORS_MENU,
            DECIMAL_PLACES_PREFERENCE,
            DECIMAL_PLACES_PREFERENCE_MENU,
            CLEAR_RESULT,
            RESTART_CONSOLE,
            EXIT_CONSOLE,
            EXIT_THIS_MENU,
            ASK_FOR_KEY
        }
    }
}
