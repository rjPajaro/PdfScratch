using PdfScratch.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Globalization;

namespace PdfScratch
{
    public class PerformanceAgreementDocument
    {
        public void GeneratePerformanceAgreementDocument(PerformanceAgreementSignatures signature)
        {
            var user = new GetUserWithSupervisorEntity()
            {
                ID = 1,
                DisplayName = "Randall Joseph",
                Email = "associate@test.com",
                Position = "Associate Dev",
                SupervisorDisplayName = "John Philip",
                SupervisorEmail = "teamlead@test.com",
                SupervisorPosition = "Team Lead Dev"
            };

            var quarters = new List<QuarterEntity>
            {
                new QuarterEntity()
                {
                    Quarter = 1,
                    StartDate = DateTime.ParseExact("01/01/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("31/03/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TenantId = new Guid("2A039769-1240-4907-B4C0-FC7ED447D654"),
                    Year = "2024",
                    QuarterStatus = "Inactive"
                },
                new QuarterEntity()
                {
                    Quarter = 2,
                    StartDate = DateTime.ParseExact("01/04/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("30/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TenantId = new Guid("2A039769-1240-4907-B4C0-FC7ED447D654"),
                    Year = "2024",
                    QuarterStatus = "Active"
                },
                new QuarterEntity()
                {
                    Quarter = 3,
                    StartDate = DateTime.ParseExact("01/07/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("30/09/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TenantId = new Guid("2A039769-1240-4907-B4C0-FC7ED447D654"),
                    Year = "2024",
                    QuarterStatus = "Inactive"
                },
                new QuarterEntity()
                {
                    Quarter = 4,
                    StartDate = DateTime.ParseExact("01/10/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("31/12/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TenantId = new Guid("2A039769-1240-4907-B4C0-FC7ED447D654"),
                    Year = "2024",
                    QuarterStatus = "Inactive"
                }
            };

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Size(PageSizes.Letter);
                        page.MarginVertical(0.79f, Unit.Inch);
                        page.MarginHorizontal(1.25f, Unit.Inch);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                        page.Content().Column(column =>
                        {
                            column.Item().AlignCenter().Height(54).Text("PERFORMANCE AGREEMENT").Bold().FontSize(18);
                            column.Item().AlignCenter().Height(48).Text("MADE AND ENTERED INTO BY AND BETWEEN:");
                            column.Item().AlignCenter().Text("THE DEPARTMENT OF FINANCIAL SERVICES AS").Bold();
                            column.Item().AlignCenter().Text($"REPRESENTED BY SUPERVISOR").Bold();
                            column.Item().AlignCenter().Text($"MR/MS. JOHN PHILIP").Bold();
                            column.Item().AlignCenter().Height(48).Text("………………………………………………………").Bold();
                            column.Item().AlignCenter().Height(32).Text("AND");
                            column.Item().AlignCenter().Text($"MR/MS. RANDALL JOSEPH").Bold();
                            column.Item().AlignCenter().Text("………………………………………………………").Bold();
                            column.Item().AlignCenter().Text("ASSOCIATE SE").Bold();
                            column.Item().AlignCenter().Height(32).Text("FOR THE");
                            column.Item().AlignCenter().Text(text =>
                            {
                                text.Span("FINANCIAL YEAR: ").Bold();
                                text.Span($"{quarters.First().StartDate.ToString("d MMMM yyyy").ToUpper()} - {quarters.Last().EndDate.ToString("d MMMM yyyy").ToUpper()}");
                            });
                        });
                    })
                    .Page(page =>
                    {
                        page.Size(PageSizes.Letter);
                        page.MarginVertical(0.79f, Unit.Inch);
                        page.MarginHorizontal(1.25f, Unit.Inch);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                        page.Content().Column(column =>
                        {
                            column.Item().Height(30).Text(text =>
                            {
                                text.Span("Thus ");
                                text.Span("done ").Bold();
                                text.Span("and ");
                                text.Span("signed ").Bold();
                                text.Span($"at ………………………on this the…… day of ………………………{DateTime.Now.Year}.");
                            });
                            column.Item().Height(40).Text("AS WITNESSES:").Bold();
                            column.Item().Row(row =>
                            {
                                row.Spacing(100);
                                // First Witness
                                if (signature.FirstWitnessSignature != null)
                                {
                                    row.RelativeItem().Row(r =>
                                    {
                                        r.AutoItem().PaddingTop(15).Text("1. ");
                                        r.RelativeItem().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(column =>
                                            {
                                                column.Item().PaddingTop(30);
                                                column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                column.Item().PaddingBottom(30);
                                            });
                                            layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.FirstWitnessSignature);
                                        });
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().PaddingTop(17).Row(r =>
                                    {
                                        r.AutoItem().Text("1. ");
                                        r.RelativeItem().PaddingTop(13).LineHorizontal(1);
                                    });
                                }
                                // User Signature
                                if (signature.Signature != null)
                                {
                                    row.RelativeItem().AlignBottom().Layers(layers =>
                                    {
                                        layers.PrimaryLayer().Column(column =>
                                        {
                                            column.Item().PaddingTop(30);
                                            column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            column.Item().AlignCenter().Text(user.Position.ToUpper()).Bold();
                                            column.Item().PaddingBottom(20);
                                        });
                                        layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.Signature);
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().AlignBottom().Column (column =>
                                    {
                                        column.Item().PaddingTop(30);
                                        column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                        column.Item().AlignCenter().Text(user.Position.ToUpper()).Bold();
                                        column.Item().PaddingBottom(20);
                                    });
                                }
                            });
                            column.Item().Row(row =>
                            {
                                row.Spacing(100);
                                // Second Witness
                                if (signature.SecondWitnessSignature != null)
                                {
                                    row.RelativeItem().Row(r =>
                                    {
                                        r.AutoItem().PaddingTop(15).Text("2. ");
                                        r.RelativeItem().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(column =>
                                            {
                                                column.Item().PaddingTop(30);
                                                column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                column.Item().PaddingBottom(30);
                                            });
                                            layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.SecondWitnessSignature);
                                        });
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().PaddingTop(17).Row(r =>
                                    {
                                        r.AutoItem().Text("2. ");
                                        r.RelativeItem().PaddingTop(13).LineHorizontal(1);
                                    });
                                }
                                row.RelativeItem();
                            });
                            column.Item().Height(40);
                            column.Item().Height(40).Text("AS WITNESSES:").Bold();
                            column.Item().Row(row =>
                            {
                                row.Spacing(100);
                                // First Supervisor Witness
                                if (signature.FirstSupervisorWitnessSignature != null)
                                {
                                    row.RelativeItem().Row(r =>
                                    {
                                        r.AutoItem().PaddingTop(15).Text("1. ");
                                        r.RelativeItem().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(column =>
                                            {
                                                column.Item().PaddingTop(30);
                                                column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                column.Item().PaddingBottom(30);
                                            });
                                            layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.FirstSupervisorWitnessSignature);
                                        });
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().PaddingTop(17).Row(r =>
                                    {
                                        r.AutoItem().Text("1. ");
                                        r.RelativeItem().PaddingTop(13).LineHorizontal(1);
                                    });
                                }
                                // Supervisor Signature
                                if (signature.SupervisorSignature != null)
                                {
                                    row.RelativeItem().AlignBottom().Layers(layers =>
                                    {
                                        layers.PrimaryLayer().Column(column =>
                                        {
                                            column.Item().PaddingTop(30);
                                            column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                            column.Item().AlignCenter().Text(user.SupervisorPosition.ToUpper()).Bold();
                                            column.Item().PaddingBottom(20);
                                        });
                                        layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.SupervisorSignature);
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().AlignBottom().Column(column =>
                                    {
                                        column.Item().PaddingTop(30);
                                        column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                        column.Item().AlignCenter().Text(user.SupervisorPosition.ToUpper()).Bold();
                                        column.Item().PaddingBottom(20);
                                    });
                                }
                            });
                            column.Item().Row(row =>
                            {
                                row.Spacing(100);
                                // Second Supervisor Witness
                                if (signature.SecondSupervisorWitnessSignature != null)
                                {
                                    row.RelativeItem().Row(r =>
                                    {
                                        r.AutoItem().PaddingTop(15).Text("2. ");
                                        r.RelativeItem().Layers(layers =>
                                        {
                                            layers.PrimaryLayer().Column(column =>
                                            {
                                                column.Item().PaddingTop(30);
                                                column.Item().LineHorizontal(1).LineColor(Colors.Black);
                                                column.Item().PaddingBottom(30);
                                            });
                                            layers.Layer().AlignCenter().Width(100).Height(60).Image(signature.SecondSupervisorWitnessSignature);
                                        });
                                    });
                                }
                                else
                                {
                                    row.RelativeItem().PaddingTop(17).Row(r =>
                                    {
                                        r.AutoItem().Text("2. ");
                                        r.RelativeItem().PaddingTop(13).LineHorizontal(1);
                                    });
                                }
                                row.RelativeItem();
                            });
                        });
                    });
            });

            document.GeneratePdf("pad-signed.pdf");
            document.ShowInPreviewer();
        }
    }
}
