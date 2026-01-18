using System;
using System.Collections.Generic;
using System.Text;

namespace Interview_Prep
{
    public class Functions
    {
        #region 'Frequency Problems'
        /// <summary>
        /// Determines whether the specified string contains any duplicate characters.
        /// </summary>
        /// <remarks>This method considers all characters based on their Unicode code points. The check is
        /// case-sensitive, so 'A' and 'a' are treated as distinct characters.</remarks>
        /// <param name="input">The string to examine for duplicate characters. If null or less than two characters in length, the method
        /// returns false.</param>
        /// <returns>true if the input string contains at least one character that appears more than once; otherwise, false.</returns>
        public static bool ContainsDuplicateChar(string input)
        {
            // Validate the input parameters O(1) time & space
            if (input == null || input.Length < 2) return false;

            // Declare our local scope frequency array with a max size of 256 for ASCII characters. O(1) space complexity.
            int[] freq = new int[256];

            // Iterate over the input string and increment the frequency array per I. O(n) time complexity.
            for (int i = 0; i < input.Length; i++)
            {
                freq[input[i]]++;

                // If any character frequency is greater than 1, we have a duplicate and return true.
                if (freq[input[i]] > 1) return true;
            }

            // If we complete the loop without finding duplicates, return false.
            return false;
        }

        /// <summary>
        /// Returns the first non-repeating character in the provided <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The string to search for a unique character. If <c>null</c> or empty, the method returns <c>null</c>.</param>
        /// <returns>The first unique <see cref="char"/> found in <paramref name="input"/>, or <c>null</c> if none is found.</returns>
        /// <remarks>
        /// Implementation notes:
        /// - Uses a fixed-size frequency array of length 256 to count occurrences (assumes characters map into the 0..255 range).
        /// - Time complexity: O(2n) where n is the length of input.
        /// - Space complexity: O(1) because the frequency array size is constant (256).
        /// </remarks>
        public static char? FirstUniqueChar(string input)
        {
            // Validate the input parameters
            if (string.IsNullOrEmpty(input)) return null;

            // Setup a max size frequency array for ASCII characters to maintain O(1) space complexity.
            int[] count = new int[256];

            // First pass to count occurrences of each character
            for (int i = 0; i < input.Length; i++)
            {
                count[input[i]]++;
            }

            // Second pass to find the first unique character
            for (int i = 0; i < input.Length; i++)
            {
                if (count[input[i]] == 1) return input[i];
            }

            // Defaut return null if no unique character is found.
            return null;
        }

        /// <summary>
        /// Determines whether two specified strings are anagrams of each other.
        /// </summary>
        /// <remarks>An anagram is a word or phrase formed by rearranging the letters of another, using
        /// all the original letters exactly once. The comparison is case-sensitive and considers all characters,
        /// including whitespace and punctuation. If either input is <see langword="null"/>, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="s">The first string to compare.</param>
        /// <param name="t">The second string to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> and <paramref name="t"/> are anagrams of each other;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsAnagram(string s, string t)
        {
            // Validate the input parameters
            if (s == null || t == null) return false;
            if (s.Length != t.Length) return false;

            // Setup frequency arrays for both strings to maintain O(1) space complexity.
            int[] freqS = new int[256];
            int[] freqT = new int[256];

            // Populate the frequency arrays for both strings.
            for (int i = 0; i < s.Length; i++)
            {
                freqS[s[i]]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                freqT[t[i]]++;
            }

            // Compare the frequency arrays to determine if they are anagrams.
            for (int i = 0; i < 256; i++)
            {
                // If any frequency does not match, the strings are not anagrams.
                if (freqS[i] != freqT[i]) return false;
            }

            return true;
        }
        #endregion

