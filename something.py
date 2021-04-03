class Solution1480(object):
    def runningSum(self, nums):
        newNums = []
        total = 0
        for n in nums:
            total += n
            newNums.append(total)
        return newNums


class Solution1108(object):
    def defangIPaddr(self, address):
        newStr = ""
        for x in address:
            if x == ".":
                newStr += "[.]"
            else:
                newStr += x
        return newStr


        