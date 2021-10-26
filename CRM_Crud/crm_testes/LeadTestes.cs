using Moq;
using Xunit;
using CRM_Crud;
using CRM_Crud.Repositories;
using CRM_Crud.Models;
using CRM_Crud.Controllers;
using CRM_Crud.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

namespace CRM_testes
{
    public class LeadTestes
    {
        [Fact]
        public void CriacaoDeLeadComDadosValidosRetornaOkResult()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("CRM_testes").Options;
            var context = new ApplicationContext(options);

            var repoLead = new LeadRepository(context);
            var repoInscricao = new InscricaoRepository(context);
            var repoCurso = new CursoRepository(context);

            var mockFiltro = new Mock<ErroFiltro>(repoInscricao, repoCurso, repoLead);
            var filtro = mockFiltro.Object;

            var controller = new LeadController(repoLead, filtro);

            var tempDataProvider = new Mock<ITempDataProvider>();
            var httpContext = new DefaultHttpContext();
            controller.TempData = new TempDataDictionary(httpContext, tempDataProvider.Object);

            var lead = new Lead();
            lead.nome = "Teste";
            lead.telefone = "(11) 11111-1111";
            lead.cpf = "111.111.111-11";
            lead.email = "Gabriel@gmail.com";

            //act

            var retorno = controller.Criar(lead);

            //assert

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void CriacaoDeLeadComDadosNaoPreenchidosRetornaBadRequest()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("CRM_testes").Options;
            var context = new ApplicationContext(options);

            var repoLead = new LeadRepository(context);
            var repoInscricao = new InscricaoRepository(context);
            var repoCurso = new CursoRepository(context);

            var mockFiltro = new Mock<ErroFiltro>(repoInscricao, repoCurso, repoLead);
            var filtro = mockFiltro.Object;

            var controller = new LeadController(repoLead, filtro);

            var tempDataProvider = new Mock<ITempDataProvider>();
            var httpContext = new DefaultHttpContext();
            controller.TempData = new TempDataDictionary(httpContext, tempDataProvider.Object);

            var lead = new Lead();
            lead.nome = "";
            lead.telefone = "";
            lead.cpf = "";
            lead.email = "";

            //act

            var retorno = controller.Criar(lead);

            //assert

            Assert.IsType<BadRequestObjectResult>(retorno);
        }

        [Fact]
        public void CriacaoDeLeadComDadosNaoPreenchidosRetornaBadRequest()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("CRM_testes").Options;
            var context = new ApplicationContext(options);

            var repoLead = new LeadRepository(context);
            var repoInscricao = new InscricaoRepository(context);
            var repoCurso = new CursoRepository(context);

            var mockFiltro = new Mock<ErroFiltro>(repoInscricao, repoCurso, repoLead);
            var filtro = mockFiltro.Object;

            var controller = new LeadController(repoLead, filtro);

            var tempDataProvider = new Mock<ITempDataProvider>();
            var httpContext = new DefaultHttpContext();
            controller.TempData = new TempDataDictionary(httpContext, tempDataProvider.Object);

            

            //act

            var retorno = controller.Criar(lead);

            //assert

            Assert.IsType<BadRequestObjectResult>(retorno);
        }
    }
}
