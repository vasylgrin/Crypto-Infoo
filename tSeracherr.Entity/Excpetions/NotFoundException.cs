namespace tSeracherr.Entity.Excpetions
{
    public class NotFoundException : Exception
    {
        public string ParamName { get; }
        public NotFoundException(string paramName,string msg) : base(msg) { ParamName = paramName; }
    }
}
