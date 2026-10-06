using System;

namespace CadCurriculoMVC.Models
{
    public class CurriculoViewModel
    {
        public int id { get; set; }

        // Dados pessoais
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        // Dados profissionais
        public string cargoPretendido { get; set; }
        public double? pretensaoSalarial { get; set; }
        public string resumoProfissional { get; set; }

        // Formação acadêmica e cursos
        public string formacao1 { get; set; }
        public string formacao2 { get; set; }
        public string formacao3 { get; set; }
        public string formacao4 { get; set; }
        public string formacao5 { get; set; }

        // Experiência profissional
        public string experiencia1 { get; set; }
        public string experiencia2 { get; set; }
        public string experiencia3 { get; set; }

        // Idiomas
        public string idioma1 { get; set; }
        public string idioma2 { get; set; }
        public string idioma3 { get; set; }
    }
}
