using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TextAnalysis;

// Особенности: если phraseBeginning больше одного слова, то нужно взять 2 последних слова phraseBeginning и использовать их в качестве ключа для поиска в nextWords
// if (nextWords.ContainsKey(phraseBeginning))
// Если такого ключа нет, то мы ищем по последнему слову phraseBeginning, если false, то возвращаем то что есть
// 1. Посчитать сколько слов в предложении 2. Получить нужное количество слов 3.Ищем ключ для продолжения фразы 4. Формируем предложение циклом
static class TextGeneratorTask // задумка такая есть цикл, его итерации зависят от wordsCount, где наверное StringBuilderom будем формировать строку каждый раз обращаясь к nextWords
{
    public static string ContinuePhrase(
        Dictionary<string, string> nextWords, //словарь
        string phraseBeginning, // несколько первых слов фразы от user'a
        int wordsCount) //количество слов, которые нужно дописать к phraseBeginning
    {
        var wordsInPhrase = phraseBeginning.Split(' ');
        if (wordsInPhrase.Count() >= 1) phraseBeginning = findNextWord(nextWords, wordsCount, wordsInPhrase); // вызов findNextWord ДОБАВЬ
        return phraseBeginning;
    }

    private static string findNextWord(
        Dictionary<string, string> nextWords,
        int wordsCount,
        string[] wordsInPhrase)
    {
        var result = new List<string>(wordsInPhrase); 
        for (int i = 0; i < wordsCount; i++) 
        {
            if(result.Count >= 2) result = findTrigramm(result, nextWords, wordsInPhrase.Count() + wordsCount);
            result = findBigramm(result, nextWords, wordsInPhrase.Count() + wordsCount);
            if(result.Count == wordsInPhrase.Count() + wordsCount) break;
        }
        string phraseBeginning = "";
        foreach (var text in result) phraseBeginning += " " + text;
        return phraseBeginning.Trim();
    }

    private static List<string> findTrigramm(List<string> result, Dictionary<string,string> nextWords, int phraseWordsSummCount)
    {
        string triGrammStr = "";
        do
        {
            var triGrammArr = result.TakeLast(2).ToArray();
            triGrammStr = triGrammArr[0] + " " + triGrammArr[1]; // это старт для цикла, первый ключ для поиска триграммы
            if (nextWords.ContainsKey(triGrammStr))
            {
                result.Add(nextWords[triGrammStr]);
                triGrammArr = result.TakeLast(2).ToArray();
                triGrammStr = triGrammArr[0] + " " + triGrammArr[1];
            }
        }
        while (nextWords.ContainsKey(triGrammStr) && result.Count + 1 <= phraseWordsSummCount);
        return result;
    }
    private static List<string> findBigramm(List<string> result, Dictionary<string, string> nextWords, int phraseWordsSummCount)
    {
        if (nextWords.ContainsKey(result.Last()) && result.Count + 1 <= phraseWordsSummCount) // поиск биграммы
            result.Add(nextWords[result.Last()]);
        return result;
    }

}