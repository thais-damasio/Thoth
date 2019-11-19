﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.DataBase.Context;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.QueryResult;
using PUC.LDSI.Domain.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PUC.LDSI.ModuloAluno.Controllers
{
    public class ProvaController : BaseController
    {
        private readonly IProvaService _ProvaService;
        private readonly IAlunoService _AlunoService;
        private readonly IAvaliacaoService _AvalicaoService;

        public ProvaController(
            AppDbContext context,
            IProvaService provaService,
            IAlunoService alunoService,
            IAvaliacaoService avaliacaoService,
            UserManager<Usuario> _user) : base(_user)
        {
            _ProvaService = provaService;
            _AlunoService = alunoService;
            _AvalicaoService = avaliacaoService;
        }

        // GET: Prova
        public async Task<IActionResult> Index()
        {
            //var aluno = await _provaService.ObterPorLogin(LoginUsuario.Email);
            return View(await _ProvaService.ObterProvasComRelacoes(LoginUsuario.Email));
        }

        // GET: Prova/FazerProva
        public async Task<IActionResult> FazerProva(int id)
        {
            var prova = await _ProvaService.ObterProvaAsync(id, LoginUsuario.Email);

            return View("Prova", prova);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalvarProva([Bind("AvaliacaoId,PublicacaoId,Questoes")] ProvaQueryResult prova)
        {
            if (ModelState.IsValid)
            {
                await _ProvaService.SalvarProvaAsync(prova, LoginUsuario.Email);
                return RedirectToAction(nameof(Index));
            }
            ProvaQueryResult provaBd = await _ProvaService.ObterProvaAsync(prova.PublicacaoId, LoginUsuario.Email);
            for (int i = 0; i < prova.Questoes.Count; i++)
            {
                provaBd.Questoes[i].Completa = prova.Questoes[i].Completa;
                for (int j = 0; j < prova.Questoes[i].Opcoes.Count; j++)
                {
                    provaBd.Questoes[i].Opcoes[j].Resposta = prova.Questoes[i].Opcoes[j].Resposta;
                }
            }
            return View("Prova", provaBd);
        }

        // Teste
        // POST: Avaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestao([Bind("IdProva,IdAvaliacaoQuestao")] ProvaQuestao questao)
        {
            if (ModelState.IsValid)
            {
                var aluno = _AlunoService.BuscarPorEmail(LoginUsuario.Email);
                questao.IdProva = aluno.Id;

                int id_ProvaQuestao = await _ProvaService.IncluirNovaProvaQuestaoAsync(questao.IdAvaliacaoQuestao, questao.IdProva);

                return RedirectToAction(nameof(EditQuestaoProva), new { id = id_ProvaQuestao });
            }
            return View(questao);
        }


        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestaoProva(int id, [Bind("IdProva,IdAvaliacaoQuestao")] ProvaQuestao questao)
        {
            if (id != questao.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _ProvaService.AtualizarNotaProvaQuestaoAsync(questao.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(questao);
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProvaOpcao([Bind("IdQuestaoProva,IdAvaliacaoOpcao,Resposta")] ProvaOpcao opcao)
        {
            if (ModelState.IsValid)
            {

                int id_ProvaOpacao = await _ProvaService.IncluirNovaProvaOpcaoAsync(opcao.IdAvaliacaoOpcao, opcao.IdQuestaoProva, opcao.Resposta);

                return RedirectToAction(nameof(EditProvaOpcao), new { id = id_ProvaOpacao });
            }
            return View(opcao);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProvaOpcao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provaOpcao = await _ProvaService.ObterProvaOpcaoAsync(id.Value);
            if (provaOpcao == null)
            {
                return NotFound();
            }
            return View(provaOpcao);
        }

        // GET: Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAvaliacaoQuestoes(int? idAvaliacao)
        {
            if (idAvaliacao == null)
            {
                return NotFound();
            }

            var questoes = await _AvalicaoService.ObterAvaliacaoQuestaoAsync(idAvaliacao.Value);
            if (questoes == null)
            {
                return NotFound();
            }
            return View(questoes);
        }

    }
}