
class Scripture {

    private string _verse;

    private List<Word> _words;

    private Reference _reference;

    public Scripture(string verse, Reference reference ) {
        _verse = verse;
        _reference = reference;
        _words = ParseVerse();

    }

    public void DisplayScripture() {
        foreach(Word word1 in _words){
            Console.Write(word1.GetText());
            Console.Write(" ");
        }

    }

    public bool CheckHidden() {
        foreach(Word word2 in _words ){
            if (word2.IsHidden() == false) {
                return false;
                }
            }
        return true;
    }
    
    public List<Word> ParseVerse() {

        String[] _words = _verse.Split(" ",StringSplitOptions.RemoveEmptyEntries);


        List<Word> wordList = new List<Word>(); 

        foreach(string letters in _words) {

            Word word = new Word(letters);
            wordList.Add(word);

        }

        return wordList;
    }

    public void Remove3Words () {
        
        for (int i = 0; i <3; i++) {
            Random randomWord = new Random();
            int randomNumber = randomWord.Next(_words.Count);
            _words[randomNumber].Hide();


        }
       
    }
}