using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace PersonalAssistant
{
	class Program
	{
		public static bool endProgram = false;

		static void Main(string[] args)
		{
			/*Start a Thread to Recognize Speech*/
			Thread speechRec = new Thread(RecognizeSpeech.RunSpeech);
			speechRec.Start();

			/*Start a Thread to Interpreate The Speech*/
			Thread interpSpeech = new Thread(UseSpeech.InterpretSpeech );
			interpSpeech.Start();

			System.Threading.SpinWait.SpinUntil(() => endProgram);

			speechRec.Abort();
			interpSpeech.Abort();


			return;
		}
	}
}
