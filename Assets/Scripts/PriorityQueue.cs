using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue {
	private int size;
	private SortedDictionary<int, Queue<SearchNode>> data;

	public int Count { get { return size; } }

	public PriorityQueue()
	{
		size = 0;
		data = new SortedDictionary<int, Queue<SearchNode>> ();
	}

	public void Add(SearchNode s, int n)
	{
		if (data.ContainsKey (n)) {
			data [n].Enqueue (s);
		} else {
			Queue<SearchNode> q = new Queue<SearchNode> ();
			q.Enqueue (s);
			data [n] = q;
		}

		size++;
	}

	public SearchNode PopFirst()
	{
		foreach (Queue<SearchNode> q in data.Values) {
			if (q.Count > 0) {
				size--;
				return q.Dequeue ();
			}
		}

		return null;
	}
}