        #region 'Sliding Window Problems'
        /// <summary>
        /// This method finds the minimum length of a contiguous subarray of which the sum is at least equal to the target value.
        /// </summary>
        /// <param name="target">The target sum to achieve.</param>
        /// <param name="numbers">An array of positive integers.</param>
        /// <returns>The minimum length of a contiguous subarray with a sum at least equal to the target. Returns 0 if no such subarray exists.</returns>
        /// <remarks>
        /// Time complexity: O(n) where n is the length of the numbers array. Space complexity: O(1) as we use a fixed amount of extra space.
        /// Uses a sliding window approach to find the minimum length subarray.
        /// </remarks>
        public static int MinSubArrayLen(int target, int[] numbers)
        {
            // First we validate the numbers array input. target should self validate because its declared as an int.
            if (numbers == null || numbers.Length == 0) return 0;

            // We define the left window, running sum and the min length. We default the min length to the max int number
            // Because it can only shrink, if we start at 0 we invalidate the logic.
            int left = 0;
            int sum = 0;
            int minLength = int.MaxValue;

            // Iterate over the numbers array to find the minimum length sub array that equals the target.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Add the current index to the running sum.
                sum += numbers[i];

                // While the running sum is >= target we shrink the to the left until the current legth is less than the min length.
                // then we subtract the left index link from the running sum.
                while (sum >= target)
                {
                    int currentLength = i - left + 1;
                    if (currentLength < minLength)
                    {
                        minLength = currentLength;
                    }

                    sum -= numbers[left];

                    // Increase the left offset by one to actually shrink on the next iteration.
                    left++;
                }
            }

            // Once we are done, if the min length is still the max value int return 0 otherwise return the min length.
            return minLength == int.MaxValue ? 0 : minLength;
        }
        #endregion

