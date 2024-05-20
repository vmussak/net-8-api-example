using AdaTech.Application.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdaTech.IntegrationTests.Steps
{
    [Binding]
    public class AlunoStepDefinition
    {
        HttpClient Client;
        HttpResponseMessage Response;
        Application.Requests.CriarAlunoRequest AlunoRequest;

        [Given(@"um aluno com nome='([^']*)' e email='([^']*)' e CEP='([^']*)'")]
        public void GivenUmAlunoComNomeEEmailECEP(string nome, string email, string cep)
        {
            AlunoRequest = new Application.Requests.CriarAlunoRequest
            {
                Nome = nome,
                Email = email,
                Cep = cep,
            };
        }

        [When(@"Aciono o endpoint POST '([^']*)'")]
        public async Task WhenAcionoOEndpointPOST(string endpoint)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7051")
            };

            Response = await Client.PostAsJsonAsync(endpoint, AlunoRequest);
        }

        [Then(@"Devo receber um status code (.*) e o aluno deve ser cadastrado com UF='([^']*)'")]
        public async Task ThenDevoReceberUmStatusCodeEOAlunoDeveSerCadastradoComUF(int p0, string uf)
        {
            var content = await Response.Content.ReadFromJsonAsync<AlunoPresenter>();
            Assert.Equal(p0, (int)Response.StatusCode);
            Assert.Equal(uf, content.Uf);
        }
    }
}
