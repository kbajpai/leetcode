public abstract class CourseSchedule {
    private readonly Dictionary<int, IList<int>> _dependsOn = new();
    private int[] _state; // 0: unvisited, 1: visiting, 2: visited

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        _state = new int[numCourses];
        _dependsOn.Clear();

        foreach (var p in prerequisites) {
            //p[0] depends on p[1]
            if (!_dependsOn.TryGetValue(p[1], out var list)) {
                list = new List<int>();
                _dependsOn[p[1]] = list;
            }

            list.Add(p[0]);
        }

        // Check each course for cycles
        for (var i = 0; i < numCourses; i++) {
            if (HasCycle(i)) {
                return false; // Cycle detected, cannot finish all courses
            }
        }

        return true; // No cycles, can finish all courses
    }

    private bool HasCycle(int course) {
        if (_state[course] == 1) {
            return true; // Currently visiting this node - cycle detected
        }

        if (_state[course] == 2) {
            return false; // Already visited and no cycle found
        }

        // Mark as visiting
        _state[course] = 1;

        // Visit all dependent courses
        if (_dependsOn.TryGetValue(course, out var dependents)) {
            foreach (var dependent in dependents) {
                if (HasCycle(dependent)) {
                    return true;
                }
            }
        }

        // Mark as visited
        _state[course] = 2;
        return false;
    }
}