namespace SimpleQ.Interface.Models.Common
{
    public class Message
    {
        public int Id { get; set; }

        public string DestinationBaseAddress { get; set; }
        public string DestinationHttpUri { get; set; }
        public string DestinationHttpMethod { get; set; }
        public string ContentType { get; set; }
        //public byte[] Content { get; set; }
        public string Content { get; set; }
    }
}