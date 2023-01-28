namespace RegExMatching;
public class RegExMatching
{
    public bool IsMatch(string s, string p)
    {

        if (p == ".*")
        {
            return true;
        }

        List<string> patterns = new List<string>();
        string placehold = s;

        for (int i = 0; i <= p.Length - 1; i++)
        {
            if (p[i] == '*')
            {
                string slice = p.Substring(i - 1, 2);
                patterns.RemoveAt(patterns.Count - 1);
                patterns.Add(slice);
            }
            else
            {
                patterns.Add(p[i].ToString());
            }
        }

        for (int i = 0; i <= patterns.Count - 1; i++)
        {
            Console.WriteLine($"Current: {patterns[i]}, S: {s}");

            if (s == "" && patterns.Contains((patterns[i] + '*').ToString()) && patterns[i] != ".")
            {
                return true;
            }
            else if (s == "" && patterns[i].Length == 2)
            {
                continue;
            }
            else if (s == "")
            {
                return false;
            }

            if (patterns[i] == s[0].ToString())
            {
                s = s.Remove(0, 1);
            }
            else if (patterns[i].Length == 2)
            {
                int index = 0;
                if (patterns[i][0] != '.')
                {
                    while (patterns[i][0] == s[index])
                    {
                        index++;
                        if (index >= s.Length)
                        {
                            break;
                        }
                    }
                    s = s.Remove(0, index);
                    Console.WriteLine($"Index after while loop: {index}, and heres S: {s}");
                }
                else
                {

                    int charCount = 0;
                    foreach (string pattern in patterns)
                    {
                        Console.WriteLine($"CURRENT PATTERN: {pattern}");
                        if (pattern == ".*")
                        {
                            continue;
                        }
                        else if (pattern.Length == 2)
                        {
                            continue;
                        }
                        else if (pattern == ".")
                        {
                            charCount += 1;
                        }
                        else if (placehold.Contains(pattern))
                        {
                            charCount += 1;
                        }

                    }
                    Console.WriteLine($"Char Count: {charCount}, Placehold Length: {placehold.Length}");
                    if (charCount == placehold.Length)
                    {
                        return true;
                    }
                    s = "";
                }
            }
            else if (patterns[i] == ".")
            {
                s = s.Remove(0, 1);
            }
        }

        Console.WriteLine($"DONE!! Here's finished S: {s}");

        if (s != "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
