using System;
using System.Collections;
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
				Console.WriteLine("Enter any of the following commands:");
				string str = "D to make a NEW directory@F to make a NEW file@P to REMOVE a directory@R to REMOVE a file@N to see the TOTAL number of files@Q to QUIT";
				//replaces @ symbols with new lines for nicer display
				str = str.Replace("@", Environment.NewLine);
				Console.WriteLine(str);
				userInput = char.ToUpper(Convert.ToChar(Console.ReadLine()));
				if (userInput != 'D' && userInput != 'F' && userInput != 'P' && userInput != 'R' && userInput != 'N' && userInput != 'Q')
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
							command.AddDirectory(directory);
							break;

						//User wants to make a new file
						case 'F':
							string file;
							Console.WriteLine("Where would you like to create your file?");
							//prints file system so user can see where they want to make a new file
							command.PrintFileSystem();
							//seperates address so there are no slashes
							file = Convert.ToString(Console.ReadLine());
							command.AddFile(file);
							break;

							//User wants to delete a directory
						case 'P':
							string removedirectory;
							Console.WriteLine("Please enter the directory to remove:");
							//prints file system so user can see where they want to delte a directory
							command.PrintFileSystem();
							removedirectory = Convert.ToString(Console.ReadLine());
							//seperates address so there are no slashes
							command.RemoveDirectory(removedirectory);
							break;

							//User wants to delete a file
						case 'R':
							string removefile;
							Console.WriteLine("Please enter the file to remove:");
							//prints file system so user can see where they want to delte a directory
							command.PrintFileSystem();
							removefile= Convert.ToString(Console.ReadLine());
							//seperates address so there are no slashes
							command.RemoveFile(removefile);
							break;

							//User wants to see the number of files
						case 'N':
							command.NumberFiles();
							break;
					}
				}
			}
			//quits program when user enters Q for quit
			while (userInput != 'Q');

		}
	}

	public class Node
	{
		public string directory; //directory variable
		public List<string> files; //need to  define List somewhere else by saying file = new List<string>
		public Node leftMostChild { get; set; } //left most child variable used throughout program
		public Node rightMostSibling { get; set; } //right most sibling variable used throughout program
		public string Item { get; set; } //to store information within node



		//argument for address of file or directory
		public Node(string item)
		{
			Item = item;
			leftMostChild = rightMostSibling = null;
			files = new List<string>();
		}
	}

	public class FileSystem
	{
		//reference to the root of the file system
		private Node root { get; set; }
		public int numFiles = 0;

		//method to put address into string and remove slashes
		public string[] Seperator(string s)
		{
			char[] slashes = new char[] { '/' };
			//This will separate all the words with slashes
			string[] words = s.Split(slashes, StringSplitOptions.RemoveEmptyEntries);

			//printing used for testing
			//foreach (string word in words)
			//{
			//	Console.WriteLine(word);
			//}
			return words;
		}

		//Creates a file system with a root directory
		public FileSystem()
		{
			root = new Node("/");    // Empty BST
		}

		//adds a file at the given address
		//returns false if the file already exists or the path is undefined; true otherwise
		public bool AddFile(string address)
		{
			//separates address into an array of the different sections of the address
			string[] seperatedAddress = Seperator(address);

			//sets the current node to the root (because you can't change the root)
			Node curr = root;
			//Console.WriteLine(curr.Item);

			//runs through the indexes in the array except the last one (the new directory)
			for (int i = 0; i < seperatedAddress.Length-1; i++)
			{
				if (curr.leftMostChild != null)
				{
					//sets the current node to the left most child
					curr = curr.leftMostChild;
					//Console.WriteLine(curr.Item);
					if (curr.Item != seperatedAddress[i])
					{
						while (curr.rightMostSibling != null)
						{
							curr = curr.rightMostSibling;
							if (curr.Item == seperatedAddress[i])
								break;
						}
					}
				}
				else { }
			}
			curr.files.Add(seperatedAddress[seperatedAddress.Length - 1]);
			//increases the numfiles counter by 1
			numFiles++;
			return true;
		}

		public string PrintFileList(Node node)
		{
			string a = "";
			foreach (string sheet in node.files)
			{
				a = a + sheet + "\n";
			}
			return a;
		}

		//removes the file at the given address
		//Returns flase if the file is not found or the path is undefined; true otherwise
		public bool RemoveFile(string address)
		{
			//separates address into an array of the different sections of the address
			string[] seperatedAddress = Seperator(address);

			//sets the current node to the root (because you can't change the root)
			Node curr = root;
			//Console.WriteLine(curr.Item);

			//runs through the indexes in the array except the last one (the new directory)
			for (int i = 0; i < seperatedAddress.Length - 1; i++)
			{
				if (curr.leftMostChild != null)
				{
					//sets the current node to the left most child
					curr = curr.leftMostChild;
					//Console.WriteLine(curr.Item);
					if (curr.Item != seperatedAddress[i])
					{
						while (curr.rightMostSibling != null)
						{
							curr = curr.rightMostSibling;
							if (curr.Item == seperatedAddress[i])
								break;
						}
					}
				}
				else { }
			}
			//removes the file at the current node
			curr.files.Remove(seperatedAddress[seperatedAddress.Length - 1]);
			//decreases the numfiles counter by 1
			numFiles--;
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
			//Console.WriteLine(curr.Item);

			//runs through the indexes in the array except the last one (the new directory)
			for (int i = 0; i < seperatedAddress.Length; i++)
			{
				if (curr.leftMostChild != null)
				{
					//sets the current node to the left most child
					curr = curr.leftMostChild;
					//Console.WriteLine(curr.Item);
					if (curr.Item != seperatedAddress[i])
					{
						while (curr.rightMostSibling != null)
						{
							curr = curr.rightMostSibling;
							if (curr.Item == seperatedAddress[i])
							{
								curr.rightMostSibling = new Node(seperatedAddress[seperatedAddress.Length - 1]);
								Console.WriteLine(curr.Item);
								break;
							}
						}
					}
					else {}
				}
				else
				{
					curr.leftMostChild = new Node(seperatedAddress[seperatedAddress.Length - 1]);
					//Console.WriteLine(curr.Item);
					//curr = curr.leftMostChild;
				}
			}
					//curr = new Node(seperatedAddress[seperatedAddress.Length-1]);
			return true;
		}

		//removes the directory (and its subdirectories) at the given address
		//Returns flase if the directory is not found or the path is undefined; true otherwise
		public bool RemoveDirectory(string address)
		{
			//separates address into an array of the different sections of the address
			string[] seperatedAddress = Seperator(address);

			//sets the current node to the root (because you can't change the root)
			Node curr = root;
			//Console.WriteLine(curr.Item);

			//runs through the indexes in the array except the last one (the new directory)
			for (int i = 0; i < seperatedAddress.Length; i++)
			{
				if (curr.leftMostChild != null)
				{
					//sets the current node to the left most child
					curr = curr.leftMostChild;
					//Console.WriteLine(curr.Item);
					if (curr.Item != seperatedAddress[i])
					{
						while (curr.rightMostSibling != null)
						{
							curr = curr.rightMostSibling;
							if (curr.Item == seperatedAddress[i])
								break;
						}
					}
				}
				else { }
			}
			//sets 
			curr.Item = null;
			return true;
		}

		//returns the number of files in the file system
		public int NumberFiles()
		{
			Console.WriteLine(numFiles);
			return numFiles;
		}

		//prints the directories in a pre-order fashion along with their files
		public void PrintFileSystem()
		{
			//calls TraverseSystem method
			Console.WriteLine(TraverseSystem());
		}

		//method to call recursive method that traverses through file system
		public string TraverseSystem()
		{
			//passes root and 0
			return preorderString(root, 0);
		}

		//method to traverse through file system
		public string preorderString(Node currentNode, int depth)
		{
			//returns nothing if current node is null
			if (currentNode == null)
			{
				return "";
			}
			string s = "";
			//adds a space before each directory to make it easier to read the file system
			for (int i = 0; i < depth; i++)
			{
				s = s + " ";

			}
			//recursively calls left child and right sibling on new lines
			return s + currentNode.Item + "\n" + s + PrintFileList(currentNode) +
								  preorderString(currentNode.leftMostChild, depth + 1) +
								  preorderString(currentNode.rightMostSibling, depth);
		}

	}
}
