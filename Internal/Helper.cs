namespace CamlBuilder4000.Internal
{
    internal static class Helper
    {
        internal static void CombineTwoQueries(bool or, CamlOperatorPicker query, CamlOperatorPicker query2)
        {
            string newCondition;
            if (query.currentCondition != null && query.query == "")
                newCondition = query.currentCondition;
            else
                newCondition = query.query;

            if (or)
                query.query = $@"<Or>{newCondition}{query2}</Or>";
            else
                query.query = $@"<And>{newCondition}{query2}</And>";

            query.currentCondition = null;
        }

        internal static void CombineCurrentQueryWithNewCondition(bool or, CamlOperatorPicker query, string newCondition)
        {
            if (query.currentCondition == null)
                query.currentCondition = newCondition;
            else
            {
                var currentQuery = query.query;
                if (currentQuery != "")
                {
                    if (query.currentCondition != null)
                    {
                        if (query.currentConditionIsOr)
                            currentQuery = $@"<Or>{currentQuery}{query.currentCondition}</Or>";
                        else
                            currentQuery = $@"<And>{currentQuery}{query.currentCondition}</And>";

                        query.currentCondition = null;
                    }
                }
                else
                {
                    if (query.currentCondition != null)
                    {
                        currentQuery = query.currentCondition;

                        query.currentCondition = null;
                    }
                }

                if (or)
                    query.query = $@"<Or>{currentQuery}{newCondition}</Or>";
                else
                    query.query = $@"<And>{currentQuery}{newCondition}</And>";
            }
        }
    }
}
