using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Defines the contract for all troubleshooter tools.
    /// Each tool represents a specific action button in the UI.
    /// </summary>
    public interface ITroubleshooterTool
    {
        /// <summary>
        /// The name of the tool, which will be displayed on the process button.
        /// </summary>
        string ToolName { get; }

        /// <summary>
        /// Performs the search operation based on the provided UI filters.
        /// </summary>
        /// <param name="parameters">An object containing all filter values from the UI.</param>
        /// <returns>A DataTable containing the search results to be displayed in the grid.</returns>
        Task<DataTable> SearchAsync(ToolParameters parameters);

        /// <summary>
        /// Executes the main logic of the tool on the selected data.
        /// </summary>
        /// <param name="selectedRows">A collection of DataRow objects that the user has selected in the grid.</param>
        /// <returns>A ProcessResult object summarizing the outcome of the operation.</returns>
        Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters);
    }
}
