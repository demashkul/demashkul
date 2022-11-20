using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = ")(){()}{}}";
        
        Console.WriteLine(CheckParanthesis2(text));
    }


    private static bool CheckParanthesis2(string text)
    {
        Stack<char> stack = new Stack<char>();
        foreach (var item in text)
        {
            if (item == '(' || item == '{')
            {
                stack.Push(item);
            }
            else
            {
                if (stack.Count==0)
                {
                    return false;
                }
                var charr = stack.Pop();
                if (!((charr == '(' && item == ')') || (charr == '{' && item == '}')))
                    return false;

            }
        }
        return true;
    }
    private static bool CheckParanthesis(string text)
    {
        string texttoBeControlled = "";
        string textAgainst;
        int textIndex = 0;
        int startIndex = 0;
        int ptr = 0;

        while (startIndex < text.Length - 1)
        {
            if (text[textIndex] == '(' || text[textIndex] == '{')
            {
                texttoBeControlled += text[textIndex];
                textIndex++;
                ptr++;
            }
            else
            {
                textAgainst = text.Substring(textIndex, texttoBeControlled.Length);
                if (ControlParantehesis(texttoBeControlled, textAgainst))
                {
                    if (textIndex == text.Length - 1)
                    {
                        return true;
                    }
                    ptr = ptr + texttoBeControlled.Length;
                    textIndex = ptr;
                    texttoBeControlled = String.Empty;
                }
                else
                {
                    return false;
                }
            }
            startIndex++;
        }
        return false;
    }
    private static bool ControlParantehesis(string a, string b)
    {
        bool match = false;
        for (int i = 0; i < a.Length; i++)
        {
            if ((a[i] == '(' && b[a.Length - i - 1] == ')')
                || a[i] == '{' && b[a.Length - i - 1] == '}')
            {
                match = true;
            }
            else
            {
                return false;
            }

        }
        return match;
    }
}