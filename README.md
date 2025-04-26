# Leetcode
Leetcode Problems

## Table of Contents
- [AddTwoNumbers](#AddTwoNumbers)
- [3Sum](#3Sum)

## AddTwoNumbers
```csharp
/// <summary>
///     Adds two numbers represented as linked lists and returns the sum as a linked list.
///     Each node contains a single digit, and the digits are stored in reverse order.
/// </summary>
/// <param name="l1">The first linked list representing a number.</param>
/// <param name="l2">The second linked list representing a number.</param>
/// <returns>A linked list representing the sum of the two numbers.</returns>
/// <remarks>
///     Time Complexity: O(max(m, n)), where m and n are the lengths of the two linked lists.
///     - Each node in both linked lists is processed once.
///     Space Complexity: O(max(m, n)), where m and n are the lengths of the two linked lists.
///     - The space is used for the resulting linked list.
/// </remarks>
public static ListNode? RunAddTwoNumbers(ListNode? l1, ListNode? l2) {
    // Initialize with a dummy node to avoid null issues
    var sm = new ListNode();

    // Head points to the dummy node
    var hd = sm;
    var co = 0;

    while (l1 != null || l2 != null) {
        int n1 = 0, n2 = 0;
        if (l1 != null) {
            // Use property `Val` instead of `val`
            n1 = l1.Val;
            // Safely assign nullable `Next`
            l1 = l1.Next;
        }

        if (l2 != null) {
            // Use property `Val` instead of `val`
            n2 = l2.Val;
            // Safely assign nullable `Next`
            l2 = l2.Next;
        }

        var s = co + n1 + n2;
        // Use property `Next` instead of `next`
        sm.Next = new ListNode(s % 10);
        // Move to the next node using `Next`
        sm = sm.Next;
        co = s / 10;
    }

    if (co > 0) {
        // Use property `Next` instead of `next`
        sm.Next = new ListNode(co);
    }

    // Return the next node of the dummy node as the actual head
    return hd.Next;
}
```

## 3Sum
```csharp
/// <summary>
///     Finds all unique triplets in the given array such that the sum of the three numbers is zero.
/// </summary>
/// <param name="nums">An array of integers.</param>
/// <returns>A list of lists, where each inner list contains three integers that sum up to zero.</returns>
/// <remarks>
///     Time Complexity: O(n^2), where n is the length of the input array.
///     - Sorting the array takes O(n log n).
///     - The two-pointer approach for each element takes O(n), and this is done for each of the n elements.
///     Space Complexity: O(1) (excluding the output list), as the algorithm operates in-place after sorting.
/// </remarks>
public static IList<IList<int>> FindThreeSum(int[] nums) {
    // Step 1: Sort the array
    Array.Sort(nums);

    // Use concrete type for better performance
    var result = new List<IList<int>>();

    for (int i = 0, n = nums.Length; i < n - 2; i++) {
        // Skip duplicates for nums[i]
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int left = i + 1, right = n - 1;
        while (left < right) {
            var sum = nums[i] + nums[left] + nums[right];
            switch (sum) {
                case 0: {
                    // Use array instead of List<int> for efficiency
                    result.Add([nums[i], nums[left], nums[right]]);

                    // Skip duplicates for left and right
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                    break;
                }
                case < 0:
                    // Increase sum
                    left++;
                    break;
                default:
                    // Decrease sum
                    right--;
                    break;
            }
        }
    }

    return result;
}
```
