using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue2 {
	private int size;
	private SortedDictionary<int, Stack<SearchNode>> data;

	public int Count { get { return size; } }

	public PriorityQueue2()
	{
		size = 0;
		data = new SortedDictionary<int, Stack<SearchNode>> ();
	}

	public void Add(SearchNode s, int n)
	{
		if (data.ContainsKey (n)) {
			data [n].Push (s);
		} else {
			Stack<SearchNode> stack = new Stack<SearchNode> ();
			stack.Push (s);
			data [n] = stack;
		}

		size++;
	}

	public SearchNode PopFirst()
	{
		foreach (Stack<SearchNode> stack in data.Values) {
			if (stack.Count > 0) {
				size--;
				return stack.Pop ();
			}
		}

		return null;
	}
}
