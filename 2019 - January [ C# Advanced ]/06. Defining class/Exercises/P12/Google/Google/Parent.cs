namespace Google
{
    public class Parent
    {
        private string parentName;
        private string parentBirthday;

        public Parent()
        {

        }
        public Parent(string parentName, string parentBirthday)
        {
            this.ParentName = parentName;
            this.ParentBirthday = parentBirthday;
        }
        public override string ToString()
        {
            if (parentName == null)
            {
                return "";
            }
            return "\r\n" + this.ParentName + " " + this.ParentBirthday;
        }

        public string ParentName { get => parentName; set => parentName = value; }
        public string ParentBirthday { get => parentBirthday; set => parentBirthday = value; }
    }
}