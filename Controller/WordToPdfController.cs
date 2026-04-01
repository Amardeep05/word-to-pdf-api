using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using GemBox.Document;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using SaveOptions = GemBox.Document.SaveOptions;

namespace word_to_pdf_api.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // GemBox version for small files
    [ApiVersion("2.0")] // Syncfusion version for large files
    public class WordToPdfController : ControllerBase
    {
        // Version 1.0 → GemBox (small files)
        [HttpPost("convert")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> ConvertWordToPdfV1Async([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a Word file.");
            try
            {
                // Load Word document from stream
                var document = await Task.Run(() => DocumentModel.Load(file.OpenReadStream()));
                // Save PDF to a memory stream
                using var stream = new MemoryStream();
                document.Save(stream, SaveOptions.PdfDefault);
                return File(stream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + ".pdf");
            }
            catch (Exception ex)
            {
                return BadRequest("Error converting file: " + ex.Message);
            }
        }
        // Version 2.0 → Syncfusion (large files)
        [HttpPost("convert")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> ConvertWordToPdfV2Async([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a Word file.");
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            // Load Word document
            using WordDocument wordDoc = new WordDocument(memoryStream, FormatType.Docx);
            // Convert Word to PDF
            using DocIORenderer renderer = new DocIORenderer();
            using PdfDocument pdfDoc = renderer.ConvertToPDF(wordDoc);
            using MemoryStream pdfStream = new MemoryStream();
            pdfDoc.Save(pdfStream);
            return File(pdfStream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + ".pdf");
        }

    }
}
