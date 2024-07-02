using Oracle.ManagedDataAccess.Client;

namespace OrcaleDbHelper
{
    public class DataParamCol
    {
        private List<OracleParameter> parameters = new List<OracleParameter>();

        public void Add(string parameterName, object value, bool isLike = false)
        {
            if (isLike && value != null)
            {
                value = $"%{value}%";
            }
            parameters.Add(new OracleParameter(parameterName, value));
        }

        public OracleParameter[] ToArray()
        {
            return parameters.ToArray();
        }
    }
}
