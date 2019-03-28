using BOL;

namespace DAL
{
    public class EntidadBase
    {
        protected HtmlHelperDbEntities db;

        public EntidadBase()
        {
            db = new HtmlHelperDbEntities();
        }
    }
}
