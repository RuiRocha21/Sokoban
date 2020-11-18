using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProfundidadeLimitada : SearchAlgorithm {
	private Stack<SearchNode> openStack = new Stack<SearchNode> ();
	public int limite;
	private int espacial=0;

    protected override void Begin()
        {
		
		
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openStack.Push(start);

	}

    protected override void Step()
    {
		if (openStack.Count > 0)
		{
			SearchNode cur_node = openStack.Pop();


			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
				print ("espacial" + espacial);
			} else {
				if (cur_node.depth < limite) {
					Successor[] sucessors = problem.GetSuccessors (cur_node.state);
					foreach (Successor suc in sucessors) {
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
						openStack.Push (new_node);
					}
					if (openStack.Count > espacial)
						espacial = openStack.Count;
				}
			}
		}
		else
		{
			finished = true;
			running = false;
		}
	}
}

