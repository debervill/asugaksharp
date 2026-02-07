using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Markdig;
using Markdig.Wpf;

namespace asugaksharp.Features.Help;

public partial class HelpWindow : Window
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UseSupportedExtensions()
        .Build();

    public HelpWindow()
    {
        InitializeComponent();
    }

    public HelpWindow(string title, string markdownContent) : this()
    {
        Title = title;
        LoadMarkdown(markdownContent);
    }

    public static HelpWindow FromFile(string filePath)
    {
        var title = Path.GetFileNameWithoutExtension(filePath);
        var content = File.ReadAllText(filePath);
        return new HelpWindow(title, content);
    }

    public static HelpWindow FromDocsFile(string fileName)
    {
        var docsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs", fileName);

        // Fallback to project docs folder during development
        if (!File.Exists(docsPath))
        {
            var projectPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            while (projectPath != null && !File.Exists(Path.Combine(projectPath, "docs", fileName)))
            {
                projectPath = Path.GetDirectoryName(projectPath);
            }
            if (projectPath != null)
            {
                docsPath = Path.Combine(projectPath, "docs", fileName);
            }
        }

        if (!File.Exists(docsPath))
        {
            return new HelpWindow("Ошибка", $"Файл справки не найден: {fileName}");
        }

        return FromFile(docsPath);
    }

    private void LoadMarkdown(string markdown)
    {
        var document = Markdig.Wpf.Markdown.ToFlowDocument(markdown, Pipeline);
        Viewer.Document = document;
    }

    private void Hyperlink_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Parameter is string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
                // Ignore errors opening links
            }
        }
    }
}
