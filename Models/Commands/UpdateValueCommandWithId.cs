namespace MediatorPatternExample.Models.Commands
{
    public class UpdateValueCommandWithId : UpdateValueCommand
    {
        public int Id { get; set; }
    }
}
