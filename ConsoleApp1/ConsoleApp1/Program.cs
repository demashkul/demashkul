internal class Program
{
    private static void Main(string[] args)
    {
        string[] ss = new string[] { "5", "2", "C", "D" };
        //Calc(ss);
        string s = "12:00:00AM";
        string time = s.Substring(0, s.Length - 2);
        string hour = time.Substring(0, 2);
        int hours = int.Parse(time.Substring(0, 2)) - 12;
        Console.WriteLine(hour);
        Console.WriteLine(hours);

        string abc = "{()}(){)";
        Braces(abc);
    }

    private static bool Braces(string text)
    {
        int i = 0;
        int j = text.Length;
        string cmp1;
        string cmp2;
        int checkStartAt = 0;
        int index = 1;
        while (index < text.Length)
        {
            cmp1 = text.Substring(checkStartAt, index);
            if (checkStartAt + 2 * index > text.Length)
            {
                return false;
            }
            cmp2 = text.Substring(checkStartAt + index, index);


            if (!Check(cmp1, cmp2))
            {
                index++;
            }
            else
            {
                if (checkStartAt + 2 * index < text.Length)
                {
                    checkStartAt = checkStartAt + 2 * index;
                    index = 1;
                }
                else if (checkStartAt + 2 * index == text.Length)
                {
                    return true;
                }
            }


        }
        return false;
    }
    private static bool Check(string a, string b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            var checkresult = BraceChecker(a[i], b[a.Length - 1 - i]);
            if (!checkresult)
            {
                return false;
            }
        }
        return true;

    }
    private static bool BraceChecker(char x, char y)
    {
        if ((x == '(' && y == ')') || (x == '{' && y == '}'))
        {
            return true;
        }
        else return false;
    }
    private static int Calc(string[] ops)
    {
        List<int> result = new List<int>();
        int sum = 0;
        foreach (var item in ops)
        {
            int newPoint = 0;
            int number = 0;

            bool success = int.TryParse(item, out number);
            if (success)
            {
                newPoint = number;
                result.Add(newPoint);
            }
            else
            {
                if (item == "+")
                {
                    newPoint = result[result.Count - 1] + result[result.Count - 2];
                    result.Add(newPoint);
                }
                else if (item == "C")
                {
                    newPoint = result[result.Count - 1];
                    result.RemoveAt(result.Count - 1);
                }
                else if (item == "D")
                {
                    newPoint = result[result.Count - 1] * result[result.Count - 2];
                    result.Add(newPoint);
                }
            }
            if (item == "C")
            {
                sum -= newPoint;
            }
            else
            {
                sum += newPoint;
            }
        }
        return 0;
    }
}