# Interview Prep

Small C# console project with common interview algorithm implementations.

## Overview

This repository contains a minimal console app demonstrating several algorithmic helper methods in the `Functions` class.

Implemented helpers:
- `ContainsDuplicate(int[] numbers)` — returns whether the array contains any duplicate values. Complexity: O(n) time, O(n) space.
- `MinSubArrayLen(int target, int[] numbers)` — minimum length contiguous subarray with sum >= `target`. Complexity: O(n) time, O(1) extra space.
- `LongestZeroSumSubarray(int[] numbers)` — length of longest contiguous subarray summing to zero. Complexity: O(n) time, O(n) space.
- `FirstUniqueChar(string input)` — first non-repeating character (returns `char?`). Complexity: O(n) time, O(1) extra space (fixed 256-size frequency array).
- `TwoSum(int[] nums, int target)` — returns two indices whose values add to `target`. Complexity: O(n) time, O(n) space.
- `HasTwoSum(int[] nums, int target)` — returns whether any two values add to `target`. Complexity: O(n) time, O(n) space.
- `CheckDoubleExists(int[] nums)` — returns whether any value is double another value in the array. Complexity: O(n) time, O(n) space.

All implementations are in `Interview Prep/Functions.cs`. The console listener and demo routines live in `Interview Prep/Program.cs`.
