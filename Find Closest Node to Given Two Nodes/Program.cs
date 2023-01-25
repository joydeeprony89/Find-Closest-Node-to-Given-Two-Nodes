// See https://aka.ms/new-console-template for more information
var edges = new int[] { 2, 0, 0 };
int node1 = 2;
int node2 = 0;
Solution s = new Solution();
var answer = s.ClosestMeetingNode(edges, node1, node2);
Console.WriteLine(answer);

public class Solution
{
  public int ClosestMeetingNode(int[] edges, int node1, int node2)
  {
    var length = edges.Length;
    int ans = -1;

    var dist1 = new int[length];
    var dist2 = new int[length];

    var visited1 = new bool[length];
    var visited2 = new bool[length];

    Dfs(node1, visited1, dist1);
    Dfs(node2, visited2, dist2);
    void Dfs(int node, bool[] visited, int[] distance)
    {
      visited[node] = true;
      var neigh = edges[node];
      if (neigh != -1 && !visited[neigh])
      {
        distance[neigh] = distance[node] + 1;
        Dfs(neigh, visited, distance);
      }
    }

    int min = int.MaxValue;
    for (int node = 0; node < length; node++)
    {
      int max = Math.Max(dist1[node], dist2[node]);
      if (visited1[node] && visited2[node] && max <= min)
      {
        // When previous and current max are same we need to set ans as the minimum of node index
        // " If there are multiple answers, return the node with the smallest index"
        if (min == max)
        {
          ans = Math.Min(node, ans);
        }
        else
        {
          min = max;
          ans = node;
        }
      }
    }
    return ans;
  }
}
