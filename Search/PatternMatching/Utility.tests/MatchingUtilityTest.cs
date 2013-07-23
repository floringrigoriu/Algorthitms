using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Utility.tests
{
    [TestClass]
    public class MatchingUtilityTest
    {
        Dictionary<String, String> matching = new Dictionary<string, string>()
        {
            {"* is *", "falling is learning"},
            {"i*", "iFone"},
            {"i *", "I am free"},
            {"To * is like having a * for breakfast", 
             "To pickle is like having a glass of vinegar for breakfast"}
        };

        Dictionary<String, String> notMatching = new Dictionary<string, string>()
        {
            {"* is  *", "falling is learning"},
            {"i*", " iFone"},
            {"i *", "I'm free"},
            {"To * is like having a * for breakfast", "To pickle is like having a glass of vinegar for breakfast and lunch"}
        };

        Dictionary<String, Token[]> tokensDictionary = new Dictionary<string, Token[]>()
        {
            {"* is *", new Token[] {new Token(" is ")}},
            {"i*", new Token[] {new Token("i",true)}},
            {"i *", new Token[] {new Token("i ",true)}},
            {"To * is like having a * for breakfast", new Token[] 
                {new Token("To ",true), new Token(" is like having a "),new Token(" for breakfast",false,true)}}
        };

        MatchingUtility utility = new MatchingUtility();

        [TestMethod]
        public void TokenizeTest()
        {
            foreach (var kvp in this.tokensDictionary)
            { 
                // trigger
                var computedTokens = this.utility.Tokanize(kvp.Key);

                // validate
                Assert.IsTrue(computedTokens.SequenceEqual(kvp.Value),
                    "Unexpected tokanization. discovered {1} {0} {1} while expedted{1} {2}",
                    String.Concat(computedTokens.Select(c => c.ToString())),
                    Environment.NewLine,
                    String.Concat(kvp.Value.Select(c => c.ToString()))
                    );
            }
        }

        [TestMethod]
        public void MatchTest()
        {
            foreach (var kvp in this.matching)
            {
                // trigger
                var areMatching = this.utility.Matches(kvp.Key,kvp.Value);

                // validate
                Assert.IsTrue(areMatching, "Expected '{0}' to match template '{1}'",kvp.Value , kvp.Key);
            }

            foreach (var kvp in this.notMatching)
            {
                // trigger
                var areMatching = this.utility.Matches(kvp.Key, kvp.Value);

                // validate
                Assert.IsFalse(areMatching, "Expected '{0}' not to match template '{1}'", kvp.Value, kvp.Key);
            }
        }

        [TestMethod]
        public void PerformanceTest()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // test 10 million matches 1250000 * 8
            for (int iteration = 0; iteration < 1250000; iteration++)
            {
                foreach (var kvp in this.matching)
                {
                    // trigger
                    var areMatching = this.utility.Matches(kvp.Key, kvp.Value);
                }

                foreach (var kvp in this.notMatching)
                {
                    // trigger
                    var areMatching = this.utility.Matches(kvp.Key, kvp.Value);
                }
            }
            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < 1000, "Time : {0}", watch.Elapsed.ToString());
        }

    }
}
