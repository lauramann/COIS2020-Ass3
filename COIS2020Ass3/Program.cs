using System;

namespace COIS2020Ass3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
		}
	}

	class Node
	{
		public string directory;
		public List<string> file; //need to define List somewhere else by saying file = new List<string>
		public Node leftMostChild;
		public Node rightMostSibling;

	}

	public class FileSystem
	{
		private Node root;

		//Creates a file system with a root directory
		public FileSystem()
		{
		}

		//adds a file at the given address
		//returns false if the file already exists or the path is undefined; true otherwise
		public bool AddFile(string address)
		{
		}

		//removes the file at the given address
		//Returns flase if the file is not found or the path is undefined; true otherwise
		public bool RemoveFile(string address)
		{
		}

		//adds a directory at the given address
		//returns false if the directory already exists or the path is undefined; true otherwise
		public bool AddDirectory(string address)
		{
		}

		//removes the directory (and its subdirectories) at the given address
		//Returns flase if the directory is not found or the path is undefined; true otherwise
		public bool RemoveDirectory(string address)
		{
		}

		//returns the number of files in the file system
		public int NumberFiles()
		{
		}

		//prints the directories in a pre-order fashion along with their files
		public void PrintFileSystem()
		{
		}

}
