namespace MediatorPatternExample.Models.Commands
{
    public class UpdateValueCommand
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public class WithId : UpdateValueCommand
        {
            public int Id { get; set; }
        }
    }
}
