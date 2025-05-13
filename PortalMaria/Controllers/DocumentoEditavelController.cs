using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;

public class DocumentoEditavelController : Controller
{
    private readonly IConverter _converter;

    public DocumentoEditavelController(IConverter converter)
    {
        _converter = converter;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GeneratePdf(string htmlContent)
    {
        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = {
                PaperSize = DinkToPdf.PaperKind.A4,
                Orientation = DinkToPdf.Orientation.Portrait
            },
            Objects = {
                new ObjectSettings()
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
        };

        var pdf = _converter.Convert(doc);
        return File(pdf, "application/pdf", "documento.pdf");

    }
}