        #region 'Hash Lookup Problems'
        /// <summary>
        /// Determines whether any two distinct elements in the specified array sum to the given target value.
        /// </summary>
        /// <remarks>Elements are considered distinct if they have different indices in the array. The
        /// method returns false if the array is null or contains fewer than two elements.</remarks>
        /// <param name="numbers">An array of integers to search for a pair whose sum equals the target. Cannot be null and must contain at
        /// least two elements.</param>
        /// <param name="target">The target sum to search for as the sum of two distinct elements in the array.</param>
        /// <returns>true if there are two distinct elements in the array whose sum equals the target value; otherwise, false.</returns>
        public static bool HasTwoSum(int[] numbers, int target)
        {
            // Validate the input parameters
            if (numbers == null || numbers.Length < 2) return false;

            // Declare the local scope variables.
            HashSet<int> seen = new HashSet<int>();

            // Iterate through the numbers array to find the two sum.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Calculate the needed value to reach the target sum.
                int needed = target - numbers[i];

                // Check if the needed value has already been seen.
                if (!seen.Contains(needed))
                {
                    // If not seen, add the current number to the seen set.
                    seen.Add(numbers[i]);
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified array contains two distinct elements such that one element is double the
        /// other.
        /// </summary>
        /// <param name="numbers">An array of integers to search for a pair where one value is double the other. Cannot be null.</param>
        /// <returns>true if there exists at least one pair of distinct elements where one is double the other; otherwise, false.</returns>
        public static bool CheckIfDoubleExists(int[] numbers)
        {
            // Validate the input parameters
            if (numbers == null || numbers.Length < 2) return false;

            // Declare the local scope variables.
            HashSet<int> seen = new HashSet<int>();

            // Iterate through the numbers array to find duplicates.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Check if the double or half of the current number has already been seen.
                if (seen.Contains(numbers[i] * 2) || (numbers[i] % 2 == 0) && seen.Contains(numbers[i] / 2)) return true;

                // If not seen, add the current number to the seen set.
                seen.Add(numbers[i]);
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified array contains at least one pair of integers where one is the negation of
        /// the other.
        /// </summary>
        /// <remarks>The method returns false if the array is null or contains fewer than two elements.
        /// Zero is considered its own negation, so a pair of zeros will be detected as a valid negation pair.</remarks>
        /// <param name="numbers">An array of integers to search for pairs of numbers that are negatives of each other. Cannot be null.</param>
        /// <returns>true if the array contains at least one pair of integers such that one is the negation of the other;
        /// otherwise, false.</returns>
        public static bool CheckIfNegationExists(int[] numbers)
        {
            // Validate the input parameters
            if (numbers == null || numbers.Length < 2) return false;

            // Declare the local scope variables.
            HashSet<int> seen = new HashSet<int>();

            // Iterate through the numbers array to find negation pairs.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Check if the negation of the current number has already been seen.
                if (seen.Contains(numbers[i] * -1))
                {
                    return true;
                }
                else
                {
                    // If not seen, add the current number to the seen set.
                    seen.Add(numbers[i]);
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified array contains any duplicate integer values.
        /// </summary>
        /// <remarks>If the array is null or contains fewer than two elements, the method returns
        /// false. This method is O(n) complexity for both time and space.</remarks>
        /// <param name="numbers">An array of integers to check for duplicate values. Can be null or empty.</param>
        /// <returns>true if any value appears more than once in the array; otherwise, false.</returns>
        public static bool ContainsDuplicate(int[] numbers)
        {
            // Validate the input parameters
            if (numbers == null || numbers.Length < 2) return false;

            // Declare the local scoep variables.
            HashSet<int> seen = new HashSet<int>();

            // Iterate through the numbers array to find duplicates.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Check if the current number has already been seen.
                if (seen.Contains(numbers[i]))
                {
                    return true;
                }
                else
                {
                    // If not seen, add the current number to the seen set.
                    seen.Add(numbers[i]);
                }
            }

            // If we complete the loop without finding duplicates, return false.
            return false;
        }
        #endregion

        #region 'Prefix Sum Problems'
        /// <summary>
        /// Two Sum problem: Finds two indices in the array such that their values add up to the target.
        /// </summary>
        /// <param name="nums">Array of input numbers</param>
        /// <param name="target">Target sum integer</param>
        /// <returns>Returns the array of two elements from the origin array that summate to the target value or null if none were found.</returns>
        public static int[]? TwoSum(int[] nums, int target)
        {
            // Validate the input parameters
            if (nums == null || nums.Length < 2) return null;

            // Define a dictionary to keep track of seen numbers and their indices.
            Dictionary<int, int> seen = new Dictionary<int, int>();

            // Iterate through the numbers array to find the two sum.
            for (int i = 0; i < nums.Length; i++)
            {
                // Calculate the needed value to reach the target sum.
                int needed = target - nums[i];

                // Check if the needed value has already been seen.
                if (seen.ContainsKey(needed))
                {
                    // If found, return the indices of the two numbers.
                    return new int[] { seen[needed], i };
                }

                // If not found, add the current number and its index to the seen dictionary.
                seen[nums[i]] = i;
            }

            return null;
        }

        /// <summary>
        /// Finds the length of the longest contiguous subarray that sums to zero.
        /// </summary>
        /// <param name="numbers">An array of integers to search for the longest zero-sum subarray.</param>
        /// <returns>The length of the longest contiguous subarray that sums to zero. Returns 0 if no such subarray exists.</returns>
        /// <remarks>
        /// Time complexity: O(n). Space complexity: O(n).
        /// Uses a prefix-sum dictionary to record the first index of each running sum; a repeated running sum indicates a zero-sum subarray.
        /// Returns 0 for null or empty input. The input array is not modified.
        /// </remarks>
        public static int LongestZeroSumSubarray(int[] numbers)
        {
            // Validate the input parameters
            if (numbers == null || numbers.Length == 0) return 0;

            Dictionary<int, int> prefixMap = new Dictionary<int, int>();
            int maxL = 0;
            int runningS = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                // First add the current index to running sum.
                runningS += numbers[i];

                // Next check if running sum is at zero, this becomes our new max length.
                if (runningS == 0)
                {
                    maxL = i + 1;
                }

                if (prefixMap.ContainsKey(runningS))
                {
                    // If the sum is already in the index, fetch and compare it so we dont overwrite indices
                    int currentL = i - prefixMap[runningS];

                    // If the current length is longer than our max length, update max length.
                    if (currentL > maxL) maxL = currentL;
                }
                else
                {
                    prefixMap[runningS] = i;
                }
            }

            return maxL;
        }
        #endregion
    }
}
