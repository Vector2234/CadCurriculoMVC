using CadCurriculoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    public class CurriculoDAO
    {
        public SqlParameter[] CriaParametros(CurriculoViewModel curriculo)
        {
            SqlParameter[] p = new SqlParameter[21];

            p[0] = new SqlParameter("id", curriculo.id);
            p[1] = new SqlParameter("nome", curriculo.nome);
            p[2] = new SqlParameter("cpf", curriculo.cpf);
            p[3] = new SqlParameter("dataNascimento", curriculo.dataNascimento);
            p[4] = new SqlParameter("endereco", curriculo.endereco);
            p[5] = new SqlParameter("telefone", curriculo.telefone);
            p[6] = new SqlParameter("email", curriculo.email);
            p[7] = new SqlParameter("cargoPretendido", curriculo.cargoPretendido);
            p[8] = new SqlParameter("pretensaoSalarial", curriculo.pretensaoSalarial);
            p[9] = new SqlParameter("resumoProfissional", curriculo.resumoProfissional);

            p[10] = new SqlParameter("formacao1", curriculo.formacao1);
            p[11] = new SqlParameter("formacao2", NullasDbNull(curriculo.formacao2));
            p[12] = new SqlParameter("formacao3", NullasDbNull(curriculo.formacao3));
            p[13] = new SqlParameter("formacao4", NullasDbNull(curriculo.formacao4));
            p[14] = new SqlParameter("formacao5", NullasDbNull(curriculo.formacao5));

            p[15] = new SqlParameter("experiencia1", NullasDbNull(curriculo.experiencia1));
            p[16] = new SqlParameter("experiencia2", NullasDbNull(curriculo.experiencia2));
            p[17] = new SqlParameter("experiencia3", NullasDbNull(curriculo.experiencia3));

            p[18] = new SqlParameter("idioma1", NullasDbNull(curriculo.idioma1));
            p[19] = new SqlParameter("idioma2", NullasDbNull(curriculo.idioma2));
            p[20] = new SqlParameter("idioma3", NullasDbNull(curriculo.idioma3));

            return p;
        }

        private object NullasDbNull(object valor)
        {
            if (valor == null)
                return DBNull.Value;
            else
                return valor;
        }

        public void Inserir(CurriculoViewModel curriculo)
        {
            SqlParameter[] p = CriaParametros(curriculo);
            string sql = "insert into curriculo(id, nome, cpf, dataNascimento, endereco, telefone, email, " +
                "cargoPretendido, pretensaoSalarial, resumoProfissional, formacao1, formacao2, " +
                "formacao3, formacao4, formacao5, experiencia1, experiencia2, experiencia3, idioma1, idioma2, idioma3) " +
                "values (@id, @nome, @cpf, @dataNascimento, @endereco, @telefone, @email, " +
                "@cargoPretendido, @pretensaoSalarial, @resumoProfissional, @formacao1, @formacao2, " +
                "@formacao3, @formacao4, @formacao5, @experiencia1, @experiencia2, @experiencia3, @idioma1, @idioma2, @idioma3)";

            HelperDAO.ExecutaSQL(sql, p);
        }

        public void Alterar(CurriculoViewModel curriculo)
        {
            string sql = "update curriculo set nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, endereco = @endereco, telefone = @telefone, email = @email, " +
            "cargoPretendido = @cargoPretendido, pretensaoSalarial = @pretensaoSalarial, resumoProfissional = @resumoProfissional, " +
            "formacao1 = @formacao1, formacao2 = @formacao2, formacao3 = @formacao3, formacao4 = @formacao4, formacao5 = @formacao5, " +
            "experiencia1 = @experiencia1, experiencia2 = @experiencia2, experiencia3 = @experiencia3, idioma1 = @idioma1, idioma2 = @idioma2, idioma3 = @idioma3 where id = @id";

            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }

        public void Excluir(int id)
        {
            string sql = "delete from curriculo where id = @id";

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("Id", id);

            HelperDAO.ExecutaSQL(sql, p);
        }

        public CurriculoViewModel Consulta(int id)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("Id", id);

            string sql = "select * from curriculo where id = @id";

            DataTable tabela = HelperDAO.ExecutaSelect(sql, p);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public CurriculoViewModel MontaModel(DataRow registro)
        {
            CurriculoViewModel curriculo = new CurriculoViewModel();

            curriculo.id = Convert.ToInt32(registro["id"]);
            curriculo.nome = registro["nome"].ToString();
            curriculo.cpf = registro["cpf"].ToString();
            curriculo.dataNascimento = Convert.ToDateTime(registro["dataNascimento"]);
            curriculo.endereco = registro["endereco"].ToString();
            curriculo.telefone = registro["telefone"].ToString();
            curriculo.email = registro["email"].ToString();

            curriculo.cargoPretendido = registro["cargoPretendido"].ToString();
            curriculo.pretensaoSalarial = Convert.ToDouble(registro["pretensaoSalarial"]);
            curriculo.resumoProfissional = registro["resumoProfissional"].ToString();

            curriculo.formacao1 = registro["formacao1"].ToString();
            curriculo.formacao2 = registro["formacao2"] == DBNull.Value ? null : registro["formacao2"].ToString();
            curriculo.formacao3 = registro["formacao3"] == DBNull.Value ? null : registro["formacao3"].ToString();
            curriculo.formacao4 = registro["formacao4"] == DBNull.Value ? null : registro["formacao4"].ToString();
            curriculo.formacao5 = registro["formacao5"] == DBNull.Value ? null : registro["formacao5"].ToString();

            curriculo.experiencia1 = registro["experiencia1"] == DBNull.Value ? null : registro["experiencia1"].ToString();
            curriculo.experiencia2 = registro["experiencia2"] == DBNull.Value ? null : registro["experiencia2"].ToString();
            curriculo.experiencia3 = registro["experiencia3"] == DBNull.Value ? null : registro["experiencia3"].ToString();

            curriculo.idioma1 = registro["idioma1"] == DBNull.Value ? null : registro["idioma1"].ToString();
            curriculo.idioma2 = registro["idioma2"] == DBNull.Value ? null : registro["idioma2"].ToString();
            curriculo.idioma3 = registro["idioma3"] == DBNull.Value ? null : registro["idioma3"].ToString();

            return curriculo;
        }

        public List<CurriculoViewModel> Listagem()
        {
            string sql = "select * from curriculo order by nome";

            using (DataTable tabela = HelperDAO.ExecutaSelect(sql, null))
            {
                List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
                foreach (DataRow registro in tabela.Rows)
                    lista.Add(MontaModel(registro));

                return lista;
            }
        }

        public int ProximoID()
        {
            string sql = "select isnull(max(Id) +1, 1) as 'MAIOR' from curriculo";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}
