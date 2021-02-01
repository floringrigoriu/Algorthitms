# https://foobar.withgoogle.com/

# Braille is a writing system used to read by touch instead of by sight. Each character is composed of 6 dots in a 2x3 grid, where each dot can either be a bump or be flat (no bump). You plan to translate the signs around the space station to Braille so that the minions under Commander Lambda's command can feel the bumps on the signs and "read" the text with their touch. The special printer which can print the bumps onto the signs expects the dots in the following order:
# 1 4
# 2 5
# 3 6

# So given the plain text word "code", you get the Braille dots:

# 11 10 11 10
# 00 01 01 01
# 00 10 00 00

# where 1 represents a bump and 0 represents no bump.  Put together, "code" becomes the output string "100100101010100110100010".

# Write a function solution(plaintext) that takes a string parameter and returns a string of 1's and 0's representing the bumps and absence of bumps in the input string. Your function should be able to encode the 26 lowercase letters, handle capital letters by adding a Braille capitalization mark before that character, and use a blank character (000000) for spaces. All signs on the space station are less than fifty characters long and use only letters and spaces.

# Languages
# =========

# To provide a Python solution, edit solution.py
# To provide a Java solution, edit Solution.java

# Test cases
# ==========
# Your code should pass the following test cases.
# Note that it may also be run against hidden test cases not shown here.

# -- Python cases --
# Input:
# solution.solution("code")
# Output:
#     100100101010100110100010

# Input:
# solution.solution("Braille")
# Output:
#     000001110000111010100000010100111000111000100010

# Input:
# solution.solution("The quick brown fox jumps over the lazy dog")
# Output:
#     000001011110110010100010000000111110101001010100100100101000000000110000111010101010010111101110000000110100101010101101000000010110101001101100111100011100000000101010111001100010111010000000011110110010100010000000111000100000101011101111000000100110101010110110
#     000001011110110010100010000000111100101001010100100100101000000000110000111010101010010111101110000000110100101010101101000000010110101001101100111100011100000000101010111001100010111010000000011110110010100010000000111000100000101011101111000000100110101010110110  

# -- Java cases --
# Input:
# Solution.solution("code")
# Output:
#     100100101010100110100010

# Input:
# Solution.solution("Braille")
# Output:
#     000001110000111010100000010100111000111000100010

# Input:
# Solution.solution("The quick brown fox jumps over the lazy dog")
# Output:
#     000001011110110010100010000000111110101001010100100100101000000000110000111010101010010111101110000000110100101010101101000000010110101001101100111100011100000000101010111001100010111010000000011110110010100010000000111000100000101011101111000000100110101010110110

# Use verify [file] to test your solution and see how it does. When you are finished editing your code, use submit [file] to submit your answer. If your solution passes the test cases, it will be removed from your home folder.






def solution(s):
    # Your code here
    # wow ! so cool coding challenge, way more fun than leetcode or Project Euler
    braille_mapping = {
        'a': '100000',
        'b': '110000',
        'c': '100100',
        'd': '100110',
        'e': '100010',
        'f': '110100',
        'g': '110110',
        'h': '110010',
        'i': '010100',
        'j': '010110',
        'k': '101000',
        'l': '111000',
        'm': '101100',
        'n': '101110',
        'o': '101010',
        'p': '111100',
        'q': '111110',
        'r': '111010',
        's': '011100',
        't': '011110',
        'u': '101001',
        'v': '111001',
        'x': '101101',
        'y': '101111',
        'z': '101011',
        'w': '010111',
        ' ': '000000'
    }
    result = []
    for c in s:
        if c == ' ':
            result.append(braille_mapping[' '])
        elif c > 'z' or not c.isalpha():
            raise Exception('not supported transalation for char : '+ c)
        elif c.isupper():
            result.extend(['000001', braille_mapping[c.lower()]])
        else:
            result.append(braille_mapping[c])
    return ''.join(result)

print(solution("code"))
print(solution("Braille"))
print(solution("The quick brown fox jumps over the lazy dog"))
    