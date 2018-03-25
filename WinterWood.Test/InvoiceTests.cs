using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinterWood.Entities;
using WinterWood.Repository.Contracts;

namespace WinterWood.Test
{
    [TestClass]
    public class InvoiceTests
    {
        private Mock<IRepository<Invoice>> _invoiceRepository = new Mock<IRepository<Invoice>>();

        public IRepository<Invoice> MockInvoiceRepository;

        [TestInitialize]
        public void Initialize()
        {
            _invoiceRepository = new Mock<IRepository<Invoice>>();
            IList<Invoice> invoices = new List<Invoice>
                {
                    new Invoice { InvoiceId = 1, AccountId=1, Reference="120.00",
                        TotalNet = 115.00m , TotalVat = 55.00m, TotalGross=120.00m },
                    new Invoice { InvoiceId = 2, AccountId=2, Reference="QW-12213-c",
                        TotalNet = 90.00m , TotalVat = 45.00m, TotalGross=96.00m },
                    new Invoice { InvoiceId = 3, AccountId=3, Reference="TR-55",
                        TotalNet = 233.55m , TotalVat = 200.00m, TotalGross=355.00m },
                    new Invoice { InvoiceId = 4, AccountId=4, Reference="MT-18",
                        TotalNet = 455.00m , TotalVat = 455.00m, TotalGross=500.00m }
                };
            _invoiceRepository.Setup(m => m.GetAllInvoices()).Returns(invoices);
            MockInvoiceRepository = _invoiceRepository.Object;

        }

        [TestMethod]
        public void Show_All_Invoices_Are_Not_Null_And_Verify_Invoice_Number()
        {
            IEnumerable<Invoice> testInvoices = _invoiceRepository.Object.GetAllInvoices();

            Assert.IsNotNull(testInvoices);
            Assert.AreEqual(4, testInvoices.Count());
        }

        [TestMethod]
        public void Get_Invoice_By_Reference_Name()
        {
            string searchString = "MT-18";
            int count = 0;
            IEnumerable<Invoice> testInvoices = MockInvoiceRepository.GetAllInvoices();
            foreach (var t in testInvoices)
            {
                if (t.Reference.Contains(searchString))
                {
                    count++;
                    Assert.IsNotNull(t);
                }
            }

            Assert.IsInstanceOfType(testInvoices, typeof(List<Invoice>));
            Assert.AreEqual(1, count);
        }
    }

}
