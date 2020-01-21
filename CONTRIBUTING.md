# Welcome
This is the contribution page

# General
It is recommended to write a brief summary of the most important
changes in the [changelog](/changelog.txt) in  the Format:

    [name]
    - did something
    - and another thing
    
 It is also a good idea to take a look after pulling.
        

# Assets

## Scripts
### Style Conventions
Generally we try to lean towards the [c# conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

### Player
 - **PlayerMovement** can be implemented by creating a new sript implementing the [inteface](EIGE-Project/Assets/Scripts/PlayerCommand.cs)
 
### Camera
 - **CameraShake** by calling CameraShake.Shake(duration, amount); staticly from anywhere
 
 
### Misc
 - **Measure Distances** by attaching DistanceMeasurement to an object and set its paramenters or call DistanceMeasurement.Get(gameobject, gameobject); to get distances on the fly
 
- **Fade in and out of scenes** by bringing the SceneFade prefab into your scene and setting the time values in the inspector (you might wanna disable the in-editor-view in the hierarchy panel since the prefab will block your view :D)


## Sprites

