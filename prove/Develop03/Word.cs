class Word{
    private string _letters;

    private bool _isHidden;

    public Word(string letters) {
        _letters = letters;
        _isHidden = false;
    }

    public void Hide() {
        _isHidden = true;

    }   

    public void Show() { 
        _isHidden = false;


    } 

    public bool IsHidden() {

        return _isHidden;
    }



    public string GetText() {

        if (_isHidden) {

            string underscores = "";
            int numLetters = _letters.Length;
            for (int i = 0; i < numLetters; i++) {
                underscores += "_";
            }

            return underscores;
        }
        else {
            return _letters;
        }
    }
}