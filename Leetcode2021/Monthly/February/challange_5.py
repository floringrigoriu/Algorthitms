# Doomsday Fuel
# =============

# Making fuel for the LAMBCHOP's reactor core is a tricky process because of the exotic matter involved. 
# It starts as raw ore, then during processing, 
# begins randomly changing between forms, 
# eventually reaching a stable form.
#  There may be multiple stable forms that a sample could ultimately reach, not all of which are useful as fuel. 

# Commander Lambda has tasked you to help the scientists increase fuel creation efficiency by predicting the end state of a given ore sample.
#  You have carefully studied the different structures that the ore can take and which transitions it undergoes. 
# It appears that, while random, the probability of each structure transforming is fixed. 
# That is, each time the ore is in 1 state, it has the same probabilities of entering the next state (which might be the same state). 
#  You have recorded the observed transitions in a matrix. The others in the lab have hypothesized more exotic forms that the ore can become, 
# but you haven't seen all of them.

# Write a function solution(m) that takes an array of array of nonnegative ints representing 
# how many times that state has gone to the next state and return an array of ints for each terminal state giving the exact probabilities of each terminal state,
#  represented as the numerator for each state, then the denominator for all of them at the end and in simplest form. 
# The matrix is at most 10 by 10. It is guaranteed that no matter which state the ore is in, there is a path from that state to a terminal state.
#  That is, the processing will always eventually end in a stable state. The ore starts in state 0. 
# The denominator will fit within a signed 32-bit integer during the calculation, as long as the fraction is simplified regularly. 

# For example, consider the matrix m:
# [
#   [0,1,0,0,0,1],  # s0, the initial state, goes to s1 and s5 with equal probability
#   [4,0,0,3,2,0],  # s1 can become s0, s3, or s4, but with different probabilities
#   [0,0,0,0,0,0],  # s2 is terminal, and unreachable (never observed in practice)
#   [0,0,0,0,0,0],  # s3 is terminal
#   [0,0,0,0,0,0],  # s4 is terminal
#   [0,0,0,0,0,0],  # s5 is terminal
# ]
# So, we can consider different paths to terminal states, such as:
# s0 -> s1 -> s3
# s0 -> s1 -> s0 -> s1 -> s0 -> s1 -> s4
# s0 -> s1 -> s0 -> s5
# Paths :
# s0 -> s5  [1/2]                -> 9/18
# s0 -> s1 -> s3 [3/18 = 1/6]    -> 3/18
# s0 -> S1 -> s4 [2/18 = 1/9]    -> 2/18
# ======================================
# total                            14/18 

### initial s0 = 1
### Final s2+s3+s4+s5 =1
#    s2  =0
# s3 *2 = s4*3
# s0 = s1 + s5
# S1  = s5 
# S1 = 4/9 s0 + 3/9 s3 + 2/9 S4 
# Tracing the probabilities of each, we find that
# s2 has probability 0
# s3 has probability 3/14
# s4 has probability 1/7
# s5 has probability 9/14
# So, putting that together, and making a common denominator, gives an answer in the form of
# [s2.numerator, s3.numerator, s4.numerator, s5.numerator, denominator] which is
# [0, 3, 2, 9, 14].

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
# Solution.solution({{0, 2, 1, 0, 0}, {0, 0, 0, 3, 4}, {0, 0, 0, 0, 0}, {0, 0, 0, 0,0}, {0, 0, 0, 0, 0}})
# Output:
#     [7, 6, 8, 21]
# s0 -> S1 ->s3  = 2/3* 3/7 = 2/7  = 6/21
# s0 -> s1-> s4 = 2/3 * 4/7 = 8/21
# s0 -> s2  = 1/3 =7/21
# [7, 6,8, 21]



# Input:
# Solution.solution({{0, 2, 1, 0, 0}, {0, 1, 0, 3, 4}, {0, 0, 0, 0, 0}, {0, 0, 0, 0,0}, {0, 0, 0, 0, 0}})


# Input:
# Solution.solution({{0, 1, 0, 0, 0, 1}, {4, 0, 0, 3, 2, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}})
# Output:
#     [0, 3, 2, 9, 14]

