using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebWallet.Dto;
using WebWallet.Entity;
using WebWallet.Param;
using WebWallet.Service;
using recurso = WebWallet.Service.UrlApi;

namespace WebWallet
{
    public partial class Transaction : System.Web.UI.Page
    {
        #region Atributos

        DataTable table = new DataTable();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                table = new DataTable();
                BindMyGrid(null);
                ResetearBalance();
            }
        }

        public void ResetearBalance()
        {
            var trans = new ConsultTransactionParam()
            {
                IdBilletera = 1
            };

            var transaction = AppServices.ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.ResetBalanceWallet
                );

        }

        private void BindMyGrid(RegistroBilletera res)
        {
            if (res != null)
            {
                table = (System.Data.DataTable)Session["Lista"];

                if (table.Rows.Count >= 0)
                {
                    lbl_balance.Text = res.Balance.ToString();
                    table.Rows.Add(res.IdWallet, res.IdTypeTransaction, res.Amount);
                    Session["Lista"] = table;
                    dg_transaccion.DataSource = table;
                    dg_transaccion.DataBind();
                }
            }
            else
            {

                table = new DataTable();

                table.Columns.Add("IdBilletera");
                table.Columns.Add("IdTipoTransaccion");
                table.Columns.Add("Monto");

                Session["Lista"] = table;
                dg_transaccion.DataSource = table;
                dg_transaccion.DataBind();
            }

        }

        protected void bnt_Registro_Click(object sender, EventArgs e)
        {
            var idBilletera = Convert.ToInt32(txt_IdWallet.Text);
            var idTipoTransaccion = Convert.ToByte(txt_IdTypeTransaction.Text);
            var monto = Convert.ToDecimal(txt_Amount.Text);

 

            var trans = new TransactionParam()
            {
                IdBilletera = idBilletera,
                IdTipoTransaccion = idTipoTransaccion,
                Monto = monto
            };

            var transaction = AppServices.ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.RegistrarTransaccion
                );

   

            var result = JsonConvert.DeserializeObject<TransactionDto>(transaction.Content);



            BindMyGrid(new RegistroBilletera()
            {
                IdWallet = trans.IdBilletera,
                IdTypeTransaction = trans.IdTipoTransaccion,
                Amount = result.Amount,
                Balance = result.Balance
            });
        }

        protected void btn_Consultar_Click(object sender, EventArgs e)
        {
            var idBilletera = Convert.ToInt32(txt_IdWallet.Text);

            var trans = new ConsultTransactionParam()
            {
                IdBilletera = idBilletera
            };

            var transaction = AppServices.ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.ConsultarTransaccion
                );



            var result = JsonConvert.DeserializeObject<TransactionDto>(transaction.Content);


            if (result != null)
            {
                lbl_balance.Text = result.Balance.ToString();
            }
        }
    }
}