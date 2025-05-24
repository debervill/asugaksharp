namespace asugaksharp.Model
{
    public class Docs
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsUploaded { get; set; }
        public string Data { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public Person? Person { get; set; }


    }
}
