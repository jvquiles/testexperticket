namespace testexperticket.Core.Messages
{
    public class UpdatedUser
    {
        public int Id { get; set; }
        
        public UpdatedUser(int id)
        {
            Id = id;
        }
    }
}