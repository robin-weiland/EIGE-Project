using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerCommand> fixedCommands = new List<PlayerCommand>();
    private List<PlayerCommand> commands = new List<PlayerCommand>();
    private List<PlayerDualCommand> dualCommands = new List<PlayerDualCommand>();
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

    private void Update()
    {
        foreach (PlayerCommand command in commands)
        {
            if (command.enabled) command.run(this);
        }
    }

    void FixedUpdate()
    {
        foreach (PlayerCommand command in fixedCommands)
        {
            if (command.enabled) command.run(this);
        }
        foreach (PlayerDualCommand command in dualCommands)
        {
            if (command.enabled) command.fixedRun(this);
        }
        if (properties.currentOrb != null) properties.currentOrb.mechanic.holdingUpdate(this);
    }

    private void registerCommand(PlayerCommand command, bool isFixed = true)
    {
        if (isFixed) fixedCommands.Add(command);
        else commands.Add(command);
    }

    private void registerCommand(PlayerDualCommand command)
    {
        commands.Add(command);
        dualCommands.Add(command);
    }

    public PlayerCommand getCommand<T>()
    {
        foreach (PlayerCommand command in commands)
        {
            if (typeof(T).IsInstanceOfType(command)) return command;
        }
        foreach (PlayerCommand command in fixedCommands)
        {
            if (typeof(T).IsInstanceOfType(command)) return command;
        }
        return null;
    }
}
