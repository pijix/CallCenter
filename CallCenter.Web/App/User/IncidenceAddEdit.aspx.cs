using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
using CallCenter.DAL;

namespace CallCenter.Web.App.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private DBContext _dbContext;
        private IncidenceService _service;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new DBContext();
            _service = new IncidenceService(_dbContext);
        }

        protected void AddIncidence(object sender, EventArgs e)
        {

            try
            {
                var newIncidence = new Incidence
                {
                    DateCreation = DateTime.Today.Date,
                    IncidenceTitle = txtTitle.Text,
                    Priority = EnumIncidencePriority.Normal,
                };

                var incidence = _service.Add(newIncidence);

            }
            catch (Exception ex)
            {
                throw;
            }

            
            
        }

        protected void UpdateIncidence(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void DelteIncidence(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}