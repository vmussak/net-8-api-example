Feature: Aluno

Feature relacionada aos Alunos da Ada Tech

@tag1
Scenario: Cadastrar um aluno
	Given um aluno com nome='Vinicius' e email='vinicius.mussak@ada.tech' e CEP='30140070'
	When Aciono o endpoint POST '/api/alunos'
	Then Devo receber um status code 200 e o aluno deve ser cadastrado com UF='MG'
