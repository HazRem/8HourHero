using System;

public class Character
{
    public int Id { get; private set; }
    //public User Owner { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int ExperienceToLevelUp { get; private set; }
    public Character()
    {

    }
}