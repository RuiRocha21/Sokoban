using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sofrega2 : SearchAlgorithm {

	private List<SearchNode> openList = new List<SearchNode> ();
	private HashSet<object> closedSet = new HashSet<object> ();
	public int heuristica;
	private int espacial = 0;

	protected override void Begin()
	{
		//problem = GameObject.Find ("Map").GetComponent<Map> ().GetProblem();
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openList.Add(start);
	}

	protected override void Step()
	{
		if (openList.Count > 0)
		{
			SearchNode cur_node = openList[0];
			openList.RemoveAt (0);
			closedSet.Add (cur_node.state);
			if (problem.IsGoal (cur_node.state)) {
				print("espacial:"+espacial);
				solution = cur_node;
				finished = true;
				running = false;
			} else {
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				foreach (Successor suc in sucessors) {
					if (!closedSet.Contains (suc.state)) {
						float h=0;
						if (heuristica == 1) {
							h = (float)problem.getHeuristica1 (suc.state);
						}else if(heuristica==2) {
							h = (float)problem.getHeuristica2 (suc.state);
						}else if(heuristica==3) {
							h = (float)problem.getHeuristica3 (suc.state);
						}else if(heuristica==4) {
							h = (float)problem.getHeuristica4 (suc.state);
						}
						SearchNode new_node = new SearchNode (suc.state, h, suc.action, cur_node);
						openList.Add (new_node);
					}

				}
				insertionSort ();
				if (espacial < openList.Count)
					espacial = openList.Count;


			}
		}
		else
		{
			finished = true;
			running = false;
		}
	}

	public void insertionSort(){
		int i, j;
		SearchNode temp;
		for (i = 1; i < openList.Count; i++) {
			j = i;
			while(j>0&&openList[j].f<openList[j-1].f){
				temp = openList [j];
				openList [j] = openList [j - 1];
				openList [j - 1] = temp;
				j--;
			}
		}

	}
}

