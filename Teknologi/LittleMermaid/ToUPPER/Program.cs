using System;
using System.IO;
using System.Threading.Tasks;

namespace ToUPPER
{

	class Program
	{
		private const string _infilesFolder = "infiles";
		private const string _outfilesFolder = "outfiles";
		private const string _infilenameBasis = _infilesFolder + "\\splitfile"; //fil navn uden tal
		private const string _outfilenameBasis = _outfilesFolder + "\\UPPERsplitfile"; //output fil navn uden tal
		private const string _fileExtension = ".txt"; //data type
		private int _sheepCount = default;
		private bool _jobIsRunning = default;

		static void Main(string[] args)
		{
			Program prog = new Program();
			prog.MainThread();
		}

		private void MainThread()
		{
			int fileCount = Directory.GetFiles(_infilesFolder).Length; // 65 filer
			Console.WriteLine($"Starting job - {fileCount} files");
			Job(fileCount);
			CountSheep();
			//kald countsheep asynkront
			Console.WriteLine("Job is done");
			Console.ReadKey();
		}

		public async void Job(int fileCount)
		{
			_jobIsRunning = true;
			for (int i = 1; i <= fileCount; i++)
			{
				FileInfo fi = new FileInfo(_infilenameBasis + i + _fileExtension);
				int fileSize = (int)fi.Length;
				char[] charbuf = new char[fileSize];

				using (StreamReader sr = fi.OpenText()) 
				{
					await using(StreamWriter sw = File.CreateText(_outfilenameBasis + i + _fileExtension))
					{
						charbuf = sr.ReadToEnd().ToCharArray();

						foreach(char c in charbuf) 
						{
							char test = char.ToUpper(c);
							sw.Write(test);
						}

					}
				}

				#region opgave 3
				//using (StreamReader sr = fi.OpenText()) //åbner fil
				//{
				//	//kontrol tilbage til mainthread 
				//	using (StreamWriter sw = File.CreateText(_outfilenameBasis + i + _fileExtension)) //opretter og skriver ny fil
				//	{
				//		Task t = new Task(() =>
				//		{
				//			//charbuf = sr.ReadAsync(charbuf);
				//			charbuf = sr.ReadToEnd().ToCharArray();
				//		});

				//		t.Start();
				//		t.Wait();

				//		foreach (char c in charbuf)
				//		{
				//			char test = Char.ToUpper(c);
				//			sw.Write(test);
				//		}
				//	}
				//}
				#endregion
			}
			_jobIsRunning = false;
		}

		//rigtig datatype
		private async void CountSheep()
		{//you have to find out what the type XYZ should be…
			int i = 1;
			while (_jobIsRunning)
			{
				Console.WriteLine(i + " sheep");
				i++;
			}

		}
	}
}
