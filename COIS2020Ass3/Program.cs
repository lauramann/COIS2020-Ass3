using System;
using System.Collections.Generic;

namespace COIS2020Ass3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//instance of FileSystem class
			FileSystem print = new FileSystem();
			//userInput variable outside of loop
			char userInput;
			//main loop so user can keep adding new directories and files until they press quit
			do
			{
				//asks user what they want to do
				Console.WriteLine("Press D to create a new directory, press F to create a new file. Press Q anytime to quit:");
				userInput = char.ToUpper(Convert.ToChar(Console.ReadLine()));
				if (userInput != 'D' && userInput != 'F' && userInput != 'Q')
					Console.WriteLine("Invalid input, try again");
				else
				{
					//determines which action to do based on what the user has put in
					switch (userInput)
					{
						//User wants to make a new directory
						case 'D':
							string directory;
							Console.WriteLine("Where would you like to create your directory?");
							//prints file system so user can see where they want to make a new directory
							print.PrintFileSystem();
							directory = Convert.ToString(Console.ReadLine());
							break;

						//User wants to make a new file
						case 'F':
							string file;
							Console.WriteLine("Enter the name of your file:");
							Console.WriteLine("Where would you like to create your file?");
							//prints file system so user can see where they want to make a new file
							print.PrintFileSystem();
							file = Convert.ToString(Console.ReadLine());
							break;
					}
				}
			}
			//quits program when user enters Q for quit
			while (userInput != 'Q');

		}
	}

	class Node
	{
		public string directory;
		private List<string> files; //need to define List somewhere else by saying file = new List<string>
		public Node leftMostChild;
		public Node rightMostSibling;

		public List<string> GetList()
		{
			return files;
		}

	}

	public class FileSystem
	{
		Node fileSystem = new Node();
		private Node root = null; //empty root

		//Creates a file system with a root directory
		public FileSystem()
		{
			Node tempVar = new Node(); //create new instance of the Node class
			List<string> files = fileSystem.GetList(); //create list to access list created in Node


		}

		//adds a file at the given address
		//returns false if the file already exists or the path is undefined; true otherwise
		public bool AddFile(string address)
		{
			if (root = null)
				
			
			return true;
		}

		//removes the file at the given address
		//Returns flase if the file is not found or the path is undefined; true otherwise
		public bool RemoveFile(string address)
		{
			return true;
		}

		//adds a directory at the given address
		//returns false if the directory already exists or the path is undefined; true otherwise
		public bool AddDirectory(string address)
		{
			return true;
		}

		//removes the directory (and its subdirectories) at the given address
		//Returns flase if the directory is not found or the path is undefined; true otherwise
		public bool RemoveDirectory(string address)
		{
			return true;
		}

		//returns the number of files in the file system
		public int NumberFiles()
		{
			return 0;
		}

		//prints the directories in a pre-order fashion along with their files
		public void PrintFileSystem()
		{
			Console.WriteLine("hello world");
		}
	}
}
