using FluentValidation.Attributes;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a request for creating and updating a document.
    /// </summary>
    [Validator(typeof(UpdateDepartmentRequestValidator))]
    public class UpdateDocumentRequest
    {
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

        /// <summary>
        /// Gets or sets a document data.
        /// </summary>
        public byte[] DocumentData { get; set; }
    }
}
