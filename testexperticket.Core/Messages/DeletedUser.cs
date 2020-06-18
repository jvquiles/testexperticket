namespace testexperticket.Core.Messages
{
    public class DeletedUser
    {
        public int Id { get; set; }
        
        public DeletedUser(int id)
        {
            Id = id;
        }
    }
}