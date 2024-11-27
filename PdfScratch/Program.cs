// See https://aka.ms/new-console-template for more information
using PdfScratch;
using PdfScratch.Models;

public class Program
{
    static void Main(string[] args)
    {
        var name = "Randall Joseph Pajaro";
        //var signature = File.ReadAllBytes("dm-signature.png");

        // GENERATE PDF STEP
        //var firstWitnessSignature = File.ReadAllBytes("dm-signature.png");
        //var secondWitnessSignature = File.ReadAllBytes("dm-signature.png");
        //var supervisorSignature = File.ReadAllBytes("dm-signature.png");
        //var firstSupervisorWitnessSignature = File.ReadAllBytes("dm-signature.png");
        //var secondSupervisorWitnessSignature = File.ReadAllBytes("dm-signature.png");
        //signature = null;
        //firstWitnessSignature = null;
        //secondWitnessSignature = null;
        //supervisorSignature = null;
        //firstSupervisorWitnessSignature = null;
        //secondSupervisorWitnessSignature = null;

        // PERFORMANCE AGREEMENT DOCUMENT
        var signature = new PerformanceAgreementSignatures();
        signature.Signature = File.ReadAllBytes("dm-signature.png");
        signature.FirstWitnessSignature = File.ReadAllBytes("dm-signature.png");
        signature.SecondWitnessSignature = File.ReadAllBytes("dm-signature.png");
        signature.SupervisorSignature = File.ReadAllBytes("dm-signature.png");
        signature.FirstSupervisorWitnessSignature = File.ReadAllBytes("dm-signature.png");
        signature.SecondSupervisorWitnessSignature = File.ReadAllBytes("dm-signature.png");


        var generatePdf = new GeneratePdfStep();
        var performanceAgreementDocument = new PerformanceAgreementDocument();
        performanceAgreementDocument.GeneratePerformanceAgreementDocument(signature);
        //var registerDocument = new RegisterDocument();
        //registerDocument.Generate(name, signature, true);
    }
}
