using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class MatchingUtility
    {
        /// <summary>
        /// comparison between strings
        /// </summary>
        private StringComparison comparison;

        private Dictionary<string, List<Token>> cachedTokens = new Dictionary<string, List<Token>>();

        /// <summary>
        /// Build a custom comparer utility
        /// </summary>
        /// <param name="comparer">comparison provider</param>
        public MatchingUtility(StringComparison comparer = StringComparison.InvariantCultureIgnoreCase)
        {
            this.comparison = comparer;
        }

        public bool Matches(String pattern, String input)
        {
            Contract.Assert(pattern != null);
            Contract.Assert(input != null);
            // 1. Tokenize
            // 2. Matches

            int start = 0;

            foreach (var token in Tokanize(pattern))
            {
                int firstOccurence = input.IndexOf(token.TokenValue, start, this.comparison);
                if (firstOccurence == -1  || // not found
                    (token.IsStarting &&  firstOccurence != 0) ||  // not at beging for search
                    (token.IsEnding &&  firstOccurence  +  token.TokenValue.Length != input.Length ))  // not at end for search
                {
                    return false;
                }

                // prepare next search;
                start = firstOccurence + token.TokenValue.Length;
            }

            return true;
        }

        public IEnumerable<Token> Tokanize(String pattern)
        {
            Contract.Assert(pattern != null);
            if (this.cachedTokens.ContainsKey(pattern))
            {
                foreach (var token in this.cachedTokens[pattern])
                {
                    yield return token;
                }
                yield break;
            }
            else
            {


                List<Token> currentResult = new List<Token>();


                int start = 0;
                for (int end = 0; end < pattern.Length; end++)
                {
                    if (pattern[end] == '*')
                    {
                        if (end > 0)
                        {
                            var token = new Token(pattern.Substring(start, end - start), start == 0);
                            yield return token;
                            currentResult.Add(token);
                        }
                        start = end + 1;
                    }
                }
                if (pattern[pattern.Length - 1] != '*')
                {
                    var token = new Token(pattern.Substring(start), start == 0, true);
                    yield return token;
                    currentResult.Add(token);
                }
                this.cachedTokens[pattern] = currentResult;
            }
        }
    }

    public class Token
    {
        public Token(String value, bool isStarting = false, bool isEnding = false)
        {
            this.TokenValue = value;
            this.IsStarting = isStarting;
            this.IsEnding = isEnding;
        }

        public bool IsStarting { get; private set; }
        public bool IsEnding { get; private set; }
        public String TokenValue { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}",
                this.IsStarting ? "[" : "-",
                this.TokenValue,
                this.IsEnding ? "]" : "-");
        }

        public override bool Equals(object obj)
        {
            var other = obj as Token;
            if (null == other)
            {
                return false;
            }
            else 
            {
                return
                    this.IsStarting == other.IsStarting &
                    this.IsEnding == other.IsEnding &
                    String.Equals(this.TokenValue, other.TokenValue);
            }
        }
    }
}
