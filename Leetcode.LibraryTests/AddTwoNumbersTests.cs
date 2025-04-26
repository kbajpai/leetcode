using Leetcode;
using Leetcode.Common;
using Xunit;

namespace LeetcodeTests;

public class AddTwoNumbersTests {
    [Fact]
    public void AddTwoNumbers_BothEmpty_ReturnsNull() {
        // Arrange
        ListNode? l1 = null;
        ListNode? l2 = null;

        // Act
        var result = AddTwoNumbers.RunAddTwoNumbers(l1, l2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AddTwoNumbers_BothNonEmpty_ReturnsCorrectSum() {
        // Arrange
        var l1 = CreateLinkedList(2, 4, 3);
        var l2 = CreateLinkedList(5, 6, 4);

        // Act
        var result = AddTwoNumbers.RunAddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(new[] { 7, 0, 8 }, ConvertToList(result));
    }

    [Fact]
    public void AddTwoNumbers_LongListsWithCarryOver_ReturnsCorrectSum() {
        // Arrange
        var l1 = CreateLinkedList(1, 8);
        var l2 = CreateLinkedList(0);

        // Act
        var result = AddTwoNumbers.RunAddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(new[] { 1, 8 }, ConvertToList(result));
    }

    [Fact]
    public void AddTwoNumbers_OneEmpty_ReturnsOtherList() {
        // Arrange
        var l1 = CreateLinkedList(0);
        var l2 = CreateLinkedList(5, 6, 4);

        // Act
        var result = AddTwoNumbers.RunAddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(new[] { 5, 6, 4 }, ConvertToList(result));
    }

    [Fact]
    public void AddTwoNumbers_WithCarryOver_ReturnsCorrectSum() {
        // Arrange
        var l1 = CreateLinkedList(9, 9, 9);
        var l2 = CreateLinkedList(1);

        // Act
        var result = AddTwoNumbers.RunAddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(new[] { 0, 0, 0, 1 }, ConvertToList(result));
    }

    private static List<int> ConvertToList(ListNode? head) {
        var result = new List<int>();
        while (head != null) {
            result.Add(head.Val);
            head = head.Next;
        }

        return result;
    }

    private static ListNode CreateLinkedList(params int[] values) {
        var dummy = new ListNode();
        var current = dummy;
        foreach (var value in values) {
            current.Next = new ListNode(value);
            current = current.Next;
        }

        return dummy.Next!;
    }
}