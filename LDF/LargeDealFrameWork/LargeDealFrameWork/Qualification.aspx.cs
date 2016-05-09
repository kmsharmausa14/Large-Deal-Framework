using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BO;
using BLL;


namespace LargeDealFrameWork
{
    public partial class Qualification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              PopulateActiveScoreScaleGridview();
        }

        private void PopulateActiveScoreScaleGridview()
        {
           
            try
            {
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveMainScreen();
                if (dsPopulateActiveScoreScaleGridview.Tables.Count > 0)
                {
                    if (dsPopulateActiveScoreScaleGridview.Tables[0].Rows.Count > 0)
                    {
                        gvScaleScore.DataSource = dsPopulateActiveScoreScaleGridview;
                        gvScaleScore.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void lnkClientPresenceScale_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientsDemandPresenceScale.aspx");
        }

        protected void lnkBusinessPriority_Click(object sender, EventArgs e)
        {
            Response.Redirect("SyntelBusinessPriorityScale.aspx");
        }

        protected void lnkUrgencyBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientsUrgencytoBuy.aspx");
        }

        protected void lnkCompetitiveAdvantage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SyntelsCompetitiveAdvantage.aspx");
        }

      
       
       
    }
}