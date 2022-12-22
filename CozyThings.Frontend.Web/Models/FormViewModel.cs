namespace CozyThings.Frontend.Web.Models
{
    public abstract class FormViewModel
    {
        public int Id { get; set; }

        public FormAction Action { get; set; }
    }

    public enum FormAction
    {
        Create, Update
    }
}
