using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Micro.Q1
{

    public class Counters
    {
        public int Original { get; set; }
        public int Current { get; set; }
        public Counters(int original, int current)
        {
            Original = original;
            Current = current;
        }
    }

    [TestClass]
    public class MicrosoftQ
    {
        [TestMethod]
        public void Scenario_1()
        {
            Assert.AreEqual(2, CountMatches("aa", "aaa"));
        }

        [TestMethod]
        public void Scenario_2()
        {
            Assert.AreEqual(2, CountMatches("ab", "abba"));
        }

        [TestMethod]
        public void Scenario_3()
        {
            Assert.AreEqual(5, CountMatches("ab", "ababab"));//3 +2
        }

        [TestMethod]
        public void Scenario_4()
        {
            Assert.AreEqual(0, CountMatches("ab", "oo"));
        }

        [TestMethod]
        public void Scenario_5()
        {
            Assert.AreEqual(3, CountMatches("a", "dasdasdasd"));
        }

        [TestMethod]
        public void Scenario_6()
        {
            Assert.AreEqual(3, CountMatches("abc", "abccbaabc"));//2
        }



        private int CountMatches(string pattern, string text)
        {
            Dictionary<char, Counters> dic = FillDictionary(pattern);
            int matchesCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char charecter = text[i];
                if (dic.ContainsKey(charecter))
                {
                    if (IsMatches(text, dic, i, pattern.Length))
                    {
                        matchesCount++;
                    }
                }
            }
            return matchesCount;

        }

        private bool IsMatches(string text, Dictionary<char, Counters> dic, int indexInText, int patternLength)
        {
            int charsNotMatched = patternLength;
            if (text.Length - indexInText < patternLength)
            {
                return false;
            }

            //zeroing counter..
            foreach (var key in dic.Keys)
            {
                dic[key].Current = dic[key].Original;
            }


            for (int i = indexInText; i < indexInText + patternLength; i++)
            {
                char charecter = text[i];
                if (dic.ContainsKey(charecter))
                {
                    dic[charecter] = new Counters(dic[charecter].Original, dic[charecter].Current - 1);
                    if (dic[charecter].Current < 0)
                    {
                        return false;
                    }
                    charsNotMatched--;

                }
            }
            return charsNotMatched == 0;
        }

        private Dictionary<char, Counters> FillDictionary(string pattern)
        {
            Dictionary<char, Counters> dic = new Dictionary<char, Counters>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dic.ContainsKey(pattern[i]))
                {
                    dic[pattern[i]] = new Counters(1, 1);
                }
                else
                {
                    dic[pattern[i]] = new Counters(dic[pattern[i]].Original + 1, dic[pattern[i]].Original + 1);
                }
            }
            return dic;
        }
    }
}
