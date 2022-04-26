class TextDocument{
    private string _currentText;
    private int _pagesNumber;
    public string CurrentText { get => _currentText; }
    public int PagesNumber { get => _pagesNumber; }
    public TextDocument(int numberOfPages, string text)
    {
        _currentText = text;
        _pagesNumber = numberOfPages;
    }
    public void ChangeText(string newText)
    {
        _currentText = newText;
    }
    public IMemento CreateNewMemento()
    {
        return new Memento(_currentText, _pagesNumber);
    }
    public void RestoreFromMemento(IMemento memento)
    {
        _currentText = memento.GetText();
        _pagesNumber = memento.GetPagesNumber();
        Console.WriteLine($"Restored from memento created at {memento.GetDate().ToString()}");
    }
    public interface IMemento
    {
        public DateTime GetDate();
        public string GetText();
        public int GetPagesNumber();
    }
    public class Memento : IMemento
    {
        private string _currentText;
        private int _pagesNumber;
        private DateTime _date;
        public Memento(string text, int pagesNumber)
        {
            _currentText = text;
            _pagesNumber = pagesNumber;
            _date = DateTime.Now;
        }
        public DateTime GetDate()
        {
            return _date;
        }

        public int GetPagesNumber()
        {
            return _pagesNumber;
        }

        public string GetText()
        {
            return _currentText;
        }
    }
}
class TextDocumentCaretaker
{
    private List<TextDocument.IMemento> _history = new List<TextDocument.IMemento>();
    private TextDocument _document;
    public TextDocument TextDocument { get => _document; }
    public TextDocumentCaretaker(TextDocument document)
    {
        _document = document;
    }
    public void CreateBackupCopy()
    {
        Console.WriteLine($"Creating backup for text document");
        _history.Add(new TextDocument.Memento(_document.CurrentText, _document.PagesNumber));
    }
    public void Undo()
    {
        if(_history.Count > 0)
        {
            TextDocument.IMemento m = _history.Last();
            _document.RestoreFromMemento(m);
            _history.Remove(m);
        }
    }
    public void WriteHistory()
    {
        Console.WriteLine("This is the history of our document^");
        foreach (TextDocument.IMemento m in _history)
        {
            Console.WriteLine($"{m.GetDate().ToString()}/{m.GetText()}/{m.GetPagesNumber()}");
        }
    }
}
class Program
{
    static void Main()
    {
        TextDocument doc = new TextDocument(10, "Initial text for document");
        TextDocumentCaretaker caretaker = new TextDocumentCaretaker(doc);
        doc.ChangeText("Text 1");
        caretaker.CreateBackupCopy();
        doc.ChangeText("Text 2");
        caretaker.CreateBackupCopy();
        doc.ChangeText("Text 3");
        caretaker.CreateBackupCopy();
        Console.WriteLine($"Current text is {doc.CurrentText}");
        /////////////////////////////
        caretaker.WriteHistory();
        ////////////////////////////
        caretaker.Undo();
        Console.WriteLine($"1 undo, current text is {doc.CurrentText}");
        caretaker.Undo();
        Console.WriteLine($"2 undo, current text is {doc.CurrentText}");
        caretaker.Undo();
        Console.WriteLine($"3 undo, current text is {doc.CurrentText}");
        caretaker.Undo();
        Console.WriteLine($"4 undo, current text is {doc.CurrentText}");
    }
}