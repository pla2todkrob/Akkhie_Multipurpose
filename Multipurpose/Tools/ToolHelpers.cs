namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// A data transfer object (DTO) to pass filter values from the UI to a tool.
    /// </summary>
    public class ToolParameters
    {
        public string ManifestDocNo { get; set; }
        public string QuotationSource { get; set; }
        public string QuotationDestination { get; set; }
        public string JobNo { get; set; }
        public string CreditNoteNo { get; set; }
    }

    /// <summary>
    /// A data transfer object (DTO) to return the results of a processing operation from a tool to the UI.
    /// </summary>
    public class ProcessResult
    {
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }
        public string Message { get; set; }
    }
}
