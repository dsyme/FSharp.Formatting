// Given a typical setup (with 'FSharp.Formatting' referenced using NuGet),
// the following will include binaries and load the literate script
#load "../../src/FSharp.Formatting.fsx"
open System.IO
open FSharp.Formatting.Literate

// ----------------------------------------------------------------------------
// SETUP
// ----------------------------------------------------------------------------

/// Return path relative to the current file location
let relative subdir = Path.Combine(__SOURCE_DIRECTORY__, subdir)

// Create output directories & copy content files there
// (We have two sets of samples in "output" and "output-all" directories,
//  for simplicitly, this just creates them & copies content there)
if not (Directory.Exists(relative "output")) then
  Directory.CreateDirectory(relative "output") |> ignore
  Directory.CreateDirectory (relative "output/content") |> ignore

for fileInfo in DirectoryInfo(relative "../../docs/files/content").EnumerateFiles() do
  fileInfo.CopyTo(Path.Combine(relative "output/content", fileInfo.Name)) |> ignore

// ----------------------------------------------------------------------------
// EXAMPLES
// ----------------------------------------------------------------------------

/// Processes a single F# Script file and produce HTML output
let processScriptAsHtml () =
  let file = relative "demo.fsx"
  let output = relative "output/demo-script.html"
  let template = relative "templates/template-file.html"
  Literate.ConvertScriptFile(file, template, output)

/// Processes a single Markdown document and produce HTML output
let processDocAsHtml () =
  let file = relative "demo.md"
  let output = relative "output/demo-doc.html"
  let template = relative "templates/template-file.html"
  Literate.ConvertMarkdown(file, template=template, output=output)

/// Processes a single Markdown document and produce HTML output
let processDocAsHtml () =
  let file = relative "demo.md"
  let output = relative "output/demo-doc.html"
  let template = relative "templates/template-file.html"
  Literate.ConvertMarkdown(file, template=template, output=output)

/// Processes a single F# Script file and produce LaTeX output
let processScriptAsLatex () =
  let file = relative "demo.fsx"
  let output = relative "output/demo-script.tex"
  let template = relative "templates/template-color.tex"
  Literate.ConvertScriptFile(file, template=template, output=output, outputKind=OutputKind.Latex)

/// Processes a single Markdown document and produce LaTeX output
let processDocAsLatex () =
  let file = relative "demo.md"
  let output = relative "output/demo-doc.tex"
  let template = relative "templates/template-color.tex"
  Literate.ConvertMarkdown(file, template=template, output=output, outputKind=OutputKind.Latex)

