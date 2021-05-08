using Microsoft.TeamFoundation.Common.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Solution1480
        {
            public int[] RunningSum(int[] nums)
            {
                int sumSoFar = 0;
                int[] result = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    result[i] = nums[i] + sumSoFar;
                    sumSoFar += nums[i];
                }
                return result;
            }
        }

        public class Solution1470
        {
            public int[] Shuffle(int[] nums, int n)
            {
                int[] result = new int[2 * n];

                int putIndexFront = 0;
                int putIndexBack = 1;
                for (int i = 0; i < 2 * n; i++)
                {
                    if(i < n)
                    {
                        result[putIndexFront] = nums[i];
                        putIndexFront += 2;
                    }
                    else
                    {
                        result[putIndexBack] = nums[i];
                        putIndexBack += 2;
                    }
                }
                return result;
            }
        }

        public class Solution1431
        {
            public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
            {
                List<bool> canHaveMost;
                int maxInList = 0;
                int minInList = int.MaxValue;
                for (int i = 0; i < candies.Length; i++)
                {
                    if (candies[i] > maxInList)
                    {
                        maxInList = candies[i];
                    }
                    if (candies[i] < minInList)
                    {
                        minInList = candies[i];
                    }
                }

                if (extraCandies + minInList > maxInList)
                {
                    canHaveMost = Enumerable.Repeat(true, candies.Length).ToList();
                }
                else 
                {
                    canHaveMost = new List<bool>();
                    for (int i = 0; i < candies.Length; i++)
                    {
                        if (candies[i] + extraCandies >= maxInList)
                        {
                            canHaveMost.Add(true);
                        }
                        else
                        {
                            canHaveMost.Add(false);
                        }
                    }
                }
                return canHaveMost;
            }
        }

        public class Solution1108
        {
            public string DefangIPaddr(string address)
            {
                return address.Replace(".", "[.]");
            }
        }

        public class Solution1342
        {
            public int NumberOfSteps(int num)
            {
                int steps = 0;
                while (num > 0)
                {
                    if(num % 2 == 0)
                    {
                        num = num / 2;
                        steps++;
                    }
                    else
                    {
                        num -= 1;
                        steps++;
                    }
                }
                return steps;
            }
        }

        public class Solution771
        {
            public int NumJewelsInStones(string J, string S)
            {
                int jewels = 0;
                for (int i = 0; i < S.Length; i++)
                {
                    if (J.Contains(S[i]))
                    {
                        jewels++;
                    }
                }
                return jewels;
            }
        }

        public class Solution1365
        {
            public int[] SmallerNumbersThanCurrent(int[] nums)
            {
                int[] result = new int[nums.Length];
                int min = int.MaxValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == min)
                    {
                        result[i] = 0;
                    }
                    int countLower = 0;
                    foreach (var num in nums)
                    {
                        if (i == 0 && num < min)
                        {
                            min = num;
                        }
                        if (num < nums[i])
                        {
                            countLower++;
                        }
                    }
                    result[i] = countLower;
                }
                return result;
            }
        }

        public class Solution1313
        {
            public static int[] DecompressRLElist(int[] nums)
            {
                int length = 0;
                for (int i = 0; i < nums.Length; i+=2)
                {
                    length += nums[i];
                }

                int[] result = new int[length];
                int currIndex = 0;
                for (int i = 0; i < nums.Length; i+=2)
                {
                    int occ = nums[i];
                    int val = nums[i + 1];
                    while(occ > 0)
                    {
                        result[currIndex] = val;
                        occ--;
                        currIndex++;
                    }
                }
                return result;
            }
        }

        public class Solution1281
        {
            public int SubtractProductAndSum(int n)
            {
                const int MAX_DIGITS = 6;
                int[] digitsReversed = new int[MAX_DIGITS];
                int currVal = n;
                for (int i = MAX_DIGITS-1; i >= 0; i--)
                {
                    digitsReversed[i] = currVal % 10;
                    currVal = currVal/10;
                }

                int totalSum = 0;
                int totalProduct = 1;
                bool passedZero = false;
                for (int i = 0; i < MAX_DIGITS; i++)
                {
                    totalSum += digitsReversed[i];
                    if(digitsReversed[i] > 0)
                    {
                        passedZero = true;
                    }
                    if (passedZero)
                    {
                        totalProduct *= digitsReversed[i];
                    }
                }
                return totalProduct - totalSum;
            }
        }

        public class Solution1389
        {
            public static int[] CreateTargetArray(int[] nums, int[] index)
            {
                int[] result = new int[nums.Length];
                HashSet<int> alreadyInserted = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (alreadyInserted.Contains(index[i]))
                    {
                        for (int x = nums.Length-2; x >= index[i]; x--)
                        {
                            result[x + 1] = result[x];
                            alreadyInserted.Add(x + 1);
                        }
                    }
                    else
                    {
                        alreadyInserted.Add(index[i]);
                    }
                    result[index[i]] = nums[i];
                }
                return result;
            }
        }

        public class Solution1295
        {
            public int FindNumbers(int[] nums)
            {
                int evenDigits = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    int digits = 0;
                    while(nums[i] > 0)
                    {
                        nums[i] = nums[i] / 10;
                        digits++;
                    }
                    if (digits % 2 == 0)
                    {
                        evenDigits++;
                    }
                }
                return evenDigits;
            }
        }

        public class Solution1221
        {
            public static int BalancedStringSplit(string s)
            {
                int countBalancedSubstrings = 0;
                int countL = 0;
                int countR = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'L')
                    {
                        countL++;
                    }
                    else
                    {
                        countR++;
                    }
                    if (countL == countR)
                    {
                        countBalancedSubstrings++;
                        countL = 0;
                        countR = 0;
                    }
                }
                return countBalancedSubstrings;
            }
        }

        public class Solution938
        {
            public int RangeSumBST(TreeNode root, int L, int R)
            {
                int sum = 0;
                if (root.val >= L && root.val <= R)
                {
                    sum += root.val;
                }
                if (root.left != null)
                {
                    sum += RangeSumBST(root.left, L, R);
                }
                if (root.right != null)
                {
                    sum += RangeSumBST(root.right, L, R);
                }
                return sum;
            }
        }

        public class Solution1290
        {
            public int GetDecimalValue(ListNode head)
            {
                int sum = 0;
                int index = 0;
                int[] digits = new int[30];
                while (head != null)
                {
                    for (int i = 0; i < index; i++)
                    {
                        digits[i] *= 2;
                    }
                    digits[index] = head.val;
                    index++;
                    head = head.next;
                }

                for (int i = 0; i < digits.Length; i++)
                {
                    sum += digits[i];
                }
                return sum;
            }
        }

        public class Solution1464
        {
            public int MaxProduct(int[] nums)
            {
                int highest = 0;
                int second = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if(nums[i] >= highest)
                    {
                        second = highest;
                        highest = nums[i];
                    } else if(nums[i] > second)
                    {
                        second = nums[i];
                    }
                }
                return (highest - 1) * (second - 1);
            }
        }

        public class Solution231
        {
            public bool IsPowerOfTwo(int n)
            {
                int ones = 0;
                if (n > 0)
                {
                    string base2String = Convert.ToString(n, toBase: 2);
                    for (int i = 0; i < base2String.Length; i++)
                    {
                        if (base2String[i] == '1')
                        {
                            ones++;
                        }
                    }
                }
                return ones == 1;
            }
        }

        public class Solution1512
        {
            public int NumIdenticalPairs(int[] nums)
            {
                int count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if(nums[i] == nums[j] && i < j)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        public class SubrectangleQueries
        {
            int[][] _rectangle;
            public SubrectangleQueries(int[][] rectangle)
            {
                _rectangle = rectangle;
            }

            public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
            {
                for (int row = 0; row < _rectangle.Length; row++)
                {
                    for (int col = 0; col < _rectangle[row].Length; col++)
                    {
                        if(row >= row1 && row <= row2 && col >= col1 && col <= col2)
                        {
                            _rectangle[row][col] = newValue;
                        }
                    }
                }
            }

            public int GetValue(int row, int col)
            {
                return _rectangle[row][col];
            }
        }

        public class Solution1486
        {
            public int XorOperation(int n, int start)
            {
                int ans = 0;
                int[] nums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    ans = ans^(start + 2 * i);
                }
                return ans;
            }
        }

        public class Solution1282
        {
            public IList<IList<int>> GroupThePeople(int[] groupSizes)
            {
                int[] groups = new int[501]; // Number of people in group of this size
                for (int i = 0; i < groupSizes.Length; i++)
                {
                    groups[groupSizes[i]] += 1;
                }

                // Get total num of groups
                int numOfGroups = 0;
                for (int gs = 0; gs < groups.Length; gs++)
                {
                    if (groups[gs] > 0)
                    {
                        numOfGroups += groups[gs] / gs;
                    }
                }

                int[][] outerGroup = new int[numOfGroups][];
                int insertIndex = 0;
                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i] > 0)
                    {
                        for (int j = 0; j < (groups[i] / i); j++)
                        {
                            outerGroup[insertIndex] = new int[i];
                            insertIndex++;
                        }
                    }
                }

                for (int i = 0; i < groupSizes.Length; i++)
                {
                    bool valueAdded = false;
                    for (int j = 0; j < outerGroup.Length; j++)
                    {
                        if (outerGroup[j].Length == groupSizes[i])
                        {
                            for (int k = 0; k < outerGroup[j].Length; k++)
                            {
                                if (outerGroup[j][k] == 0)
                                {
                                    outerGroup[j][k] = i;
                                    valueAdded = true;
                                    break;
                                }
                            }
                        }
                        if (valueAdded)
                        {
                            break;
                        }
                    }
                }

                return outerGroup;
            }

            public class Solution1266
            {
                public int MinTimeToVisitAllPoints(int[][] points)
                {
                    if (points.Length == 0 || points.Length == 1) return 0;
                    int[] current;
                    int[] target;
                    int seconds = 0;
                    for (int pt = 0; pt < points.Length-1; pt++)
                    {
                        current = points[pt];
                        target = points[pt + 1];
                        int[] next = current;
                        while (current[0] != target[0] || current[1] != target[1])
                        {
                            if (target[0] > current[0]) // Up
                            {
                                next[0]++;
                            }
                            if (target[0] < current[0]) // Down
                            {
                                next[0]--;
                            }
                            if (target[1] < current[1]) // Left
                            {
                                next[1]--;
                            }
                            if (target[1] > current[1]) // Right
                            {
                                next[1]++;
                            }
                            current = next;
                            seconds++;
                        }
                    }
                    return seconds;
                }
            }

            public class Solution804
            {
                public int UniqueMorseRepresentations(string[] words)
                {
                    string[] codes = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                    const int OFFSET = 97;
                    int diffWords = 0;
                    HashSet<string> encoded = new HashSet<string>();
                    for (int w = 0; w < words.Length; w++)
                    {
                        string encodedWord = "";
                        for (int l = 0; l < words[w].Length; l++)
                        {
                            encodedWord += codes[words[w][l] - OFFSET];
                        }
                        if(!encoded.TryGetValue(encodedWord, out string val))
                        {
                            encoded.Add(encodedWord);
                            diffWords += 1;
                        }
                    }
                    return diffWords;
                }
            }

            public class Solution832
            {
                public int[][] FlipAndInvertImage(int[][] A)
                {
                    for (int r = 0; r < A.Length; r++)
                    {
                        int insertIndex = 0;
                        int[] reversedAndFlipped = new int[A[r].Length];
                        for (int b = A[r].Length - 1; b >= 0; b--)
                        {
                            reversedAndFlipped[insertIndex] = A[r][b] ^ 1;
                            insertIndex++;
                        }
                        A[r] = reversedAndFlipped;
                    }
                    return A;
                }
            }

            public class Solution1304
            {
                public int[] SumZero(int n)
                {
                    int[] ans = new int[n];
                    int total = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if(i == n - 1)
                        {
                            ans[i] = 0-total;
                        }
                        else
                        {
                            ans[i] = i;
                            total += i;
                        }
                        
                    }
                    return ans;
                }
            }

            public class Solution1299
            {
                public int[] ReplaceElements(int[] arr)
                {
                    int curHigh = arr[arr.Length-1];
                    arr[arr.Length - 1] = -1;
                    for (int i = arr.Length - 2; i >= 0 ; i--)
                    {
                        int temp = arr[i];
                        arr[i] = curHigh;
                        if(curHigh < temp)
                        {
                            curHigh = temp;
                        }
                    }
                    return arr;
                }
            }

            public class Solution1502
            {
                public bool CanMakeArithmeticProgression(int[] arr)
                {
                    Array.Sort(arr);
                    int diff = arr[1] - arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[i] - arr[i - 1] != diff) return false;
                    }
                    return true;
                }
            }

            public class Solution13
            {
                public string GenerateTheString(int n)
                {
                    string res = "";
                    for (int i = 0; i < n-1; i++)
                    {
                        res += 'a';
                    }
                    if (n % 2 == 0)
                    {
                        res += 'z';
                    }
                    else
                    {
                        res += 'a';
                    }
                    return res;
                }
            }

            public class Solution1475
            {
                public int[] FinalPrices(int[] prices)
                {
                    for (int i = 0; i < prices.Length; i++)
                    {
                        for (int j = i+1; j < prices.Length; j++)
                        {
                            if(prices[j] <= prices[i])
                            {
                                prices[i] = prices[i] - prices[j];
                                break;
                            }
                        }
                    }
                    return prices;
                }
            }
            public class Solution1450
            {
                public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
                {
                    int count = 0;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (queryTime >= startTime[i] && queryTime <= endTime[i]) count++;
                    }
                    return count;
                }
            }

            public class Solution1323
            {
                public int Maximum69Number(int num)
                {
                    int numDuplicate = num;
                    int count = 0;
                    int latest6 = 0;

                    while (numDuplicate != 0)
                    {
                        if(numDuplicate % 10 == 6)
                        {
                            latest6 = count;
                        }
                        numDuplicate /= 10;
                        count++;
                    }
                    if (latest6 == 0 && num % 10 == 6)
                    {
                        return num + 3;
                    }
                    if (latest6 == 0) return num;
                    return num + (int)(3 * Math.Pow(10, latest6));
                }
            }

            public class Solution1021
            {
                public string RemoveOuterParentheses(string S)
                {
                    string ans = "";
                    int open = 0;
                    int close = 0;

                    for (int i = 0; i < S.Length; i++)
                    {
                        if (S[i] == '(')
                        {
                            if(open != close)
                            {
                                ans += S[i];
                            }
                            open++;
                        }
                        else
                        {
                            close++;
                            if (open != close)
                            {
                                ans += S[i];
                            }
                        }

                    }
                    return ans;
                }
            }

            public class Solution1436
            {
                public string DestCity(IList<IList<string>> paths)
                {
                    string dest = "";
                    for (int i = 0; i < paths.Count; i++)
                    {
                        bool found = false;
                        for (int j = 0; j < paths.Count; j++)
                        {
                            if(paths[i][1] == paths[j][0])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            dest = paths[i][1];
                            break;
                        }
                    }
                    return dest;
                }
            }

            public class Solution1309
            {
                public string FreqAlphabets(string s)
                {
                    const int OFFSET = 96;
                    string ans = "";
                    for (int i = 0; i < s.Length; i++)
                    {
                        if(i <= s.Length-3 && s[i+2] == '#')
                        {
                            ans += (char)(int.Parse(s[i].ToString() + s[i + 1].ToString())+OFFSET);
                            i += 2;
                        }
                        else
                        {
                            ans += (char)(int.Parse(s[i].ToString()) + OFFSET);
                        }
                    }
                    return ans;
                }
            }

            public class Solution1351
            {
                public int CountNegatives(int[][] grid)
                {
                    int total = 0;
                    for (int i = 0; i < grid.Length; i++)
                    {
                        for (int n = 0; n < grid[i].Length; n++)
                        {
                            if(grid[i][n] < 0)
                            {
                                total += grid[i].Length - n;
                                break;
                            }
                        }
                    }
                    return total;
                }
            }

            public class Solution1460
            {
                public bool CanBeEqual(int[] target, int[] arr)
                {
                    int[] nums = new int[1001];
                    for (int i = 0; i < target.Length; i++)
                    {
                        nums[target[i]]++;
                        nums[arr[i]]++;
                    }

                    for (int i = 0; i < nums.Length; i++)
                    {
                        if(nums[i] != 0 && nums[i]%2 != 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public class Solution728
            {
                public IList<int> SelfDividingNumbers(int left, int right)
                {
                    List<int> nums = new List<int>();
                    for (int i = left; i <= right; i++)
                    {
                        if (IsSelfDividing(i))
                        {
                            nums.Add(i);
                        }
                    }
                    return nums;
                }

                private bool IsSelfDividing(int num)
                {
                    int numCopy = num;
                    if (num < 10) return true;
                    while (num > 0)
                    {
                        if(num%10 == 0 || numCopy % (num%10) != 0)
                        {
                            return false;
                        }
                        num = num / 10;
                    }
                    return true;
                }
            }

            public class Solution617
            {
                public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
                {
                    TreeNode node = new TreeNode();
                    if(t1 != null && t2 != null)
                    {
                        node.val = t1.val + t2.val;
                        node.left = MergeTrees(t1.left, t2.left);
                        node.right = MergeTrees(t1.right, t2.right);
                    } 
                    else if(t1 == null && t2 == null)
                    {
                        return null;
                    }
                    else if(t1 != null)
                    {
                        return t1;
                    }
                    else
                    {
                        return t2;
                    }
                    
                    return node;
                }
            }

            public class Solution905
            {
                public int[] SortArrayByParity(int[] A)
                {
                    int[] ans = new int[A.Length];
                    int fromFront = 0;
                    int fromBack = A.Length - 1;
                    for (int i = 0; i < A.Length; i++)
                    {
                        if(A[i] % 2 == 0)
                        {
                            ans[fromFront] = A[i];
                            fromFront++;
                        }
                        else
                        {
                            ans[fromBack] = A[i];
                            fromBack--;
                        }
                    }
                    return ans;
                }
            }

            public class Solution961
            {
                public int RepeatedNTimes(int[] A)
                {
                    HashSet<int> set = new HashSet<int>();
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (set.Contains(A[i]))
                        {
                            return A[i];
                        }
                        else
                        {
                            set.Add(A[i]);
                        }
                    }
                    return -1;
                }
            }

            public class Solution657
            {
                public bool JudgeCircle(string moves)
                {
                    int ud = 0;
                    int lr = 0;
                    for (int i = 0; i < moves.Length; i++)
                    {
                        if(moves[i] == 'U')
                        {
                            ud++;
                        }
                        else if(moves[i] == 'D')
                        {
                            ud--;
                        }
                        else if(moves[i] == 'L')
                        {
                            lr++;
                        }
                        else if(moves[i] == 'R')
                        {
                            lr--;
                        }
                    }
                    return ud == 0 && lr == 0;
                }
            }

            public class Solution700
            {
                public TreeNode SearchBST(TreeNode root, int val)
                {
                    if (root == null) return null;
                    if (root.val == val)
                    {
                        return root;
                    }
                    TreeNode left = SearchBST(root.left, val);
                    if(left != null)
                    {
                        return left;
                    }
                    else
                    {
                        return SearchBST(root.right, val);
                    }
                }
            }

            public class Solution461
            {
                public int HammingDistance(int x, int y)
                {
                    int diff = x ^ y;
                    string s = Convert.ToString(diff, 2);
                    int count = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if(s[i] == '1')
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }

            public class Solution942
            {
                public int[] DiStringMatch(string S)
                {
                    int low = 0;
                    int high = S.Length;
                    int[] ans = new int[S.Length+1];

                    for (int i = 0; i < S.Length; i++)
                    {
                        if(S[i] == 'D')
                        {
                            ans[i] = high;
                            high--;
                        }
                        else
                        {
                            ans[i] = low;
                            low++;
                        }
                    }
                    if(S[S.Length-1] == 'D')
                    {
                        ans[S.Length] = high;
                    }
                    else
                    {
                        ans[S.Length] = low;
                    }
                    return ans;
                }
            }

            public class Solution977
            {
                public int[] SortedSquares(int[] A)
                {
                    for (int i = 0; i < A.Length; i++)
                    {
                        A[i] = A[i] * A[i];
                    }
                    Array.Sort(A);
                    return A;
                }
            }

            public class Solution561
            {
                public int ArrayPairSum(int[] nums)
                {
                    Array.Sort(nums);
                    int total = 0;
                    for (int i = 0; i < nums.Length; i+=2)
                    {
                        total += nums[i];
                    }
                    return total;
                }
            }

            public class Solution1672
            {
                public int MaximumWealth(int[][] accounts)
                {
                    int highestWealthSoFar = -1;
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        int customerTotal = 0;
                        for (int j = 0; j < accounts[i].Length; j++)
                        {
                            customerTotal += accounts[i][j];
                        }
                        if(customerTotal > highestWealthSoFar)
                        {
                            highestWealthSoFar = customerTotal;
                        }
                    }
                    return highestWealthSoFar;
                }
            }

            public class ParkingSystem1603
            {
                int _big;
                int _med;
                int _small;

                public ParkingSystem1603(int big, int medium, int small)
                {
                    _big = big;
                    _med = medium;
                    _small = small;
                }

                public bool AddCar(int carType)
                {
                    if (carType == 1 && _big > 0)
                    {
                        _big -= 1;
                        return true;
                    } else if(carType == 2 && _med > 0)
                    {
                        _med -= 1;
                        return true;
                    }
                    else if(carType == 3 &&  _small > 0)
                    {
                        _small -= 1;
                        return true;
                    }
                    return false;
                }
            }

            public class Solution1528
            {
                public string RestoreString(string s, int[] indices)
                {
                    char[] chars = new char[indices.Length];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        chars[indices[i]] = s[i];
                    }
                    return new string(chars);
                }
            }

            public class Solution1773
            {
                public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
                {
                    int matches = 0;
                    int indexToCheck;
                    if(ruleKey == "type")
                    {
                        indexToCheck = 0;
                    } else if(ruleKey == "color")
                    {
                        indexToCheck = 1;
                    } else
                    {
                        indexToCheck = 2;
                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        if(items[i][indexToCheck] == ruleValue)
                        {
                            matches++;
                        }
                    }
                    return matches;
                }
            }

            public class Solution1678
            {
                public string Interpret(string command)
                {
                    string result = "";
                    for (int i = 0; i < command.Length; i++)
                    {
                        if(command[i] == 'G')
                        {
                            result += "G";
                        }else if(command[i] == '(' && command[i+1] == ')')
                        {
                            i++;
                            result += "o";
                        }
                        else
                        {
                            i += 3;
                            result += "al";
                        }
                    }
                    return result;
                }
            }

            public class Solution1614
            {
                public int MaxDepth(string s)
                {
                    if (s == "")
                    {
                        return 0;
                    }
                    int depth = 0;
                    int open = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if(s[i] == '(')
                        {
                            open++;
                            if(open > depth)
                            {
                                depth = open;
                            }
                        }else if(s[i] == ')')
                        {
                            open--;
                        }
                    }
                    return depth;
                }

                public class Solution1720
                {
                    public int[] Decode(int[] encoded, int first)
                    {
                        int[] n = new int[encoded.Length+1];
                        n[0] = first;
                        for (int i = 0; i < encoded.Length; i++)
                        {
                            n[i+1] = n[i] ^ encoded[i];
                        }
                        return n;
                    }
                }
            }
        }

    }
}
