using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class EmailExtractor
{
    public List<string> ExtractEmails(string input)
    {
        var emails = new List<string>();
        var matches = Regex.Matches(input, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}");
        foreach (Match match in matches)
        {
            emails.Add(match.Value.ToLower());
        }
        return emails;
    }
}

class Program
{
    static void Main()
    {
        string text = "Contact Info@Example.com and Support@Example.org";
        var extractor = new EmailExtractor();
        var emails = extractor.ExtractEmails(text);
        emails.ForEach(Console.WriteLine);
    }
}
