namespace Todo.Domain.Entity.Item;

public class Item {
    public int ItemId {get; set;}
    public string? Title {get; set;} = string.Empty;
    public string? Description {get; set;} = string.Empty;
    public bool IsFinished {get; set;} 
}
