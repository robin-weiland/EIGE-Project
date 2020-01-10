using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerCommand> fixedCommands = new List<PlayerCommand>();
    private List<PlayerCommand> commands = new List<PlayerCommand>();
    [SerializeField]
    public PlayerProperties properties = new PlayerProperties();
    public Rigidbody2D rigidbody2D { private set; get; }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.freezeRotation = true;
        registerCommand(new PlayerMove());
        registerCommand(new PlayerJump());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (PlayerCommand command in fixedCommands)
        {
            command.run(this);
        }
    }

    private void registerCommand(PlayerCommand command, bool isFixed = true)
    {
        if (isFixed) fixedCommands.Add(command);
        else commands.Add(command);
    }
}
