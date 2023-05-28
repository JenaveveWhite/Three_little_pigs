
class Reference {
    private string _name;

    private int _chapter;

    private int _verseStartNumber;

    private int _verseEndNumber;

    public Reference(string name, int chapter, int verseStartNumber, int verseEndNumber) {
        _name = name;
        _chapter = chapter;
        _verseStartNumber = verseStartNumber;
        _verseEndNumber = verseEndNumber;
    
    }

    public void DisplayReference() {
        string verse = ($"{_name} {_chapter}:{_verseStartNumber}-{_verseEndNumber}");

        Console.WriteLine($"{verse}");
    }


}