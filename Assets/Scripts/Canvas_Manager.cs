using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CanvasType
{
    MainMenu,
    UserInfo,
    OptionsMenu
}

public class Canvas_Manager : Singleton<Canvas_Manager>
{
    List<Canvas_Controller> canvasControllerList;
    Canvas_Controller lastActiveCanvas;

    protected void Awake()
    {
        canvasControllerList = GetComponentsInChildren<Canvas_Controller>().ToList();

        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
         
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType _type)
    {
	if (lastActiveCanvas != null)
        {
	    lastActiveCanvas.gameObject.SetActive(false);
        }

    	Canvas_Controller desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
   	if(desiredCanvas != null)
    	{
	    desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
    	}
        else {Debug.LogWarning("The desired canvas was not found!");} 

    }

}
