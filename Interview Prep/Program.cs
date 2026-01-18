namespace Interview_Prep
{
    internal class Program
    {
        // Instantiate my custom functionality class for non-static members.
        Functions functionProvider = new Functions();

        // Map readable test names to the static test methods below.
        static readonly Dictionary<string, Action> TestMap = new(StringComparer.OrdinalIgnoreCase)
        {
            { "minsubarraylen", TestMinSubArrayLen },
            { "min", TestMinSubArrayLen },
            { "longestzerosum", TestLongestZeroSumSubarray },
            { "zero", TestLongestZeroSumSubarray },
            { "firstunique", TestFirstUniqueCharacter },
            { "gettwosum", TestTwoSum },
            { "containsduplicate", TestContainsDuplicate },
            { "checktwosum", TestCheckTwoSum }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Interview Prep — Test Console Listener");
            Console.WriteLine("Type 'help' for available commands.");

            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input)) continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting.");
                    break;
                }

                if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("  list           - list available tests");
                    Console.WriteLine("  run <name>     - run a test by name (aliases allowed)");
                    Console.WriteLine("  runall | all   - run all tests");
                    Console.WriteLine("  <name>         - shorthand: type a test name to run it");
                    Console.WriteLine("  exit | quit    - exit listener");
                    continue;
                }

                if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Available tests:");
                    foreach (var key in TestMap.Keys)
                    {
                        Console.WriteLine($"  {key}");
                    }
                    continue;
                }

                if (input.Equals("runall", StringComparison.OrdinalIgnoreCase) || input.Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var kv in TestMap)
                    {
                        RunTest(kv.Key, kv.Value);
                    }
                    continue;
                }

                if (input.StartsWith("run ", StringComparison.OrdinalIgnoreCase))
                {
                    string name = input.Substring(4).Trim();
                    if (TestMap.TryGetValue(name, out var action))
                    {
                        RunTest(name, action);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown test '{name}'. Type 'list' to see available tests.");
                    }
                    continue;
                }

                // Allow direct test name invocation without the "run" prefix.
                if (TestMap.TryGetValue(input, out var testAction))
                {
                    RunTest(input, testAction);
                    continue;
                }

                Console.WriteLine($"Unrecognized command '{input}'. Type 'help' for commands.");
            }
        }

        static void RunTest(string name, Action test)
        {
            Console.WriteLine();
            Console.WriteLine($"--- Running: {name} ---");
            try
            {
                test();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test '{name}' threw an exception: {ex}");
            }
            Console.WriteLine($"--- Finished: {name} ---");
            Console.WriteLine();
        }

        static void TestLongestZeroSumSubarray()
        {
            // The expected reuslt of the test array is 6 because index 0 to index 5 sums to zero.
            int[] test = new int[] { 1, 2, -3, 2, 4, -6, 4 };
            Console.WriteLine("Test Data: { 1, 2, -3, 2, 4, -6, 4 }");
            Console.WriteLine($"Zero sum sub array unit test results: {Functions.LongestZeroSumSubarray(test)}");
        }

        static void TestMinSubArrayLen()
        {
            int[] test = new int[] { 2, 3, 1, 2, 4, 3, 6, 1, 4, 3 };
            int target = 7;
            Console.WriteLine("Test Data: { 2, 3, 1, 2, 4, 3, 6, 1, 4, 3 } with target 7");
            Console.WriteLine($"Min sub array length unit test results: {Functions.MinSubArrayLen(target, test)}");
        }

        static void TestFirstUniqueCharacter()
        {
            string test = "leetcode";
            Console.WriteLine("Test Data: \"leetcode\"");
            Console.WriteLine($"First unique character unit test results: {Functions.FirstUniqueChar(test)}");
        }

        static void TestTwoSum()
        {
            int[] test = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[]? result = Functions.TwoSum(test, target);
            Console.WriteLine("Test Data: { 2, 7, 11, 15 } with target 9");
            Console.WriteLine($"Two sum unit test results: " + (result != null ? $"[{result[0]}, {result[1]}]" : ""));
        }

        static void TestContainsDuplicate()
        {
            int[] test = new int[] { 1, 2, 3, 1 };
            Console.WriteLine("Test Data: { 1, 2, 3, 1 }");
            Console.WriteLine($"Contains duplicate unit test results: {Functions.ContainsDuplicate(test)}");
        }

        static void TestCheckTwoSum()
        {
            int[] test = new int[] { 1, 2, 3, 4, 5 };
            int target = 10;
            Console.WriteLine("Test Data: { 1, 2, 3, 4, 5 } with target 10");
            Console.WriteLine($"Check two sum unit test results: {Functions.CheckTwoSum(test, target)}");
        }
}