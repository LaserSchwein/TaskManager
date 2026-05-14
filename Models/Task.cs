using System;

class Task
{
    public int ID{get;}
    public string Name {get;} = "Unknown";
    public ExecutionStatus Status{get; private set;}
    public string Description{get; private set;} = "Empty";
    
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

    public void UpdateStatus(ExecutionStatus status)
    {
        this.Status = status;
    }

    public void AddOrChangeDesription(string desription)
    {
        this.Description = desription;
    }

    public override string ToString()
    {
        return $"{this.ID} {this.Name} {this.Status} {this.Description}";
    }
}