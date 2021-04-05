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


class Solution1470(object):
    def shuffle(self, nums, n):
        numLst = []
        for i in range(n):
            numLst.append(nums[i])
            numLst.append(nums[i+n])
        return numLst
        
class Solution1431(object):
    def kidsWithCandies(self, candies, extraCandies):
        ans = []
        most = max(candies)
        for kid in candies:
            ans.append((kid + extraCandies) >= most)
        return ans

class Solution1672(object):
    def maximumWealth(self, accounts):
        most = 0
        for customer in accounts:
            total = 0
            for balance in customer:
                total += balance
            if total > most:
                most = total
        return most


class Solution1512(object):
    def numIdenticalPairs(self, nums):
        count = 0
        for i in range(len(nums)):
            for j in range(i+1,len(nums)):
                if(nums[i] == nums[j]):
                    count += 1
        return count


class Solution771(object):
    def numJewelsInStones(self, jewels, stones):
        count = 0
        for stone in stones:
            if stone in jewels:
                count += 1
        return count

class ParkingSystem1603(object):
    _big = 0
    _med = 0
    _small = 0

    def __init__(self, big, medium, small):
        self._big = big
        self._med = medium
        self._small = small
        

    def addCar(self, carType):
        if carType == 1 and self._big > 0:
            self._big -= 1
            return True
        elif carType == 2 and self._med > 0:
            self._med -= 1
            return True
        elif carType == 3 and self._small > 0:
            self._small -= 1
            return True
        return False

class Solution1365(object):
    def smallerNumbersThanCurrent(self, nums):
        ans = []
        rng = range(len(nums))
        for num in nums:
            more = 0
            for i in rng:
                if num > nums[i]:
                    more += 1
            ans.append(more)
        return ans

class Solution1342(object):
    def numberOfSteps (self, num):
        curr = num
        step = 0
        while curr > 0:
            if curr == 1:
                curr -= 1
                step += 1
            elif curr % 2 != 0:
                curr -= 1
                step += 1
            else:
                curr /= 2
                step += 1
        return step

class Solution1528(object):
    def restoreString(self, s, indices):
        length = len(indices)
        newStr = [" "] * length
        ans = ""
        for i in range(length):
            newStr[indices[i]] = s[i]
        
        for x in newStr:
            ans += x
        return ans
        
class Solution1281(object):
    def subtractProductAndSum(self, n):
        numStrLst = list(str(n))
        prod = 1
        sum = 0
        for i in numStrLst:
            num = int(i)
            prod *= num
            sum += num
        return prod - sum

class Solution1313(object):
    def decompressRLElist(self, nums):
        intLst = []
        for i in range(0,len(nums),2):
            intLst += [nums[i+1]]*nums[i]
        return intLst


class Solution1773(object):
    def countMatches(self, items, ruleKey, ruleValue):
        count = 0
        rules = ["type", "color", "name"]
        ruleIndex = rules.index(ruleKey)
        for item in items:
            if item[ruleIndex] == ruleValue:
                count += 1
        return count

class Solution1678(object):
    def interpret(self, command):
        ans = ""
        i = 0
        while i < len(command):
            if command[i] == "G":
                ans += "G"
                i += 1
            elif command[i+1] == ")":
                ans += "o"
                i += 2
            else:
                ans += "al"
                i += 4
        return ans


class Solution1720(object):
    def decode(self, encoded, first):
        decoded = [first]
        index = 0
        for num in encoded:
            decoded += (decoded[index] ^ num)
            index += 1
        return decoded


class Solution1389(object):
    def createTargetArray(self, nums, index):
        targetArray = []
        for i in range(len(nums)):
            targetArray = targetArray[:index[i]] + [nums[i]] + targetArray[index[i]:]
        return targetArray
        

class Solution1221(object):
    def balancedStringSplit(self, s):
        found = 0
        offset = 0
        for letter in s:
            if letter == "R":
                offset += 1
            else:
                offset -= 1
            if(not offset):
                found += 1
        return found