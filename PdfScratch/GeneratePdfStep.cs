using PdfScratch.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace PdfScratch
{
    public class GeneratePdfStep
    {
        public void GeneratePdf(string name, byte[]? signature)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Size(PageSizes.Letter.Landscape());
                        page.MarginTop(1, Unit.Inch);
                        page.MarginLeft(1, Unit.Inch);
                        page.MarginRight(1, Unit.Inch);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(11.5f).FontFamily(Fonts.Trebuchet));

                        page.Content().Column(column =>
                        {
                            column.Spacing(30);
                            column.Item().AlignCenter().DefaultTextStyle(textStyle => textStyle.FontSize(20).Weight(FontWeight.Bold)).Text("APPROVAL OF THE 2023/2024 SERVICE DELIVERY AND BUDGET IMPLEMENTATION PLAN");
                            column.Item().Text("The Service Delivery and Budget Implementation Plan (SDBIP) for 2023/2024 is hereby approved by the mayor of Walter Sisulu Local Municipality in terms of section 53 (1)(c)(ii) of the Local Government: Municipal Finance Management Act (MFMA), No. 56 of 2003, read with Section 58, per Resolution Number _________.");
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().AlignLeft().AlignBottom().Column(col =>
                                {

                                    if (signature is null)
                                    {
                                        col.Item().Padding(25).Column(column =>
                                        {
                                            column.Item().PaddingHorizontal(110).PaddingVertical(15);
                                            column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            column.Item().AlignCenter().Text(name);
                                            column.Item().PaddingBottom(80);
                                        });
                                    }
                                    else
                                    {
                                        col.Item().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Padding(25).Column(column =>
                                            {
                                                column.Item().PaddingHorizontal(110).PaddingVertical(15);
                                                column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                column.Item().AlignCenter().Text(name);
                                                column.Item().PaddingBottom(80);
                                            });
                                            layers.Layer().AlignCenter().Width(150).Height(150).Image(signature);
                                        });
                                    }
                                });
                                row.RelativeItem().AlignRight().AlignBottom().Column(col =>
                                {
                                    if (signature is null)
                                    {
                                        col.Item().Padding(25).Column(column =>
                                        {
                                            column.Item().PaddingHorizontal(110).PaddingVertical(15);
                                            column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            column.Item().AlignCenter().Text("Date");
                                            column.Item().PaddingBottom(80);
                                        });
                                    }
                                    else
                                    {
                                        col.Item().Padding(25).Column(column =>
                                        {
                                            column.Item().PaddingHorizontal(110).PaddingVertical(15);
                                            column.Item().AlignCenter().Text(DateTime.UtcNow.ToShortDateString());
                                            column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            column.Item().AlignCenter().Text("Date");
                                            column.Item().PaddingBottom(80);
                                        });
                                    }
                                });
                            });
                        });
                    })
                    .Page(page =>
                    {
                        page.Size(PageSizes.Letter.Landscape());
                        page.MarginTop(1, Unit.Inch);
                        page.MarginLeft(0.5f, Unit.Inch);
                        page.MarginRight(0.5f, Unit.Inch);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontFamily(Fonts.Arial));

                        page.Content().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            // Headers
                            table.Cell().ColumnSpan(15).Element(container => Block(container, "#c5e0b3", 11, FontWeight.Bold)).Text("KEY PERFORMANCE AREA (KPA) 2: MUNICIPAL TRANSFORMATION AND ORGANISATIONAL DEVELOPMENT");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Strategic Objective");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).RotateLeft().Text("Programme No.");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Indicator");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Indicator Type");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Budget Allocation");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Baseline");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Spatial Reference");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Annual Target");
                            table.Cell().Element(container => Block(container, "#a6a6a6", fontWeight: FontWeight.Bold)).Text("Quarter 1");
                            table.Cell().Element(container => Block(container, "#a6a6a6", fontWeight: FontWeight.Bold)).Text("Quarter 2");
                            table.Cell().Element(container => Block(container, "#a6a6a6", fontWeight: FontWeight.Bold)).Text("Quarter 3");
                            table.Cell().Element(container => Block(container, "#a6a6a6", fontWeight: FontWeight.Bold)).Text("Quarter 4");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Means of Verification");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Custodian");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).Text("Internal Role Players");


                            // Body
                            table.Cell().RowSpan(2).Element(container => Block(container)).Text("Improve financial viability and management");
                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).RotateLeft().AlignCenter().Text("FV 2023/24 - 01");
                            table.Cell().Element(container => Block(container)).Text("% of the Eskom debt written off as per the municipal debt relief programme");
                            table.Cell().Element(container => Block(container)).Text("Output");
                            table.Cell().Element(container => Block(container)).Text("OPEX");
                            table.Cell().Element(container => Block(container)).Text("New Indicator");
                            table.Cell().Element(container => Block(container)).Text("Internal");
                            table.Cell().Element(container => Block(container)).Text("33%");
                            table.Cell().Element(container => Block(container)).Text("Municipal debt relief monitoring report");
                            table.Cell().Element(container => Block(container)).Text("Municipal debt relief monitoring report");
                            table.Cell().Element(container => Block(container)).Text("Municipal debt relief monitoring report");
                            table.Cell().Element(container => Block(container)).Text("33%");
                            table.Cell().Element(container => Block(container)).Text("Confirmation from NT that 1/3 of the debt as at 31 March 2023 has been written off");
                            table.Cell().Element(container => Block(container)).Text("Chief Financial Officer");
                            table.Cell().Element(container => Block(container)).Text("Chief Financial Officer");

                            table.Cell().Element(container => Block(container, "#808080", fontWeight: FontWeight.Bold)).RotateLeft().AlignCenter().Text("FV 2023/24 - 02");
                            table.Cell().Element(container => Block(container)).Text("Number (No.) of GRAP\r\ncompliant mid-term financial statements submitted ti the AGSA");
                            table.Cell().Element(container => Block(container)).Text("Output");
                            table.Cell().Element(container => Block(container)).Text("R2.7m");
                            table.Cell().Element(container => Block(container)).Text("Adverse Opinion");
                            table.Cell().Element(container => Block(container)).Text("Internal");
                            table.Cell().Element(container => Block(container)).Text("1");
                            table.Cell().Element(container => Block(container)).Text("1");
                            table.Cell().Element(container => Block(container)).Text("N/A");
                            table.Cell().Element(container => Block(container)).Text("N/A");
                            table.Cell().Element(container => Block(container)).Text("N/A");
                            table.Cell().Element(container => Block(container)).Text("Unqualified audit opinion");
                            table.Cell().Element(container => Block(container)).Text("Chief Financial Officer");
                            table.Cell().Element(container => Block(container)).Text("Manager: Financial Accounting");


                            static IContainer Block(IContainer container, string background = Colors.White, float fontSize = 8, FontWeight fontWeight = FontWeight.Normal)
                            {
                                return container
                                    .Border(0.5f)
                                    .Background(background)
                                    .AlignCenter()
                                    .AlignMiddle()
                                    .Padding(10)
                                    .DefaultTextStyle(
                                        textStyle => textStyle.FontSize(fontSize).Weight(fontWeight));
                            }
                        });
                    });
            });

            document.GeneratePdf("sdbip-signed.pdf");
            document.ShowInPreviewer();
        }
    }
}
