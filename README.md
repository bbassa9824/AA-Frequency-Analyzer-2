# AA-Frequency-Analyzer-2

**Version 1.0**

AA-Frequency-Analyzer-2 is a software tool specifically designed to determine amino-acid frequencies at positions surrounding the canonical furin cleavage site of various proteins.

## Functionality

Furin is a proteolytic enzyme abundant in the tissues of higher animals, where it converts proproteins to their active forms. Bacteria and viruses can exploit furin to activate their own proteins and increase pathogenicity.

The consensus furin-recognition site in various protein substrates is **R-X-X-R**, where R represents arginine and X represents any of the 20 standard protein amino acids. Amino acids at positions beyond this consensus site may also influence furin activity.

AA-Frequency-Analyzer-2 is designed to determine amino-acid frequencies at individual positions within aligned sequence segments encompassing furin cleavage sites. The standard analysis uses 20-amino-acid segments spanning positions **P14 through P6′**, with the arginine immediately preceding the scissile bond designated P1.

The program is particularly useful for analyzing large datasets of furin substrate sequences and comparing positional amino-acid preferences surrounding the cleavage site.

## Input

The program accepts datasets of aligned amino-acid segments in comma-separated format, generally prepared as a column in Excel.

For the standard 20-amino-acid analysis, sequences must be aligned so that the P1 arginine is at position 14.

The complete query dataset is pasted into the input field, preferably as a column.

The program validates the input sequences before analysis. Sequences of incorrect length, sequences containing characters other than the 20 standard amino acids, and 20-amino-acid sequences without arginine at P1 are rejected and reported separately.

The program can also analyze shorter motifs from 1 to 20 amino acids.

## PickUnique option

The **PickUniqueIfChecked** option determines whether duplicate identical sequences are included in the analysis.

Select this option when the objective is to analyze only unique sequences.

Leave it unchecked when duplicate sequences are meaningful to the analysis—for example, when the objective is to determine the proportions of different sequence types within a dataset.

The appropriate choice therefore depends on the research question.

## Output

The program produces two principal outputs.

### Output 1 — Individual amino-acid frequencies

The second output field displays the positional frequencies of individual amino acids.

For the standard 20-amino-acid analysis, positions are reported from **P14 through P6′**.

Output 1 can be saved as a CSV file and opened in Microsoft Excel for further analysis and graphical presentation.

### Output 2 — Physicochemical amino-acid categories

The third output field displays the positional frequencies of amino acids grouped into physicochemical categories, including:

- Hydrophobic amino acids
- Hydrophilic amino acids
- Charged amino acids

Output 2 can also be saved as a CSV file and opened in Excel.

Rejected sequences are reported separately.

## How to use

1. Start AA-Frequency-Analyzer-2.

2. Examine the **PickUniqueIfChecked** option. Select it if only unique sequences are to be analyzed. Leave it unchecked if duplicate sequences are to be retained.

3. Paste the query dataset into the first input field. The sequences are generally entered as an Excel column or in comma-separated format.

4. Click **PerformAnalysis**.

5. A message will display the current status of the PickUnique option. Click **OK** to acknowledge the selection.

6. An input box will ask for the length of the motif to be analyzed. The default is **20 amino acids**. Motif lengths from 1 to 20 amino acids can be entered.

7. The analysis results are displayed in the output fields.

8. Save Output 1 and/or Output 2 as CSV files when required.

## Plotting Output 1 in Excel

Output 1 can be opened in Microsoft Excel and plotted graphically.

One procedure that has worked reliably is:

1. Open the saved CSV file in Excel.
2. Highlight the first two columns.
3. Select **Insert** and choose a suitable chart type, preferably a 2-D column/bar chart.
4. After the initial chart is displayed, extend the selected data range from the lower-right corner to include the remaining columns.
5. The chart should then display the positional frequencies across the complete dataset.

Selecting all columns before initially creating the chart may not always produce the desired plot; creating the chart from the first two columns and subsequently extending the data range has worked reliably.

## Validation

The program was validated using a dataset of **100 20-amino-acid segments containing the PRRAR motif**, with a predetermined composition of flanking amino acids.

The positional amino-acid frequencies produced by the program were compared with the expected frequencies. The program produced the predicted results.

## Installation and requirements

- **Operating system:** Microsoft Windows
- **Application type:** Windows Forms application
- **Framework:** .NET 9.0 for Windows

A ready-to-install version is available under **Releases** in this GitHub repository.

To install:

1. Download `AA-Frequency-Analyzer-2-v1.0-Windows.zip`.
2. Extract the ZIP file.
3. Run `setup.exe`.
4. Follow the installation prompts.

## Source code

The Visual Basic source code and Visual Studio project files are included in this repository to facilitate inspection and reproducibility.

## Documentation

The illustrated Word documentation is provided as:

**README-AA-Frequency-Analyzer-2.docx**

It contains additional information about the program and its use.

## Limitations

AA-Frequency-Analyzer-2 is a highly customized tool designed primarily for the analysis of furin cleavage sites.

Application to other types of proteolytic cleavage sites may require modification of the program.

Sequence datasets are entered manually by copying and pasting them into the program.

## Technical support

Users experiencing software-related issues may report them through the **Issues** section of the GitHub repository.

## DOI

AA-Frequency-Analyzer-2 Version 1.0 has been archived in Zenodo.

**Version 1.0 DOI:** 10.5281/zenodo.22967582

## Author

Copyright © 2026. All rights reserved.
