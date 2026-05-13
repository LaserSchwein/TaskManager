using System;

class Task
{
    public int ID{get;}
    public string Name {get;} = "Unknown";
    public ExecutionStatus Status{get; private set;}
    public string Description{get; } = "Empty";
    
    public Task()
    {
        
    }
    public Task(int id, string name, ExecutionStatus status, string description)
    {
        ID = id;
        Name = name;
        Status = status;
        Description = description;
    }

    public override string ToString()
    {
        return $"{this.ID} {this.Name} {this.Status} {this.Description}";
    }
}