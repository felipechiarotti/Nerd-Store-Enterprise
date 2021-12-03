namespace NSE.Core.Communication
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Staatus { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }
}
