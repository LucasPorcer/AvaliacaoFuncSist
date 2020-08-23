using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.Validators;
using FI.WebAtividadeEntrevista.InfraData.Repositories.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["BancoDeDados"].ConnectionString;

        private BeneficiarioValidator beneficiarioValidator;
        private BeneficiarioSQLRepository beneficiarioRepo;

        public BeneficiarioController()
        {
            beneficiarioValidator = new BeneficiarioValidator();
            beneficiarioRepo = new BeneficiarioSQLRepository(ConnectionString);
        }

        public JsonResult BeneficiarioList(int idCliente)
        {
            try
            {
                var entidades = beneficiarioRepo.GetBeneficiariosFromClientId(idCliente);

                var beneficiarios = new List<BeneficiarioModel>();

                entidades.ToList().ForEach(e =>
                {
                    beneficiarios.Add(new BeneficiarioModel() { Cpf = e.Cpf, ID = e.ID, Nome = e.Nome });
                });

                return Json(new { Result = "OK", Records = beneficiarios, TotalRecordCount = beneficiarios.Count });
            }
            catch (Exception ex)
            {
                return Json($"ERRO: {ex.Message}");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BeneficiarioModel beneficiario)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    List<string> erros = (from item in ModelState.Values
                                          from error in item.Errors
                                          select error.ErrorMessage).ToList();

                    Response.StatusCode = 400;
                    return Json(string.Join(Environment.NewLine, erros));
                }

                var objToAdd = new Beneficiario(beneficiario.Cpf, beneficiario.Nome, beneficiario.IDCliente);

                var validador = beneficiarioValidator.Validate(objToAdd);

                if (!validador.IsValid)
                {
                    return Json(string.Join(Environment.NewLine, validador.Errors));
                }

                if (beneficiarioRepo.ValidateIfExists(beneficiario.Cpf, beneficiario.IDCliente))
                {
                    Response.StatusCode = 400;
                    return Json($"Este CPF de beneficiáriojá está cadastrado para este cliente!");
                }

                beneficiarioRepo.AddBeneficiario(objToAdd);

                return Json($"Cadastro do beneficiário {beneficiario.Nome} efetuado com sucesso!");


            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return Json($"CPF já existe!");
            }
            catch (Exception ex)
            {
                return Json($"ERRO: {ex.Message}");
            }
        }


        public JsonResult Update(int Id)
        {
            try
            {
                var beneficiario = beneficiarioRepo.GetBeneficiario(Id);

                return Json(new { beneficiario.ID, beneficiario.Nome, beneficiario.Cpf }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json($"ERRO: {ex.Message}");
            }

        }


        [HttpPost]
        public JsonResult Delete(int Id)
        {
            try
            {
                var beneficiario = beneficiarioRepo.GetBeneficiario(Id);

                beneficiarioRepo.DeleteBeneficiario(Id);

                return Json($"Beneficiário {beneficiario.Nome} excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return Json($"ERRO: {ex.Message}");
            }
        }
    }
}
