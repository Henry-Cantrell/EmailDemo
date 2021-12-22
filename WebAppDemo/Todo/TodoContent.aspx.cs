using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDemo.DAL;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using TextBox = System.Web.UI.WebControls.TextBox;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using NPOI.SS.Formula.Functions;
using MailKit.Net.Smtp;
using SmtpClient = System.Net.Mail.SmtpClient;
using System.Activities.Expressions;
using WebAppDemo.ClassLibrary;

namespace WebAppDemo.Todo
{
    /// <summary>
    /// This partial controls gridview events and also handles email sending
    /// </summary>
    public partial class TodoContent : System.Web.UI.Page
    {
        crud cr = new crud();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvOneBind();
            }
        }

        public void gdvOneBind()
        {
            DataTable dt1 = cr.GetTodos();
            gdvOne.DataSource = dt1;
            gdvOne.DataBind();
        }

        protected void gdvOne_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvOne.EditIndex = e.NewEditIndex;
            gdvOneBind();
        }

        protected void gdvOne_OnRowEditCancel(object sender, GridViewCancelEditEventArgs e)
        {
            gdvOne.EditIndex = -1;
            gdvOneBind();
        }
        protected void gdvOne_OnPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            gdvOne.PageIndex = e.NewPageIndex;
            gdvOneBind();
        }
        protected void gdvOne_OnRowDelete(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gdvOne.Rows[e.RowIndex];
            int databaseID = Convert.ToInt32(gdvOne.DataKeys[e.RowIndex].Value.ToString());
            cr.DeleteRow(databaseID);
            gdvOneBind();
        }
        protected void gdvOne_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gdvOne.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)gdvOne.Rows[e.RowIndex];
            TextBox textTodo = (TextBox)row.Cells[0].Controls[0];
            string todo = textTodo.Text;

            cr.UpdateRow(id, todo);
            gdvOne.EditIndex = -1;
            gdvOneBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string todo = txtTodo.Text;
            try
            {
                cr.InsertTodo(todo);
                gdvOneBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            txtTodo.Text = "";
        }
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //getting row data
                int rowIndex = ((GridViewRow)((System.Web.UI.Control)sender).NamingContainer).RowIndex;
                GridViewRow row = (GridViewRow)gdvOne.Rows[rowIndex];
                string todo = row.Cells[0].Text;

                //sending mail
                Email.sendEmail(todo);
                lblMsg.Text = "Success: Mail sent successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (SmtpException ex)
            {
                //catched smtp exception
                lblMsg.Text = "SMTP Exception: " + ex.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

