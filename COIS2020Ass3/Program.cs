using System;
using System.Collections.Generic;

namespace COIS2020Ass3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
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
							Console.WriteLine("Please enter the path of your new directory");
							//prints file system so user can see where they want to make a new directory
							command.PrintFileSystem();
							directory = Convert.ToString(Console.ReadLine());
							//seperates address so there are no slashes
							command.Seperator(directory);
							break;

						//User wants to make a new file
						case 'F':
							string file;
							Console.WriteLine("Where would you like to create your file?");
							//prints file system so user can see where they want to make a new file
							command.PrintFileSystem();
							//seperates address so there are no slashes
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
		private List<string> files; //need to  define List somewhere else by saying file = new List<string>
		public Node leftMostChild;
		public Node rightMostSibling;
		public string Item { get; set; } //

		//argument for address of file or directory
		public  Node(string item)
		{
			Item = item;
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
		//Node fileSystem = new Node("/");
		//reference to the root of the file system
		private Node root { get; set; }

		//public FileSyste DirectoryTree()
		//{
		//	root = new Node("/");    // Empty BST
		//}

		public string[] Seperator(string s)
		{
			//This will separate all the words with slashes
			string[] words = s.Split('/');
			foreach (string word in words)
			{
				Console.WriteLine(word);
			}
			return words;
		}

		//Creates a file system with a root directory
		public FileSystem()
		{
			root = new Node("/");    // Empty BST
			//creates new list for files 
			List<string> files = root.GetList(); //create list to access list created in Node
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
			//separates address into an array of the different sections of the address
			string[] seperatedAddress = Seperator(address);
			//sets the current node to the root (because you can't change the root)
			Node curr = root;

			//runs through the indexes in the array except the last one (the new directory)
			for (int i = 0; i < address.Length - 1; i++)
			{
				if (curr.leftMostChild != null)
				{
					//sets the current node to the left most child
					curr = curr.leftMostChild;
					if (curr.Item == seperatedAddress[i]) ;
					else
					{
						while (curr != null)
						{
							curr = curr.rightMostSibling;
							if (curr.Item == seperatedAddress[i])
								break;
						}
					}
				}
				else
					return false;
			}
			curr = new Node(seperatedAddress[seperatedAddress.Length-1]);
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
			string message = "/print/me/please/";
			Console.WriteLine(message);

		}
	}
}
