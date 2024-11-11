public class SelectWordCommand : ICommand
{
    private DogGameController controller;
    private string word;

    public SelectWordCommand(DogGameController controller, string word)
    {
        this.controller = controller;
        this.word = word;
    }

    public void Execute()
    {
        controller.OnWordButtonClicked(word);
    }
}
