using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AprofProgressivo : SearchAlgorithm {
	private Stack<SearchNode> openStack = new Stack<SearchNode> ();
	private SearchNode start;
	private int limite=0;
	private int tamanhostack=0;

	protected override void Begin() 
	{

		start = new SearchNode (problem.GetStartState (), 0);
	}

	protected override void Step()
	{
		if (openStack.Count > 0)
		{
			SearchNode cur_node = openStack.Pop();


			if (problem.IsGoal (cur_node.state)) {
				print ("limite:"+limite);
				print ("espacial:" + tamanhostack);
				solution = cur_node;
				finished = true;
				running = false;
			} else {
				if (cur_node.depth < limite) {
					Successor[] sucessors = problem.GetSuccessors (cur_node.state);
					foreach (Successor suc in sucessors) {
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
						openStack.Push (new_node);
					}
					if (tamanhostack < openStack.Count)
						tamanhostack = openStack.Count;
				}
			}
		}
		else
		{
			openStack.Clear();
			openStack.Push (start);
			limite++;				

		}
	}
}

