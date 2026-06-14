using System.IO;
using iText.Kernel.Pdf;
using iText.Forms;

namespace asugaksharp.Features.Protocol;

public class DiagnoseTemplatesHandler
{
    private static readonly string TemplateDir =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");

    public string Diagnose()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Templates dir: {TemplateDir}");
        sb.AppendLine($"Dir exists: {Directory.Exists(TemplateDir)}");
        sb.AppendLine();

        foreach (var file in Directory.GetFiles(TemplateDir, "*.pdf"))
        {
            sb.AppendLine($"=== {Path.GetFileName(file)} ===");
            try
            {
                using var reader = new PdfReader(file);
                using var pdf = new PdfDocument(reader);
                sb.AppendLine($"  Pages: {pdf.GetNumberOfPages()}");
                var form = PdfAcroForm.GetAcroForm(pdf, false);
                if (form == null)
                {
                    sb.AppendLine("  FORM: null (no AcroForm)");
                }
                else
                {
                    var formFields = form.GetAllFormFields();
                    sb.AppendLine($"  Fields ({formFields.Count}):");
                    foreach (var kvp in formFields.OrderBy(k => k.Key))
                    {
                        var f = kvp.Value;
                        var tooltip = f.GetFieldFlag(iText.Forms.Fields.PdfFormField.FF_MULTILINE) ? "[multiline]" : "";
                        var altName = f.GetPdfObject().GetAsString(iText.Kernel.Pdf.PdfName.TU)?.ToUnicodeString() ?? "";
                        var value   = f.GetValueAsString();
                        var type    = f.GetFormType()?.ToString()?.Split('/').Last() ?? "?";

                        // Позиция на странице
                        var widgets = f.GetWidgets();
                        var rect = widgets?.Count > 0 ? widgets[0].GetRectangle()?.ToRectangle() : null;
                        var pos = rect != null
                            ? $"x={rect.GetX():F0} y={rect.GetY():F0} w={rect.GetWidth():F0} h={rect.GetHeight():F0}"
                            : "no widget";

                        sb.AppendLine($"    [{kvp.Key}]  type={type}  alt=\"{altName}\"  val=\"{value}\"  {pos}");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"  ERROR: {ex.GetType().Name}: {ex.Message}");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
