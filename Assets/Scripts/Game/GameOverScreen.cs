using System;

public class GameOverScreen : Window
{
    public event Action RestartButtonPressed;
    
    protected override void OnButtonClick()
    {
        RestartButtonPressed?.Invoke();
    }
}
