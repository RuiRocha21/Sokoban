using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aasterisco : SearchAlgorithm {

    private PriorityQueue openQueue = new PriorityQueue();
    // private List<SearchNode> openList = new List<SearchNode>();
    private HashSet<object> closedSet = new HashSet<object>();
    private SearchNode start;
    public int heuristica;
    private int maxQueue = 0;

    protected override void Begin() {
        start = new SearchNode(problem.GetStartState(), 0);
        openQueue.Add((SearchNode)start, 0);
        //openList.Add(start);
    }

    protected override void Step()
    {
        
        //if (openList.Count > 0)
        if (openQueue.Count>0)
        {
            //SearchNode cur_node = openList[0];
            SearchNode cur_node = openQueue.PopFirst();
            //openList.RemoveAt(0);
            closedSet.Add(cur_node.state);
            
            if (problem.IsGoal(cur_node.state))
            {

                solution = cur_node;
                finished = true;
                running = false;
                print("maxQueue:" + maxQueue);
            }
            else {
                Successor[] sucessors = problem.GetSuccessors(cur_node.state);
                
                foreach (Successor suc in sucessors)
                {
                    
                    if (!closedSet.Contains(suc.state))
                    {
                        float h = 0;

                        float g = cur_node.g;
                        if (heuristica == 1)
                        {
                            h = (float)problem.getHeuristica1(suc.state);
                        }
                        else if (heuristica == 2)
                        {
                            h = (float)problem.getHeuristica2(suc.state);          
                        }
                        else if (heuristica == 3)
                        {
                            h = (float)problem.getHeuristica3(suc.state);
                        }
                        else if (heuristica == 4)
                        {
                            h = (float)problem.getHeuristica4(suc.state);
                        }
                        if (heuristica > 0 && heuristica<5)
                        {
                            SearchNode new_node = new SearchNode(suc.state, g + h, suc.action, cur_node);
                            openQueue.Add((SearchNode)new_node, new_node.depth);
                        }

                        //print("heuristica  " + h+" fgdf  "+g);
                    }
                }
 
                if (maxQueue < openQueue.Count)
                    maxQueue = openQueue.Count;
            }
        }
        else
        {
            finished = true;
            running = false;
        }
    }

    
}
