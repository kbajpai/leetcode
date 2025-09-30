namespace Leetcode {
    public abstract class KeysAndRooms {
        /*
        Pseudocode (detailed plan):
        - Validate input:
            - If `rooms` is null => return false (invalid input).
            - Let `n = rooms.Count`.
            - If `n <= 1` => return true (0 or 1 room is trivially visitable).
        - Prepare state for recursive DFS:
            - Create a boolean array `visited` of size `n`, all false.
            - Create an integer `visitedCount` initialized to 0.
        - Define a local recursive function `void Dfs(int room)` that:
            - Marks `visited[room] = true`.
            - Increments `visitedCount`.
            - Iterates each `key` in `rooms[room]`:
                - If `key` is out of range (<0 or >= n), skip it (defensive).
                - If `visited[key]` is false, call `Dfs(key)`.
            - Return when all reachable keys from this room are processed.
        - Start recursion by calling `Dfs(0)` (room 0 is initially open).
        - After recursion finishes, compare `visitedCount` with `n`:
            - If equal, all rooms were visited => return true.
            - Otherwise => return false.
        - This approach uses recursive DFS, avoids stacks/queues,
          and preserves the defensive checks present in the original code.
        */

        public static bool CanVisitAllRooms(IList<IList<int>> rooms) {
            var n = rooms.Count;

            if (n <= 1) {
                return true;
            }

            var visited = new bool[n];
            var visitedCount = 0;

            DFS(0);
            return visitedCount == n;

            void DFS(int room) {
                // mark current room visited and count it
                visited[room] = true;
                visitedCount++;

                var keys = rooms[room];

                foreach (var key in keys) {
                    if (key < 0 || key >= n) {
                        continue; // defensive: ignore invalid keys
                    }

                    if (!visited[key]) {
                        DFS(key);
                    }
                }
            }
        }
    }
}