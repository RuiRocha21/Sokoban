using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AprofProgressivoCortes : SearchAlgorithm {
	private Stack<SearchNode> openStack = new Stack<SearchNode> ();
	private SearchNode start;
	private int limite=0;
	private int tamanhostack=0;
	private HashSet<object> closedSet = new HashSet<object> ();


	protected override void Begin() 
	{
		start = new SearchNode (problem.GetStartState (), 0);
		openStack.Push (start);
	
	}

	protected override void Step()
	{
		if (openStack.Count > 0)
		{
			SearchNode cur_node = openStack.Pop();
			closedSet.Add (cur_node.state);


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
						if (!closedSet.Contains (suc.state)) {
							SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
							openStack.Push (new_node);
						}
					}
					if (tamanhostack < openStack.Count)
						tamanhostack = openStack.Count;
				}
			}
		}
		else
		{
			closedSet.Clear ();
			openStack.Clear();
			openStack.Push (start);
			limite++;				

		}
	}
}

