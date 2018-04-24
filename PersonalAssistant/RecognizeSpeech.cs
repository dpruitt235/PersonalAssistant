using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace PersonalAssistant
{
	class RecognizeSpeech
	{
		private static string currMesg = "temp";
		public static void RunSpeech()
		{
			using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US")))
			{

				// Create a grammar for finding services in different cities.
				Choices options = new Choices(new string[] { "what will the weather be like", "play music", "what time is it" , "quit"});

				GrammarBuilder otherSearch = new GrammarBuilder("computer");
				GrammarBuilder searchOptions = new GrammarBuilder(options);

				// Create a Grammar object from the GrammarBuilder and load it to the recognizer.
				Grammar StartingGrammer = new Grammar(otherSearch);
				Grammar OptionsGrammer = new Grammar(searchOptions);

				recognizer.LoadGrammarAsync(StartingGrammer);
				recognizer.LoadGrammarAsync(OptionsGrammer);

				// Add a handler for the speech recognized event.
				recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

				// Configure the input to the speech recognizer.
				recognizer.SetInputToDefaultAudioDevice();

				// Start asynchronous, continuous speech recognition.
				recognizer.RecognizeAsync(RecognizeMode.Multiple);

				// Waits until the message says to kill the program
				System.Threading.SpinWait.SpinUntil(() => currMesg.Contains("quit"));
				return;

			}

		}

		// Handle the SpeechRecognized event.
		static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			Console.WriteLine("Recognized text: " + e.Result.Text);
			currMesg = MessagePass.messagePass = e.Result.Text;
			MessagePass.messageHasBeenPassed = true; //used to wait the other thread
		}
	}
}
