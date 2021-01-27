class Solution:
    def maximumTime(self, time: str) -> str:
        result = ''
        for i in range(5):
            if time[i] == '?':
                if i == 0:
                    result = result + '2'
                elif i ==1 :
                    if result[0] == '2':
                        result = result + '3'
                    else:
                        result = result + '9'
                elif i == 3:
                    result = result + '5'
                elif i == 2:
                    result = result + ':'
                else:
                    result = result + '9'
            else :
                result = result + time[i]
                    
        return result

s = Solution()
print(s.maximumTime("2?:?0"))
print(s.maximumTime("0?:3?"))
print(s.maximumTime("1?:22"))