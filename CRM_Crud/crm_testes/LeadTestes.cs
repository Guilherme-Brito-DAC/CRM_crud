using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Moq;
using System.Diagnostics;
using Xunit;

namespace crm_testes
{
    public class LeadTestes
    {
        public Mock<ILeadRepository> leadRepository;

        public LeadTestes()
        {
            leadRepository = new Mock<ILeadRepository>();
        }

        [Fact]
        public void CriarLead()
        {
            //Arrange

            var lead = new Lead();
            lead.nome = "Guilherme";
            lead.cpf = "519.123.121-45";
            lead.telefone = "(31) 12353-1231";
            lead.email = "guilherme2@gmail.com";

            //Act

            leadRepository.Setup(l => l.CriarLead(lead)).Verifiable();

            //Assert

            leadRepository.Verify();
            Assert.True(true);
        }

        [Fact]
        public void CriarLeadComMesmoNome()
        {

        }

        [Fact]
        public void EditarLead()
        {

        }

        [Fact]
        public void EditarLeadParaUmMesmoNome()
        {

        }

        [Fact]
        public void DeletarLead()
        {

        }
    }
}
