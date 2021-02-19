# Hey, I Already Did That!
# ========================

# Commander Lambda uses an automated algorithm to assign minions randomly to tasks, in order to keep minions on their toes. But you've noticed a flaw in the algorithm -- it eventually loops back on itself, so that instead of assigning new minions as it iterates, it gets stuck in a cycle of values so that the same minions end up doing the same tasks over and over again. You think proving this to Commander Lambda will help you make a case for your next promotion. 

# You have worked out that the algorithm has the following process: 

# 1) Start with a random minion ID n, which is a nonnegative integer of length k in base b
# 2) Define x and y as integers of length k.  x has the digits of n in descending order, and y has the digits of n in ascending order
# 3) Define z = x - y.  Add leading zeros to z to maintain length k if necessary
# 4) Assign n = z to get the next minion ID, and go back to step 2

# For example, given minion ID n = 1211, k = 4, b = 10, then x = 2111, y = 1112 and z = 2111 - 1112 = 0999. Then the next minion ID will be n = 0999 and the algorithm iterates again: x = 9990, y = 0999 and z = 9990 - 0999 = 8991, and so on.

# Depending on the values of n, k (derived from n), and b, at some point the algorithm reaches a cycle, such as by reaching a constant value. For example, starting with n = 210022, k = 6, b = 3, the algorithm will reach the cycle of values [210111, 122221, 102212] and it will stay in this cycle no matter how many times it continues iterating. Starting with n = 1211, the routine will reach the integer 6174, and since 7641 - 1467 is 6174, it will stay as that value no matter how many times it iterates.

# Given a minion ID as a string n representing a nonnegative integer of length k in base b, where 2 <= k <= 9 and 2 <= b <= 10, write a function solution(n, b) which returns the length of the ending cycle of the algorithm above starting with n. For instance, in the example above, solution(210022, 3) would return 3, since iterating on 102212 would return to 210111 when done in base 3. If the algorithm reaches a constant, such as 0, then the length is 1.

# Languages
# =========

# To provide a Java solution, edit Solution.java
# To provide a Python solution, edit solution.py

# Test cases
# ==========
# Your code should pass the following test cases.
# Note that it may also be run against hidden test cases not shown here.

# -- Java cases --
# Input:
# Solution.solution('210022', 3)
# Output:
#     3

# Input:
# Solution.solution('1211', 10)
# Output:
#     1

# -- Python cases --
# Input:
# solution.solution('1211', 10)
# Output:
#     1

# Input:
# solution.solution('210022', 3)
# Output:
#     3

def int_to_char_array(n, base):
    result = []
    while n >0:
        result.append(str(n % base))
        n //= base
    result.reverse()
    return result

def compute_next(n,b):
    diff =  int(''.join(sorted(n, reverse=True)), base =b) - int(''.join(sorted(n)), base =b)
    result = int_to_char_array(diff,b)
    padded_result =['0'] * (len(n) - len(result)) + result
    return ''.join(padded_result)




def solution(n, b):
    # assuming the task will always cycle (assumption to be verified analytically )
    # solution via 2 pointers (slow/fast), this is a similar problem to finding loops in list,but instead of heaving a list in memory the next element is computed
    #  https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3627/
    slow = n
    fast = compute_next(n,b)
    # find loop
    while slow != fast:
        # print('prepare',slow)
        slow = compute_next(slow,b)
        for i in range(2):
            fast = compute_next(fast,b)
    # size the loop
    result = 0
    while True:
        # print('compute',slow, fast)
        result+=1
        slow = compute_next(slow,b)
        for i in range(2):
            fast = compute_next(fast,b)
        if slow == fast:
            break
    return result

print(int_to_char_array(7,2))
print(solution('1211', 10))
print(solution('210022', 3))

