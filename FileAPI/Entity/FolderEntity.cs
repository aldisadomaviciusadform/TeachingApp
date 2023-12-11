namespace FileAPI.Entity
{
    public class FolderEntity
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }
}
