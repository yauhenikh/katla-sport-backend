using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StaffManagement
{
    /// <summary>
    /// Represents a document service.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Gets a list of documents.
        /// </summary>
        /// <returns>A <see cref="Task{List{DocumentListItem}}"/>.</returns>
        Task<List<DocumentListItem>> GetDocumentsAsync();

        /// <summary>
        /// Gets a document with specified identifier.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <returns>A <see cref="Task{Document}"/>.</returns>
        Task<Document> GetDocumentAsync(int documentId);

        /// <summary>
        /// Gets a list of documents for specified employee.
        /// </summary>
        /// <param name="employeeId">An employee identifier.</param>
        /// <returns>A <see cref="Task{List{DocumentListItem}}"/>.</returns>
        Task<List<DocumentListItem>> GetDocumentsAsync(int employeeId);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateDocumentRequest"/>.</param>
        /// <returns>A <see cref="Task{Document}"/>.</returns>
        Task<Document> CreateDocumentAsync(UpdateDocumentRequest createRequest);

        /// <summary>
        /// Creates a new document with file.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateDocumentRequest"/>.</param>
        /// <param name="filePath">A path to a file.</param>
        /// <returns>A <see cref="Task{Document}"/>.</returns>
        Task<Document> CreateDocumentWithFileAsync(UpdateDocumentRequest createRequest, string filePath);

        /// <summary>
        /// Updates an existed document.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateDocumentRequest" />.</param>
        /// <returns>A <see cref="Task{Document}"/></returns>
        Task<Document> UpdateDocumentAsync(int documentId, UpdateDocumentRequest updateRequest);

        /// <summary>
        /// Updates an existed document with file.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateDocumentRequest" />.</param>
        /// <param name="filePath">A path to a file.</param>
        /// <returns>A <see cref="Task{Document}"/></returns>
        Task<Document> UpdateDocumentWithFileAsync(int documentId, UpdateDocumentRequest updateRequest, string filePath);

        /// <summary>
        /// Deletes an existed document.
        /// </summary>
        /// <param name="documentId">A document identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteDocumentAsync(int documentId);
    }
}
