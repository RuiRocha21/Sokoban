using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Options;


public class BatchmodeConfig {

	private static readonly object syncLock = new object();

	public static bool batchmode = false;
	public static int mapNumber = -1;
	public static string algName = "";
	public static string heuristicName = "";
	public static string loggerFilename = "";
	public static string output = "";

	private static bool processed = false;

	public static void HandleArgs(){

		lock (syncLock) 
		{
			if (!processed) {
				// get the list of arguments 
				string[] args = Environment.GetCommandLineArgs ();

				bool show_help = false;

				OptionSet parser = new OptionSet () {
					"Usage: ",
					"",
					{"batchmode", "run in batchmode",
						v => batchmode = v != null
					},
					{"map=", "the number of the {MAP} to use.",
						(int v) => mapNumber = v
					},
					{"search=", "the search algorithm to use.",
					v => algName = v
					},
					{"heuristic=", "the heuristic function to use.",
					v => heuristicName = v
					},
					{"logfile=", "the logger output filename to use.",
						v => loggerFilename = v
					},
					{"solutionfile=", "the solution output filename to use.",
						v => output = v
					},
					{ "h|help",  "show this message and exit", 
					v => show_help = v != null 
					},
				};

				try{
					parser.Parse(args);
					processed = true;
				}
				catch (OptionException e) {
					Console.Write ("sokoban: ");
					Console.WriteLine (e.Message);
					Console.WriteLine ("Try `sokoban --help' for more information.");
					Application.Quit ();
					return;
				}

				if (show_help) {
					parser.WriteOptionDescriptions (Console.Out);
					Application.Quit();
					return;
				}

			}
		}

	}
}
