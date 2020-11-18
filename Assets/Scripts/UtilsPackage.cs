using System;
using UnityEngine;
using System.IO;
using System.Diagnostics;

// Simple file Logging class
public class SimpleLogger
{
	private StreamWriter fw;

	public SimpleLogger (string path)
	{
		this.fw = File.AppendText (path);
	}

	public void Log (string logMessage, int frame = 1){
		// Get current call stack
		StackTrace stackTrace = new StackTrace();

		// sample: [dd/mm/aaaa hh:mm:ss][<Class>.<Method>]: <LogMessage>
		this.fw.WriteLine("[{0} {1}][{2}.{3}]: {4}",
			DateTime.Now.ToShortDateString(),
			DateTime.Now.ToLongTimeString(),
			stackTrace.GetFrame(frame).GetMethod().ReflectedType.Name,
			stackTrace.GetFrame(frame).GetMethod().Name,
			logMessage);
	}

	// allows the usage of ("teste {0}" ,variable)
	public void Log(string text,params object[] args) {
		 Log(string.Format (text, args), 2);
	}

	public void Flush(){
		this.fw.Flush ();
	}

	public StreamWriter getStream(){
		return fw;
	}

	public void Close(){
		this.fw.Close ();
	}
}


// Helper class to save a List of objects as json
public static class JsonHelper
{
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}

	public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper);
	}

	public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] Items;
	}
}



