# Interview Prep

Small C# console project with common interview algorithm implementations.

## Overview

This repository contains a minimal console app demonstrating several algorithmic helper methods in the `Functions` class:

- `MinSubArrayLen(int target, int[] numbers)` — minimum length contiguous subarray with sum >= `target`.  
  Complexity: O(n) time, O(1) extra space.

- `LongestZeroSumSubarray(int[] numbers)` — length of longest contiguous subarray summing to zero.  
  Complexity: O(n) time, O(n) space.

- `FirstUniqueChar(string input)` — first non-repeating character (returns `char?`).  
  Complexity: O(n) time, O(1) extra space (fixed 256-size frequency array).

- `TwoSum(int[] nums, int target)` — returns two indices whose values add to `target`.  
  Complexity: O(n) time, O(n) space.

All implementations are in `Functions.cs`. The project entry point is `Program.cs`, which contains simple test methods and calls `TestMinSubArrayLen()` by default.

## Requirements

- .NET SDK: .NET 10
- C# language version: 14.0
- Visual Studio 2026 (optional) or `dotnet` CLI

If using Visual Studio, open the solution and use __StartDebugging__ or __Run__ as usual. Ensure the project target framework is set to `.NET 10` in project properties.
