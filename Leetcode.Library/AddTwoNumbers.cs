using Leetcode.Common;

namespace Leetcode;

/// <summary>
///     Provides a method to add two numbers represented as linked lists.
/// </summary>
public abstract class AddTwoNumbers {
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
}