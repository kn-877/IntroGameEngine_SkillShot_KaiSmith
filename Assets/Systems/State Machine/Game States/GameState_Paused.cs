using UnityEngine;

public class GameState_Paused : IGameState
{
    GameManager gameManager => GameManager.Instance;
    BallManager ballManager => GameManager.Instance.BallManager;
    CameraManager cameraManager => GameManager.Instance.CameraManager;
    GameStateManager gameStateManager => GameManager.Instance.GameStateManager;
    InputManager inputManager => GameManager.Instance.InputManager;
    UIManager uIManager => GameManager.Instance.UIManager;


    #region Singleton Instance
    // A single, readonly instance of the atate class is created.
    // The 'readonly' keyword ensures this instance cannot be modified after initialization.
    private static readonly GameState_Paused _instance = new GameState_Paused();

    // Provides global access to the singleton instance of this state.
    // Uses an expression-bodied property to return the static _instance variable.
    public static GameState_Paused Instance => _instance;
    #endregion

    public void EnterState()
    {
        Cursor.visible = true;

        Time.timeScale = 0f;

        cameraManager.DisableCameraOrbit();
        

        // hide all UI Menus
        uIManager.ShowPausedUI();

        // Start Listening for Pause Input to resume
        inputManager.PauseEvent += gameStateManager.Resume;
    }

  
    public void FixedUpdateState() {}
    public void UpdateState() {}
    public void LateUpdateState() { }

    public void ExitState()
    {
        inputManager.PauseEvent -= gameStateManager.Resume;

    }







}
