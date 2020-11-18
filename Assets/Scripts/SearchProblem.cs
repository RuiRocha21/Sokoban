using UnityEngine;
using System.Collections;


public struct Successor
{
	public object state;
	public float cost;
	public Action action;


	public Successor(object state, float cost, Action a)
	{
		this.state = state;
		this.cost = cost;
		this.action = a;
	}
}

public delegate float Heuristic(object state);

public interface ISearchProblem
{
	object GetStartState ();
	bool IsGoal (object state);

    int getHeuristica1(object state);
    double getHeuristica2(object state);
    double getHeuristica3(object state);
    double getHeuristica4(object state);

    Successor[] GetSuccessors (object state);

	ulong GetVisited ();
	ulong GetExpanded ();
}
