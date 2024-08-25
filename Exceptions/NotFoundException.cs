namespace HumanResource.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(){}
        public NotFoundException(string message) : base(message) {}
        public NotFoundException(string message, Exception innerexception) : base(message, innerexception) {}
    }
}