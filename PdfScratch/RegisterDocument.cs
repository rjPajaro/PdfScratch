using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace PdfScratch
{
    public class RegisterDocument
    {
        public void Generate(string name, byte[] signature, bool withSignature)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Size(PageSizes.Letter);
                        page.Margin(1f, Unit.Inch);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                        // RANDALL TODO : Add signature if `withSignature` is `true`, use `user.ESignatureNavigation.File`; set date to now
                        page.Content().Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.Spacing(80);
                                row.RelativeItem().Column(c =>
                                {
                                    if (!withSignature)
                                    {
                                        c.Item().Column(col =>
                                        {
                                            col.Item().PaddingVertical(25);
                                            col.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            col.Item().AlignCenter().Text(name).Bold();
                                            col.Item().PaddingBottom(180);
                                        });
                                    }
                                    else
                                    {
                                        c.Item().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(col =>
                                            {
                                                col.Item().PaddingVertical(25);
                                                col.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                col.Item().AlignCenter().Text(name).Bold();
                                                col.Item().PaddingBottom(180);
                                            });
                                            layers.Layer().AlignCenter().Width(150).Height(150).Image(signature);
                                        });
                                    }
                                });
                                row.RelativeItem().Column(c =>
                                {
                                    if (!withSignature)
                                    {
                                        c.Item().Column(col =>
                                        {
                                            col.Item().PaddingVertical(25);
                                            col.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            col.Item().AlignCenter().Text("Date").Bold();
                                            col.Item().PaddingBottom(180);
                                        });
                                    }
                                    else
                                    {
                                        c.Item().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(col =>
                                            {
                                                col.Item().PaddingVertical(25);
                                                col.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                col.Item().AlignCenter().Text("Date").Bold();
                                                col.Item().PaddingBottom(180);
                                            });
                                            layers.Layer().AlignCenter().PaddingVertical(35).Text(DateTime.Now.ToShortDateString());
                                        });
                                    }
                                });
                            });
                        });
                    });
            });
            

            document.GeneratePdf("pad-signed.pdf");
            document.ShowInPreviewer();
        }
    }
}
