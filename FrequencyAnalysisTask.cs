using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        private static Dictionary<string, Dictionary<string, int>> nGrams = new Dictionary<string, Dictionary<string, int>>();
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            foreach (var sentences in text)
            {
                for (int i = 0; i < sentences.Count - 1; i++)
                {
                    SetBigram(sentences, i);
                    if (i < sentences.Count - 2) SetTrigram(sentences, i);
                }
            }
            return new Dictionary<string, string> { }; // не забудь еблан
        }

        private static void SetBigram(List<string> sentence, int i)
        {
            var bigram = sentence[i];
            var nextWord = sentence[i + 1];
            if (!nGrams.ContainsKey(bigram))
                nGrams[bigram] = new Dictionary<string, int>();

            if (!nGrams[bigram].ContainsKey(nextWord))
                nGrams[bigram][nextWord] = 0;

            nGrams[bigram][nextWord]++;
            
        }
        private static void SetTrigram(List<string> sentence, int i)
        {
            var trigram = sentence[i];
            var nextNextWord = sentence[i + 2];
            if (!nGrams.ContainsKey(trigram))
                nGrams[trigram] = new Dictionary<string, int>();

            if (!nGrams[trigram].ContainsKey(nextNextWord))
                nGrams[trigram][nextNextWord] = 0;

            nGrams[trigram][nextNextWord]++;
        }
    }
}