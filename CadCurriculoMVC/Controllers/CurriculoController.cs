using CadCurriculoMVC.DAO;
using CadCurriculoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadCurriculoMVC.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                List<CurriculoViewModel> lista = dao.Listagem();
                return View(lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Create()
        {
            try
            {
                CurriculoViewModel curriculo = new CurriculoViewModel();

                CurriculoDAO dao = new CurriculoDAO();
                curriculo.id = dao.ProximoID();

                return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(curriculo.id) == null)
                    dao.Inserir(curriculo);
                else
                    dao.Alterar(curriculo);

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Curriculo(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();

                CurriculoViewModel curriculo = dao.Consulta(id);

                if (curriculo == null)
                    return RedirectToAction("Index");

                return View(curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
