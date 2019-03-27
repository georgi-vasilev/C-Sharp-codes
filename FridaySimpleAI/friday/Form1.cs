using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace friday
{
	public partial class Form1 : Form
	{
		SpeechSynthesizer s = new SpeechSynthesizer();
		Choices list = new Choices();
		public Form1()
		{
			SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
			Grammar gr = new Grammar(new GrammarBuilder(list));
			s.Speak("Hello. Im friday!");
			s.Speak("How are you my lord?");
			list.Add(new String[] { "hello friday", "open gooogle", "what time is it", "search for" });
			try
			{
				rec.RequestRecognizerUpdate();
				rec.LoadGrammar(gr);
				rec.SpeechRecognized += rec_SpeechRecognized;
				rec.SetInputToDefaultAudioDevice();
				rec.RecognizeAsync(RecognizeMode.Multiple);
			}
			catch
			{
				return;
			}

		}
		public void fridaySpeech(String h)
		{
			s.Speak(h);
		}
		private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			//throw new NotImplementedException();
			String r = e.Result.Text;
			if(r == "hello friday")
			{
				fridaySpeech("how can i help you my lord");
			}
			if (r == "open google")
			{
				Process.Start("http://www.google.com");
			}
			if (r == "what time is it")
			{
				fridaySpeech(DateTime.Now.ToString("h:mm tt"));
			}
			if (r == "search for")
			{

			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}









