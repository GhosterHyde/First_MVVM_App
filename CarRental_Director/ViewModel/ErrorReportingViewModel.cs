namespace CarRental_Director.ViewModel
{
    public class ErrorReportingViewModel
    {
        public string Message { get; set; }
        public ErrorReportingViewModel(string message)
        {
            Message = message;
        }
    }
}
