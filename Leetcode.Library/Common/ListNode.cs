namespace Leetcode.Common;

public class ListNode(int val = 0, ListNode? next = null) {
    public int Val { get; } = val;

    public ListNode? Next { get; set; } = next;
}