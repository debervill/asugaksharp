using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Forms;
using iText.Forms.Fields;

try { Console.OutputEncoding = System.Text.Encoding.UTF8; } catch (System.IO.IOException) { }

var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "Templates")))
    dir = dir.Parent;
if (dir == null) { Console.WriteLine("Templates folder not found"); return; }
var baseDir = Path.Combine(dir.FullName, "Templates");

var file = Directory.GetFiles(baseDir, "*Протокол .pdf").First();
Console.WriteLine($"=== {Path.GetFileName(file)} ===\n");

using var reader = new PdfReader(file);
using var pdf    = new PdfDocument(reader);
var form = PdfAcroForm.GetAcroForm(pdf, false);
if (form == null) { Console.WriteLine("no form"); return; }

var rows = form.GetAllFormFields()
    .Select(kv =>
    {
        var f    = kv.Value;
        var alt  = f.GetPdfObject().GetAsString(iText.Kernel.Pdf.PdfName.TU)?.ToUnicodeString() ?? "";
        var widgets = f.GetWidgets();
        var w    = widgets?.Count > 0 ? widgets[0] : null;
        var rect = w?.GetRectangle()?.ToRectangle();
        var page = w != null ? pdf.GetPageNumber(w.GetPage()) : 0;
        return new
        {
            Key  = kv.Key,
            Page = page,
            Y    = rect?.GetY()    ?? 0f,
            X    = rect?.GetX()    ?? 0f,
            W    = rect?.GetWidth() ?? 0f,
            Alt  = alt
        };
    })
    .OrderBy(r => r.Page)
    .ThenByDescending(r => r.Y)
    .ToList();

foreach (var r in rows)
{
    var altPart = string.IsNullOrEmpty(r.Alt) ? "" : $"  \"{r.Alt}\"";
    Console.WriteLine($"  p{r.Page}  [{r.Key,-12}]  x={r.X,3:F0} y={r.Y,3:F0} w={r.W,3:F0}{altPart}");
}
