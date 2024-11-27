using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfScratch.Models
{
    public class PerformanceAgreementSignatures
    {
        public byte[]? Signature { get; set; }

        public byte[]? FirstWitnessSignature { get; set; }
        
        public byte[]? SecondWitnessSignature { get; set; }

        public byte[]? SupervisorSignature { get; set; }

        public byte[]? FirstSupervisorWitnessSignature { get; set; }
        
        public byte[]? SecondSupervisorWitnessSignature { get; set; }
    }
}
