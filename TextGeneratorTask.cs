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
        return phraseBeginning;
    }
}