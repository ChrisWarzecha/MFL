using System;

[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class CC : Attribute
{
    private string _help;
    
    // Constructor 
    public CC() 
    { 
        _help = "help absent";
    } 
    
    // Constructor 
    public CC( string help) 
    { 
        _help = help;
    }
    
    public string Help()
    {
        return _help;
    }
    
}