# -- Python cases --
# Input:
# solution.solution([[0, 2, 1, 0, 0], [0, 0, 0, 3, 4], [0, 0, 0, 0, 0], [0, 0, 0, 0,0], [0, 0, 0, 0, 0]])
# Output:
#     [7, 6, 8, 21]

# Input:
# solution.solution([[0, 1, 0, 0, 0, 1], [4, 0, 0, 3, 2, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0]])
# Output:
#     [0, 3, 2, 9, 14]

# Use verify [file] to test your solution and see how it does. When you are finished editing your code, use submit [file] to submit your answer. If your solution passes the test cases, it will be removed from your home folder.

# perform matrics inversion
from fractions import Fraction 
import math

def zeros(rows):
    A = []
    for i in range(rows):
        A.append([])
        for j in range(rows):
            A[-1].append(Fraction(0))

    return A

def ones(rows):
    o = zeros(rows)
    for i in range(rows):
        o[i][i]= Fraction(1)
    return o

def diff(a,b):
    result = zeros(len(a))
    for i in range(len(a)):
        for j in range(len(a)):
            result[i][j] = a[i][j]-b[i][j]
    return result

def normalize(m):
    result = []
    for row in m :
        s = max(sum(row),1) # 0/0 div error
        result.append(list(map(lambda r : Fraction(r,s), row)))
    return result

def inv(m):
    n = len(m)
    result = ones(n)
    indices = list(range(n)) # to allow flexible row referencing ***
    for fd in range(n): # fd stands for focus diagonal
        fdScaler = Fraction(1) / m[fd][fd]
        # FIRST: scale fd row with fd inverse. 
        for j in range(n): # Use j to indicate column looping.
            m[fd][j] *= fdScaler
            result[fd][j] *= fdScaler
        # SECOND: operate on all rows except fd row as follows:
        for i in indices[0:fd] + indices[fd+1:]: 
            # *** skip row with fd in it.
            crScaler = m[i][fd] # cr stands for "current row".
            for j in range(n): 
                # cr - crScaler * fdRow, but one element at a time.
                m[i][j] = m[i][j] - crScaler * m[fd][j]
                result[i][j] = result[i][j] - crScaler * result[fd][j]
    return result

def solution(m):
    # at the begining the system is in State 0, so state probability will be 
    # S_time_0 = [1  0  0 .... 0] 
    # we can consider normalized version of transtition matrix M` such sum(each row M) ==1
    # after first transition
    # S_time_1 = S_time_0 * M'   
    #
    # after second  transition
    # S_time_2 = S_time_1 * M' =  S_time_0 * (M')^2
    #  
    # after third  transition
    # S_time_3 = S_time_2 * M' =  S_time_0 * (M')^3
    #  
    # This system will stabilize continuing to infinity in 
    # S_final = S_time_0 *(M')^infinity
    # probablility of final state will sum(1)
    #
    # sums(s_time_0: s_final) = s_time_0 * ( 1 + M' + M'^2+ M'^3 ...) =
    #  =s_time_0 * ( I - M')^(-1)

    # 
    # not to use numpy use use inverse matrix from : https://integratedmlai.com/matrixinverse/

    m = normalize(m)
    #print(m)
    I = ones(len(m))
    #print(I)
    i_m = diff(I,m)
    #print (i_m)
    inv_m = inv(i_m)
    #print(inv_m)
    
    final_states_probability = []
    for i in range(len(m)):
        row = m[i]
        if sum(row) == 0:
            final_states_probability.append(inv_m[0][i])
    #print(final_states_probability)
    common_multiple = 1
    for f in final_states_probability:
        if f:
            other = f.denominator
            common_multiple =common_multiple*other // math.gcd(common_multiple, other)
    #print(common_multiple)
    result = []
    for f  in final_states_probability:
        if f:
            result.append(f.numerator * common_multiple // f.denominator)
        else :
            result.append(0)
    result.append(common_multiple)
    return result

probabilities = [[0, 1, 0, 0, 0, 1], [4, 0, 0, 3, 2, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0]]
result = solution(probabilities)
print(result)

print(solution([[0, 2, 1, 0, 0], [0, 0, 0, 3, 4], [0, 0, 0, 0, 0], [0, 0, 0, 0,0], [0, 0, 0, 0, 0]]))