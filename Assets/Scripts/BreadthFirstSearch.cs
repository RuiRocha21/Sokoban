using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreadthFirstSearch : SearchAlgorithm {

	private Queue<SearchNode> openQueue = new Queue<SearchNode> ();
	private HashSet<object> closedSet = new HashSet<object> ();

    private int tamanhoQueue = 0;

    protected override void Begin () 
	{
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openQueue.Enqueue (start);
	}
	
	protected override void Step()
	{
		if (openQueue.Count > 0)
		{
			SearchNode cur_node = openQueue.Dequeue();
			closedSet.Add (cur_node.state);
            

            if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
                print("tamanho queue  "+ tamanhoQueue);
				finished = true;
				running = false;
			} else {
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				foreach (Successor suc in sucessors) {
					if (!closedSet.Contains (suc.state)) {
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
						openQueue.Enqueue (new_node);
					}
				}
			}
            if (tamanhoQueue < openQueue.Count)
                tamanhoQueue = openQueue.Count;
        }
		else
		{
            finished = true;
			running = false;
		}
	}
}
