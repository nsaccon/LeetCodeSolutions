# Definition for a binary tree node.
class TreeNode(object):
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

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
            for j in range(i+1, len(nums)):
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
    def numberOfSteps(self, num):
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
        for i in range(0, len(nums), 2):
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
            targetArray = targetArray[:index[i]] + \
                [nums[i]] + targetArray[index[i]:]
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


class Solution1486(object):
    def xorOperation(self, n, start):
        ans = 0
        for i in range(n):
            ans = ans ^ (start + 2 * i)
        return ans


class Solution938(object):
    def rangeSumBST(self, root, low, high):
        total = 0
        if(root.val >= low and root.val <= high):
            total += root.val
        if root.left is not None:
            total += self.rangeSumBST(root.left, low, high)
        if root.right is not None:
            total += self.rangeSumBST(root.right, low, high)
        return total

class Solution1614(object):
    def maxDepth(self, s):
        pars = 0
        depth = 0
        for letter in s:
            if letter == "(":
                pars += 1
            elif letter == ")":
                pars -= 1
            if pars > depth:
                depth = pars
        return depth
            
class Solution1662(object):
    def arrayStringsAreEqual(self, word1, word2):
        string1 = ""
        string2 = ""
        for i in range(len(word1)):
            string1 += word1[i]
        for x in range(len(word2)):
            string2 += word2[x]
            if(not string2 == string1[:len(string2)]):
                return False
        return string1 == string2

class OrderedStream1656(object):
    stream = []
    length = -1
    nextIndexToReturn = 0

    def __init__(self, n):
        self.stream = [""]*n
        self.length = n

    def insert(self, idKey, value):
        self.stream[idKey-1] = value
        returnStream = []
        if idKey-1 == self.nextIndexToReturn:
            indexFilledTo = self.length
            for i in range(idKey,self.length):
                if self.stream[i] == "":
                    indexFilledTo = i
                    break
            returnStream = self.stream[idKey-1:indexFilledTo]
            self.nextIndexToReturn = indexFilledTo
        return returnStream


class Solution1684(object):
    def countConsistentStrings(self, allowed, words):
        offset = 97
        canHave = [False]*26
        valid = 0
        for letter in allowed:
            canHave[ord(letter)-offset] = True
        for word in words:
            valWord = True
            for letter in word:
                if not canHave[ord(letter)-offset]:
                    valWord = False
                    break
            if valWord:
                valid += 1
        return valid

class Solution1588(object):
    def sumOddLengthSubarrays(self, arr):
        total = 0
        for i in range(1,len(arr)+1,2):
            for j in range(len(arr)-i+1):
                total += sum(arr[j:j+i])
        return total


class Solution1688(object):
    def numberOfMatches(self, n):
        count = 0
        while n > 1:
            if n % 2 != 0:
                count += (n-1) / 2
                n = ((n-1) / 2) + 1
            else:
                count += n / 2
                n = n / 2
        return count
        