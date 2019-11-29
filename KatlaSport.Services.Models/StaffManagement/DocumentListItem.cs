namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a document related to the employee.
    /// </summary>
    public class DocumentListItem
    {
        /// <summary>
        /// Gets or sets a document ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a filename.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets an ID of the employee the document belongs to.
        /// </summary>
        public int EmployeeId { get; set; }
    }
}
