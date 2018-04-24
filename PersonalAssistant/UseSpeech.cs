using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssistant
{
	class UseSpeech
	{
		private static string parseMessage = "temp";

		public static void InterpretSpeech()
		{
			while (true)
			{
				/*Wait until recieved message to avoid busy wait*/
				System.Threading.SpinWait.SpinUntil(() => MessagePass.messageHasBeenPassed);
				parseMessage = MessagePass.messagePass;
				MessagePass.messageHasBeenPassed = false;
				if (parseMessage.Contains("computer quit") )
				{
					Program.endProgram = true;
				}
				/*End of Checking for End*/

				/*Check conditions have been met*/


			}

		}

	}
}
