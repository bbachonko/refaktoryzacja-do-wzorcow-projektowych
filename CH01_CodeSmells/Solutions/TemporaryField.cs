namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class InvoiceGenerator
    {
        public void GenerateInvoice()
        {
            int invoiceNumber = 12345;
            using (PdfWriter pdfWriter = new PdfWriter($"Invoice_{invoiceNumber}.pdf"))
            {
                // Generowanie faktury
                pdfWriter.Write("Invoice Content");
            }
        }

        public void OtherMethod()
        {
            // Metoda, która nie korzysta z tymczasowych pól
        }
    }
}