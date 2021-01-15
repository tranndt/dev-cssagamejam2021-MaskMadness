using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    PlayButton,
    OptionButton,
    QuitButton,
    TaskListButton
}

[RequireComponent(typeof(Button))]
public class Canvas_Switcher : MonoBehaviour
{

    Canvas_Manager canvasManager;
    Button menuButton;
    public ButtonType buttonType;
    
    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButon.onClick.AddListener(OnButtonClicked);
        canvasManager = Canvas_Manager.GetInstance();
    }

    void OnButtonClicked()
    {
        switch (buttonType)
	{
	    case ButtonType.PlayButton:
		canvasManager.SwitchCanvas(CanvasType.UserInfo);
               	SceneManager.LoadScene("04_City");
		break;
	    //case ButtonType.OptionButton
	}
    }
        
}
