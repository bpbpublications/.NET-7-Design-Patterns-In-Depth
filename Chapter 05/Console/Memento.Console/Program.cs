using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SurveyCaretaker caretaker = new();
            Survey originator = new();
            originator.SetAnswer(1, "A");
            originator.SetAnswer(2, "B");
            caretaker.AddMemento(originator.SaveDraft());
            originator.SetAnswer(3, "C");
            caretaker.AddMemento(originator.SaveDraft());
            originator.SetAnswer(4, "D");
            originator.RestoreDraft(caretaker.GetMemento());
            originator.Submit();
            Console.Read();
        }
    }
}
