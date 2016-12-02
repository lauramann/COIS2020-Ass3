using System;
using System.Collections.Generic;

namespace COIS2020Ass3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			FileSystem cake = new FileSystem();
			//instance of FileSystem class
			FileSystem command = new FileSystem();
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
							command.PrintFileSystem();
							directory = Convert.ToString(Console.ReadLine());
							break;

						//User wants to make a new file
						case 'F':
							string file;
							Console.WriteLine("Where would you like to create your file?");
							//prints file system so user can see where they want to make a new file
							command.PrintFileSystem();
							file = Convert.ToString(Console.ReadLine());
							command.AddFile(ref file);

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
		public string Item { get; set; } //

		//argument for address of file or directory
		public  Node(string item)
		{
			Item = item;
		}

		public Node()
		{
		}

		//returns files list so the other class can access it
		public List<string> GetList()
		{
			return files;
		}

	}

	public class FileSystem
	{
		//creates instance of Node class
		Node fileSystem = new Node();
		//reference to the root of the file system
		private Node root { get; set; }

		//Creates a file system with a root directory
		public FileSystem()
		{
			//creates new list for files 
			List<string> files = fileSystem.GetList(); //create list to access list created in Node
			files.Add("dexter");
		}

		//adds a file at the given address
		//returns false if the file already exists or the path is undefined; true otherwise
		public bool AddFile(ref string address)
		{
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
			Node curr;
			bool inserted = false;
			if (root == null)
			{
				root = new Node(address);
				inserted = true;
			}
			return inserted;
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
