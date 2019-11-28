namespace KatlaSport.DataAccess.StaffCatalogue
{
    /// <summary>
    /// Represents a document related to the employee.
    /// </summary>
    public class Document
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
        /// Gets or sets a document data.
        /// </summary>
        public byte[] DocumentData { get; set; }

        /// <summary>
        /// Gets or sets an ID of the employee the document belongs to.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee the document belongs to.
        /// </summary>
        public virtual Employee Employee { get; set; }
    }
}
