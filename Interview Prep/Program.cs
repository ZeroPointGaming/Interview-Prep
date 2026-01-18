namespace Interview_Prep
{
    internal class Program
    {
        // Instantiate my custom functionality class for non-static members.
        Functions functionProvider = new Functions();

        static void Main(string[] args)
        {
            // Call test methods to demonstrate functionality.
            //TestLongestZeroSumSubarray();

            TestMinSubArrayLen();
        }

        static void TestLongestZeroSumSubarray()
        {
            // The expected reuslt of the test array is 6 because index 0 to index 5 sums to zero.
            int[] test = new int[] { 1, 2, -3, 2, 4, -6, 4 };
            Console.WriteLine($"Zero sum sub array unit test results: {Functions.LongestZeroSumSubarray(test)}");
        }

        static void TestMinSubArrayLen()
        {
            int[] test = new int[] { 2, 3, 1, 2, 4, 3, 6, 1, 4, 3 };
            int target = 7;
            Console.WriteLine($"Min sub array length unit test results: {Functions.MinSubArrayLen(target, test)}");
        }
    }
}
