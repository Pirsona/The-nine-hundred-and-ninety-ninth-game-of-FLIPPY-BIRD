using System;

public class StartScreen : Window
{
    public event Action PlayButtonPressed;
    
    protected override void OnButtonClick()
    {
        PlayButtonPressed?.Invoke();
    }
}