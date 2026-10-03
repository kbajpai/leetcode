using Xunit;

namespace LeetcodeTests {
    public class CourseScheduleTests {
        private readonly TestableCourseSchedule _courseSchedule = new();

        [Fact]
        public void CanFinish_HandlesMultipleCallsCorrectly() {
            // Arrange - Test that state is properly reset between calls
            const int S_NUM_COURSES1 = 2;
            var prerequisites1 = new int[][] { [1, 0] };

            const int S_NUM_COURSES2 = 2;
            var prerequisites2 = new int[][] { [1, 0], [0, 1] };

            // Act
            var result1 = _courseSchedule.CanFinish(S_NUM_COURSES1, prerequisites1);
            var result2 = _courseSchedule.CanFinish(S_NUM_COURSES2, prerequisites2);

            // Assert
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenCycleInMiddleOfChain() {
            // Arrange - Cycle in chain: 0 -> 1 -> 2 -> 1
            const int S_NUM_COURSES = 3;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 1],
                [1, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenLongCycleExists() {
            // Arrange - Long cycle: 0->1->2->3->4->0
            const int S_NUM_COURSES = 5;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 1],
                [3, 2],
                [4, 3],
                [0, 4]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenOneCycleInMultipleComponents() {
            // Arrange - One valid chain and one cycle
            //     0 -> 1    2 <-> 3
            const int S_NUM_COURSES = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [3, 2],
                [2, 3]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenSelfLoop() {
            // Arrange - Course depends on itself: 0 -> 0
            const int S_NUM_COURSES = 1;
            var prerequisites = new int[][] {
                [0, 0]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenSimpleCycleExists() {
            // Arrange - Cycle: 1 -> 0 -> 1
            const int S_NUM_COURSES = 2;
            var prerequisites = new int[][] {
                [1, 0],
                [0, 1]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsFalse_WhenThreeNodeCycle() {
            // Arrange - Cycle: 0 -> 1 -> 2 -> 0
            const int S_NUM_COURSES = 3;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 1],
                [0, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenComplexDAG() {
            // Arrange - Complex DAG without cycles
            //     0 -> 1 -> 3
            //     |         ^
            //     v         |
            //     2 --------+
            const int S_NUM_COURSES = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 0],
                [3, 1],
                [3, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenCoursesWithNoConnections() {
            // Arrange - 5 courses with no dependencies
            const int S_NUM_COURSES = 5;
            var prerequisites = Array.Empty<int[]>();

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenDAGWithMultiplePaths() {
            // Arrange - DAG: 0 and 1 both point to 2
            //     0 \
            //         2
            //     1 /
            const int S_NUM_COURSES = 3;
            var prerequisites = new int[][] {
                [2, 0],
                [2, 1]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenDiamondDependency() {
            // Arrange - Diamond pattern (DAG)
            //       0
            //      / \
            //     1   2
            //      \ /
            //       3
            const int S_NUM_COURSES = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 0],
                [3, 1],
                [3, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenDisconnectedComponents() {
            // Arrange - Multiple disconnected valid chains
            //     0 -> 1    2 -> 3    4 -> 5
            const int S_NUM_COURSES = 6;
            var prerequisites = new int[][] {
                [1, 0],
                [3, 2],
                [5, 4]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenLargeDAG() {
            // Arrange - Large DAG: 0->1->2->3->4->5
            const int S_NUM_COURSES = 6;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 1],
                [3, 2],
                [4, 3],
                [5, 4]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenLinearChainExists() {
            // Arrange - Chain: 3 -> 2 -> 1 -> 0
            const int S_NUM_COURSES = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 1],
                [3, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenMultipleDependentsFromOnePrerequisite() {
            // Arrange - One course is prerequisite for multiple courses
            //     0 -> 1
            //     0 -> 2
            //     0 -> 3
            var numCourses = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [2, 0],
                [3, 0]
            };

            // Act
            var result = _courseSchedule.CanFinish(numCourses, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenMultipleIndependentChains() {
            // Arrange - Two independent chains: (1->0) and (3->2)
            var numCourses = 4;
            var prerequisites = new int[][] {
                [1, 0],
                [3, 2]
            };

            // Act
            var result = _courseSchedule.CanFinish(numCourses, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenNoCycles() {
            // Arrange - Linear dependency: 1 -> 0
            const int S_NUM_COURSES = 2;
            var prerequisites = new int[][] {
                [1, 0]
            };

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenNoPrerequisites() {
            // Arrange
            const int S_NUM_COURSES = 3;
            var prerequisites = Array.Empty<int[]>();

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanFinish_ReturnsTrue_WhenSingleCourse() {
            // Arrange
            const int S_NUM_COURSES = 1;
            var prerequisites = Array.Empty<int[]>();

            // Act
            var result = _courseSchedule.CanFinish(S_NUM_COURSES, prerequisites);

            // Assert
            Assert.True(result);
        }

        // Create a concrete implementation for testing
        private class TestableCourseSchedule : CourseSchedule {
            // Concrete implementation for testing
        }
    }
}