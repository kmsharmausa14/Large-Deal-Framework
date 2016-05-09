using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    class paramBO
    {
        #region Private Variables
        private List<ParamcolumnsBO> _businesssolution;
        private List<ParamcolumnsBO> _technicalsolution;
        private List<ParamcolumnsBO> _servicedeliverymodel;
        private List<ParamcolumnsBO> _transitionplanning;
        private List<ParamcolumnsBO> _governanceengagementmodel;
        private List<ParamcolumnsBO> _processmethodologies;
        private List<ParamcolumnsBO> _hrandchangemanagement;
        private List<ParamcolumnsBO> _commercialandplanning;
        private List<ParamcolumnsBO> _integrations;
        private List<ParamcolumnsBO> _finalscore;
        #endregion

        #region Public VARIABLES
        public List<ParamcolumnsBO> Businesssolution
        {
            get { return _businesssolution;}
            set { _businesssolution = value;}
        }

        public List<ParamcolumnsBO> Technicalsolution
        {
            get { return _technicalsolution; }
            set { _technicalsolution = value; }
        }

        public List<ParamcolumnsBO> Servicedeliverymodel
        {
            get { return _servicedeliverymodel; }
            set { _servicedeliverymodel = value; }
        }

        public List<ParamcolumnsBO> Transitionplanning
        {
            get { return _transitionplanning; }
            set { _transitionplanning = value; }
        }

        public List<ParamcolumnsBO> Governanceengagementmodel
        {
            get { return _governanceengagementmodel; }
            set { _governanceengagementmodel = value; }
        }

        public List<ParamcolumnsBO> Processmethodologies
        {
            get { return _processmethodologies; }
            set { _processmethodologies = value; }
        }

        public List<ParamcolumnsBO> Hrandchangemanagement
        {
            get { return _hrandchangemanagement; }
            set { _hrandchangemanagement = value; }
        }

        public List<ParamcolumnsBO> Commercialandplanning
        {
            get { return _commercialandplanning; }
            set { _commercialandplanning = value; }
        }

        public List<ParamcolumnsBO> Integrations
        {
            get { return _integrations; }
            set { _integrations = value; }
        }

        public List<ParamcolumnsBO> Finalscore
        {
            get { return _finalscore; }
            set { _finalscore = value; }
        }

        #endregion


    }
}
