namespace TextAnalysis;

static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        char[] sentencesSeparators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
        var sentencesList = new List<List<string>>();
        foreach (var sentence in text.Split(sentencesSeparators))
        {
            var words = SplitSentenceIntoWords(sentence);
            if (words.Count > 0) sentencesList.Add(words);
        }
        return sentencesList;
    }

    public static List<string> SplitSentenceIntoWords(string sentence)
    {
        var words = new List<string>();
        var word = "";

        foreach (var ch in sentence)
        {
            if (char.IsLetter(ch) || ch == '\'')
            {
                word += ch;
            }
            else if (word.Length > 0)
            {
                words.Add(word.ToLower());
                word = "";
            }
        }

        if (word.Length > 0)
        {
            words.Add(word.ToLower());
        }

        return words;
    }
}