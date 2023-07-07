using System;
using System.Collections.Generic;
using System.Text;

public class SurveyState
{
    public Dictionary<int, string> Answers { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var item in Answers)
            sb.Append($"Question:{item.Key}, Answer: {item.Value}{Environment.NewLine}");
        return sb.ToString();
    }
}
public class Survey
{
    private class SurveySnapshot : ISurveySnapshot
    {
        private readonly SurveyState _state;
        public SurveySnapshot(SurveyState state) => _state = state;
        public SurveyState Restore() => _state;
    }

    private SurveyState _state = new() { Answers = new() };
    public void Submit() => Console.WriteLine(_state);
    public ISurveySnapshot SaveDraft() => new SurveySnapshot(new SurveyState { Answers = new(_state.Answers) });
    public void RestoreDraft(ISurveySnapshot snapshot) => _state = snapshot.Restore();
    public void SetAnswer(int question, string answer) => _state.Answers.Add(question, answer);
}
public interface ISurveySnapshot
{
    SurveyState Restore();
}
//public class SurveySnapshot
//{
//    private readonly SurveyState _state;
//    public SurveySnapshot(SurveyState state) => _state = state;
//    public SurveyState Restore() => _state;
//}
public class SurveyCaretaker
{
    readonly Stack<ISurveySnapshot> _mementos = new();
    public void AddMemento(ISurveySnapshot snapshot) => _mementos.Push(snapshot);
    public ISurveySnapshot GetMemento() => _mementos.Pop();
}
