namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a document related to the employee.
    /// </summary>
    public class Document : DocumentListItem
    {
        /// <summary>
        /// Gets or sets a document data.
        /// </summary>
        public byte[] DocumentData { get; set; }
    }
}
